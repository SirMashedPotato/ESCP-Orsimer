﻿using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;


namespace MorrowRim_Orsimir
{
    //Setting the Harmony instance
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            var harmony = new Harmony("com.MorrowRim_Orsimir");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    /* 
     * Patch that checks for thing made of orichalcum and made by Orsimer
     * If thing is found, increase quality level by 1
     */
    [HarmonyPatch(typeof(GenRecipe))]
    [HarmonyPatch("PostProcessProduct")]
    public static class GenRecipe_PostProcessProduct_Patch
    {
        [HarmonyTranspiler]
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            if (ESCP_Orsimer_Mod.ESCP_Orsimer_EnableOrichalcPatch())
            {
                var codes = new List<CodeInstruction>(instructions);
                //used for checking for the right function call
                var generateQuality = AccessTools.Method(typeof(QualityUtility), nameof(QualityUtility.GenerateQualityCreatedByPawn), new Type[] { typeof(Pawn), typeof(SkillDef)});
                //function that is called to check quality
                var stuffCheck = AccessTools.Method(typeof(HarmonyUtility), nameof(HarmonyUtility.CheckQualityIncrease));
                //find the right position in the stack
                for (int i = 0; i < codes.Count; i++)
                {
                    if (codes[i].opcode == OpCodes.Call && codes[i].operand == generateQuality)
                    {
                        yield return codes[i];
                        yield return new CodeInstruction(OpCodes.Stloc_2); // stores original quality
                        yield return new CodeInstruction(OpCodes.Ldarg_2); // pawn
                        yield return new CodeInstruction(OpCodes.Ldloc_2); // loads original quality
                        yield return new CodeInstruction(OpCodes.Ldarg_0); // thing
                        yield return new CodeInstruction(OpCodes.Ldarg_1); // recipe def
                        codes[i] = new CodeInstruction(OpCodes.Call, stuffCheck); // modify
                        yield return codes[i]; // and return modifed
                        if (ESCP_Orsimer_Mod.ESCP_Orsimer_Logging()) Log.Message("ESCP_Orsimer_ModName".Translate() + ", has succesfully patched GenRecipe.PostProcessProduct");
                    } 
                    else
                    {
                        yield return codes[i];
                    }
                }
            }
        }
    }
}