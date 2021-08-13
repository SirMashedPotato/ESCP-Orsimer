﻿using RimWorld;
using Verse;
using System;
using System.Collections.Generic;

namespace MorrowRim_Orsimir
{
    class CompProperties_BeserkerRage : CompProperties
    {
		public CompProperties_BeserkerRage()
		{
			this.compClass = typeof(Comp_BeserkerRage);
		}
		public HediffDef hediffDef;
		public bool enableAugments = false;
		public RecordDef recordDef;
		public List<ThingDef> totems;
		public List<HediffDef> augments;
		public bool enableTracker = true;
	}
}