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
            Log.Message("1.1");
            return p != null && p.def == ThingDef.Named("MorrowRim_OrsimerRace");
        }

        public static bool MadeOfOrichalc(Thing t)
        {
            Log.Message("1.2");
            return t != null && t.Stuff != null && t.Stuff == ThingDef.Named("MorrowRim_Orichalcum");
        }
    }
}
