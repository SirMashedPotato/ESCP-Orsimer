using UnityEngine;
using Verse;
using System;

namespace MorrowRim_Orsimir
{
    class ESCP_Orsimer_Mod : Mod
    {
        ESCP_Orsimer_ModSettings settings;
        public ESCP_Orsimer_Mod(ModContentPack contentPack) : base(contentPack)
        {
            this.settings = GetSettings<ESCP_Orsimer_ModSettings>();
        }

        public override string SettingsCategory() => "ESCP_Orsimer_ModName".Translate();

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.Begin(inRect);

            //listing_Standard.CheckboxLabeled("ESCP_Orsimer_EnableEchaterePatch".Translate(), ref settings.ESCP_Orsimer_EnableEchaterePatch, "ESCP_Orsimer_EnableEchaterePatchTooltip".Translate());
            //listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("ESCP_Orsimer_EnableOrichalcPatch".Translate(), ref settings.ESCP_Orsimer_EnableOrichalcPatch, "ESCP_Orsimer_EnableOrichalcPatchTooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.Label("ESCP_Orsimer_EnableOrichalcPatchChance".Translate() + " (" + settings.ESCP_Orsimer_EnableOrichalcPatchChance * 100 + "%)");
            settings.ESCP_Orsimer_EnableOrichalcPatchChance = (float)Math.Round(listing_Standard.Slider(settings.ESCP_Orsimer_EnableOrichalcPatchChance, 0f, 1f) * 20) / 20;
            listing_Standard.Gap();

            listing_Standard.GapLine();
            if (Prefs.DevMode)
            {
                listing_Standard.CheckboxLabeled("ESCP_Logging".Translate(), ref settings.ESCP_Orsimer_Logging, "ESCP_Orsimer_Logging".Translate());
                listing_Standard.Gap();
            }

            //reset button
            Rect rectReset = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(rectReset, "ESCP_Reset".Translate());
            if (Widgets.ButtonText(rectReset, "ESCP_Reset".Translate(), true, true, true))
            {
                ESCP_Orsimer_ModSettings.ResetSettings(settings);
            }
            listing_Standard.Gap();

            listing_Standard.End();
            base.DoSettingsWindowContents(inRect);
        }

        /* returns */
        /*
        public static bool ESCP_Orsimer_EnableEchaterePatch()
        {
            return LoadedModManager.GetMod<ESCP_Orsimer_Mod>().GetSettings<ESCP_Orsimer_ModSettings>().ESCP_Orsimer_EnableEchaterePatch;
        }
        */
        public static bool ESCP_Orsimer_EnableOrichalcPatch()
        {
            return LoadedModManager.GetMod<ESCP_Orsimer_Mod>().GetSettings<ESCP_Orsimer_ModSettings>().ESCP_Orsimer_EnableOrichalcPatch;
        }

        public static float ESCP_Orsimer_EnableOrichalcPatchChance()
        {
            return LoadedModManager.GetMod<ESCP_Orsimer_Mod>().GetSettings<ESCP_Orsimer_ModSettings>().ESCP_Orsimer_EnableOrichalcPatchChance;
        }

        public static bool ESCP_Orsimer_Logging()
        {
            return LoadedModManager.GetMod<ESCP_Orsimer_Mod>().GetSettings<ESCP_Orsimer_ModSettings>().ESCP_Orsimer_Logging && Prefs.DevMode;
        }
    }
}
