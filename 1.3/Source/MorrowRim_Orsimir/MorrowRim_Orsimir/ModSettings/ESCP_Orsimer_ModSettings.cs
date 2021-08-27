using Verse;

namespace MorrowRim_Orsimir
{
    class ESCP_Orsimer_ModSettings : ModSettings
    {
        //settings
        public bool ESCP_Orsimer_EnableOrichalcPatch = ESCP_Orsimer_EnableOrichalcPatch_def;
        public float ESCP_Orsimer_EnableOrichalcPatchChance = ESCP_Orsimer_EnableOrichalcPatchChance_def;
        //public bool ESCP_Orsimer_EnableEchaterePatch = ESCP_Orsimer_EnableEchaterePatch_def;
        public bool ESCP_Orsimer_Logging = ESCP_Orsimer_Logging_def;

        //defaults
        private static readonly bool ESCP_Orsimer_EnableOrichalcPatch_def = true;
        private static readonly float ESCP_Orsimer_EnableOrichalcPatchChance_def = 1f;
        //private static readonly bool ESCP_Orsimer_EnableEchaterePatch_def = true;
        private static readonly bool ESCP_Orsimer_Logging_def = false;

        //save settings
        public override void ExposeData()
        {
            Scribe_Values.Look(ref ESCP_Orsimer_EnableOrichalcPatch, "ESCP_Orsimer_EnableOrichalcPatch", ESCP_Orsimer_EnableOrichalcPatch_def);
            Scribe_Values.Look(ref ESCP_Orsimer_EnableOrichalcPatchChance, "ESCP_Orsimer_EnableOrichalcPatchChance", ESCP_Orsimer_EnableOrichalcPatchChance_def);
            //Scribe_Values.Look(ref ESCP_Orsimer_EnableEchaterePatch, "ESCP_Orsimer_EnableEchaterePatch", ESCP_Orsimer_EnableEchaterePatch_def);
            Scribe_Values.Look(ref ESCP_Orsimer_Logging, "ESCP_Orsimer_Logging", ESCP_Orsimer_Logging_def);
            base.ExposeData();
        }

        //rest settings
        public static void ResetSettings(ESCP_Orsimer_ModSettings settings)
        {
            settings.ESCP_Orsimer_EnableOrichalcPatch = ESCP_Orsimer_EnableOrichalcPatch_def;
            settings.ESCP_Orsimer_EnableOrichalcPatchChance = ESCP_Orsimer_EnableOrichalcPatchChance_def;
            settings.ESCP_Orsimer_Logging = ESCP_Orsimer_Logging_def;
        }
    }
}
