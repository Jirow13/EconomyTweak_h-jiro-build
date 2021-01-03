using System;
using HarmonyLib;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace EconomyTweak_h
{
	// Token: 0x02000002 RID: 2
	public class SubModule : MBSubModuleBase
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002048 File Offset: 0x00000248
		protected override void OnSubModuleLoad()
		{
			base.OnSubModuleLoad();
			EconomyTweak_h_globalConstants.EconomyTweak_h_globalConstants_read();
			Harmony harmony = new Harmony("EconomyTweak_h");
			harmony.PatchAll();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002075 File Offset: 0x00000275
		protected override void OnBeforeInitialModuleScreenSetAsRoot()
		{
			base.OnBeforeInitialModuleScreenSetAsRoot();
			InformationManager.DisplayMessage(new InformationMessage("EconomyTweak by heu3becteh v0.152.1"));
		}
	}
}
