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
            Log.Message("skill = " + recipe.workSkill);
            return recipe.workSkill == SkillDefOf.Crafting;
        }

        public static QualityCategory CheckQualityIncrease(Pawn worker, QualityCategory initial, Thing thing, RecipeDef recipe)
        {
            if (IsOrsimer(worker) && MadeOfOrichalc(thing) && RightSkill(recipe) && initial != QualityCategory.Legendary)
            {
                Log.Message("Initial = " + initial);
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
