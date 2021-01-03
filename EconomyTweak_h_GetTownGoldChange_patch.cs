using System;
using System.IO;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Core;

namespace EconomyTweak_h
{
	// Token: 0x0200000B RID: 11
	[HarmonyPatch(typeof(DefaultSettlementEconomyModel), "GetTownGoldChange")]
	internal class EconomyTweak_h_GetTownGoldChange_patch
	{
		// Token: 0x06000037 RID: 55 RVA: 0x00003BDC File Offset: 0x00001DDC
		[HarmonyPrefix]
		public static bool EconomyTweak_h_GetTownGoldChange(Town town, ref int __result)
		{
			int gold = town.Gold;
			float num = town.Prosperity;
			float num2 = (float)gold * 0.95f + num * EconomyTweak_h_globalConstants.EconomyTweak_h_MarketGoldProsperityRatio * EconomyTweak_h_globalConstants.EconomyTweak_h_ValueOfProsperity * 0.05f;
			int num3 = MBRandom.RoundRandomized(num2 - (float)gold);
			__result = num3;
			bool flag = EconomyTweak_h_globalConstants.EconomyTweak_h_DebugLevel > 0;
			if (flag)
			{
				using (StreamWriter streamWriter = File.AppendText(EconomyTweak_h_globalConstants.EconomyTweak_h_path + "EconomyTweak_h_log.txt"))
				{
					streamWriter.WriteLine("EconomyTweak_h_GetTownGoldChange");
				}
				bool economyTweak_h_DebugDisplay = EconomyTweak_h_globalConstants.EconomyTweak_h_DebugDisplay;
				if (economyTweak_h_DebugDisplay)
				{
					InformationManager.DisplayMessage(new InformationMessage("EconomyTweak_h_GetTownGoldChange"));
				}
				bool flag2 = EconomyTweak_h_globalConstants.EconomyTweak_h_DebugLevel > 1;
				if (flag2)
				{
					using (StreamWriter streamWriter2 = File.AppendText(EconomyTweak_h_globalConstants.EconomyTweak_h_path + "EconomyTweak_h_log.txt"))
					{
						streamWriter2.WriteLine(string.Concat(new string[]
						{
							"town = ",
							town.ToString(),
							", EconomyTweak_h_TownGold = ",
							gold.ToString(),
							", EconomyTweak_h_TownProsperity = ",
							num.ToString(),
							", EconomyTweak_h_GetTownGoldChange(result) = ",
							__result.ToString()
						}));
					}
				}
			}
			return false;
		}
	}
}
