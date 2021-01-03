using System;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Core;

namespace EconomyTweak_h
{
	// Token: 0x0200000C RID: 12
	[HarmonyPatch(typeof(DefaultVillageProductionCalculatorModel), "CalculateDailyProductionAmount")]
	internal class EconomyTweak_h_CalculateDailyProductionAmount_patch
	{
		// Token: 0x06000039 RID: 57 RVA: 0x00003D48 File Offset: 0x00001F48
		[HarmonyPostfix]
		public static void EconomyTweak_h_CalculateDailyProductionAmount(Village village, ItemObject item, ref float __result)
		{
			__result *= EconomyTweak_h_globalConstants.EconomyTweak_h_ProductionMultiplier;
		}
	}
}
