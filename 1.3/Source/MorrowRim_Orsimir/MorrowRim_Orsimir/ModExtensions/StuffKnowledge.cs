using Verse;
using RimWorld;
using System.Collections.Generic;


namespace MorrowRim_Orsimir
{
    class StuffKnowledge : DefModExtension
    {
        public List<string> stuffList;
        //public List<ThingDef> stuffList = new List<ThingDef> { };
        public SkillDef skill;

        public static StuffKnowledge Get(Def def)
        {
            return def.GetModExtension<StuffKnowledge>();
        }
    }
}
