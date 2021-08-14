using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using System.Reflection;
using Verse;
using System;
using System.Linq;
using System.Collections.Generic;
using Verse.AI;
using Verse.AI.Group;
using System.Text;
using UnityEngine;

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

    [HarmonyPatch(typeof(QuestManager))]
    [HarmonyPatch("Notify_ThingsProduced")]
    public static class QuestManager_NotifyThingsProduced_Patch
    {
        [HarmonyPostfix]
        [HarmonyPriority(Priority.Last)]
        public static void CheckOrichalcum(Pawn worker, List<Thing> things)
        {
            Log.Message("1");
            foreach (Thing thing in things)
            {
                Log.Message(": " + thing);
                if (thing.def.CostStuffCount > 0 && HarmonyUtility.MadeOfOrichalc(thing) && HarmonyUtility.IsOrsimer(worker))
                {
                    Log.Message("2");
                    if (thing.def.comps.Any(x => x.compClass.Name == "CompQuality"))
                    {
                        Log.Message("3");
                        thing.TryGetQuality(out QualityCategory qc);
                        if (qc != QualityCategory.Legendary)
                        {
                            thing.TryGetComp<CompQuality>().SetQuality(qc + 1, new ArtGenerationContext());
                            Log.Message("Quality increased for: " + thing + ", from: " + qc);
                        }
                    }
                }
            }
        }
    }
}
