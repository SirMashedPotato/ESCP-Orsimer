using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using RimWorld;
using System.Reflection.Emit;
using System.Linq;

namespace MorrowRim_Orsimir
{
    public static class HarmonyUtility
    {
        /* For qulity patch */
        public static bool IsOrsimer(Pawn p)
        {
            return p != null && p.def == ThingDef.Named("ESCP_OrsimerRace");
        }

        public static bool MadeOfOrichalc(Thing t)
        {
            return t != null && t.Stuff != null && t.Stuff == ThingDef.Named("ESCP_Orichalcum");
        }

        public static bool RightSkill(RecipeDef recipe)
        {
            return recipe.workSkill == SkillDefOf.Crafting;
        }

        public static bool ChanceIncrease()
        {
            bool chance = Rand.Chance(ESCP_Orsimer_Mod.ESCP_Orsimer_EnableOrichalcPatchChance());
            return chance;
        }

        public static QualityCategory CheckQualityIncrease(Pawn worker, QualityCategory initial, Thing thing, RecipeDef recipe)
        {
            if (initial != QualityCategory.Legendary && RightSkill(recipe) && MadeOfOrichalc(thing) && IsOrsimer(worker) && ChanceIncrease())
            {
                if (ESCP_Orsimer_Mod.ESCP_Orsimer_Logging()) Log.Message("Initial quality of  " + thing + " = " + initial + ", improved quality = " + initial+1); ;
                return initial+1;
            }
            return initial;
        }

        /* for taming patch */
        /*
        public static bool IsOrsimerTamable(Pawn p)
        {
            return p != null && (p.def == ThingDef.Named("ESCP_Echatere") || p.def == ThingDef.Named("ESCP_Welwa"));
        }
        */
    }
}
