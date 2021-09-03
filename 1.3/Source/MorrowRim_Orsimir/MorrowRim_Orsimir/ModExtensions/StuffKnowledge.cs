using Verse;
using RimWorld;
using System.Collections.Generic;


namespace MorrowRim_Orsimir
{
    class StuffKnowledge : DefModExtension
    {
        public List<string> stuffList;
        public SkillDef skill;
        public TraitDef requiredTrait = null;
        public HediffDef requiredHediff = null;
        public Backstory requiredBackstory = null;

        public static StuffKnowledge Get(Def def)
        {
            return def.GetModExtension<StuffKnowledge>();
        }
    }
}
