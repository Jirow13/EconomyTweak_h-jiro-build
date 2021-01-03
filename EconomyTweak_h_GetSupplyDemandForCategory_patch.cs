using System;
using System.IO;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace EconomyTweak_h
{
	// Token: 0x02000007 RID: 7
	[HarmonyPatch(typeof(DefaultSettlementEconomyModel), "GetSupplyDemandForCategory")]
	internal class EconomyTweak_h_GetSupplyDemandForCategory_patch
	{
		// Token: 0x0600002F RID: 47 RVA: 0x00002D08 File Offset: 0x00000F08
		[HarmonyPrefix]
		public static bool EconomyTweak_h_GetSupplyDemandForCategory(Town town, ItemCategory category, float dailySupply, float dailyDemand, float oldSupply, float oldDemand, ref ValueTuple<float, float> __result)
		{
			float num = dailySupply;
			float num2 = (float)EconomyTweak_h_globalConstants.EconomyTweak_h_OptimalStockPeriodPrice * dailyDemand;
			float item = oldDemand * MathF.Pow(dailyDemand / oldDemand, 0.2f);
			float num3 = MathF.Pow((num2 + dailyDemand + 1f) / (num + dailyDemand + 1f), EconomyTweak_h_globalConstants.EconomyTweak_h_LongtermPriceMultiplierExpValue);
			bool flag = oldSupply > 10f;
			if (flag)
			{
				oldSupply = MathF.Clamp(oldDemand / oldSupply, 0.5f, 1.5f);
			}
			float num4 = oldSupply * MathF.Pow(num3 / oldSupply, 0.2f);
			num4 = MathF.Clamp(num4, 0.4f, 10f);
			__result = new ValueTuple<float, float>(num4, item);
			bool flag2 = EconomyTweak_h_globalConstants.EconomyTweak_h_DebugLevel > 0;
			if (flag2)
			{
				using (StreamWriter streamWriter = File.AppendText(EconomyTweak_h_globalConstants.EconomyTweak_h_path + "EconomyTweak_h_log.txt"))
				{
					streamWriter.WriteLine("EconomyTweak_h_GetSupplyDemandForCategory");
				}
				bool economyTweak_h_DebugDisplay = EconomyTweak_h_globalConstants.EconomyTweak_h_DebugDisplay;
				if (economyTweak_h_DebugDisplay)
				{
					InformationManager.DisplayMessage(new InformationMessage("EconomyTweak_h_GetSupplyDemandForCategory"));
				}
				bool flag3 = EconomyTweak_h_globalConstants.EconomyTweak_h_DebugLevel > 1;
				if (flag3)
				{
					using (StreamWriter streamWriter2 = File.AppendText(EconomyTweak_h_globalConstants.EconomyTweak_h_path + "EconomyTweak_h_log.txt"))
					{
						streamWriter2.WriteLine(string.Concat(new string[]
						{
							"town = ",
							town.ToString(),
							", category = ",
							category.ToString(),
							", dailySupply = ",
							dailySupply.ToString(),
							", dailyDemand = ",
							dailyDemand.ToString(),
							", oldSupply = ",
							oldSupply.ToString(),
							", oldDemand = ",
							oldDemand.ToString(),
							", EconomyTweak_h_LongtermPriceMultiplier = ",
							num3.ToString(),
							", newDemand(item) = ",
							item.ToString(),
							", newSupply(num) = ",
							num4.ToString(),
							", EconomyTweak_h_GetSupplyDemandForCategory(result) = ",
							__result.ToString()
						}));
					}
				}
			}
			return false;
		}
	}
}
