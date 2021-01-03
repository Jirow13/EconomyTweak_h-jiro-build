using System;
using System.IO;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace EconomyTweak_h
{
	// Token: 0x0200000A RID: 10
	[HarmonyPatch(typeof(DefaultSettlementProsperityModel), "CalculateProsperityChange")]
	internal class EconomyTweak_h_CalculateProsperityChange_patch
	{
		// Token: 0x06000035 RID: 53 RVA: 0x00003798 File Offset: 0x00001998
		[HarmonyPostfix]
		public static void EconomyTweak_h_CalculateProsperityChange(Town fortification, StatExplainer explanation, ref float __result)
		{
			int gold = fortification.Gold;
			float num = fortification.Prosperity;
			float foodChange = fortification.FoodChange;
			float foodStocks = fortification.FoodStocks;
			float value = 0f;
			float num2 = 0f;
			int num3 = 0;
			float value2 = 0f;
			ExplainedNumber explainedNumber = new ExplainedNumber(0f, explanation, null);
			ExplainedNumber explainedNumber2 = new ExplainedNumber(0f, explanation, null);
			ExplainedNumber explainedNumber3 = new ExplainedNumber(0f, explanation, null);
			bool flag = !fortification.IsCastle;
			if (flag)
			{
				bool flag2 = EconomyTweak_h_Dictionaries.EconomyTweak_h_TownDemandFulfilledDictionary.ContainsKey(fortification);
				if (flag2)
				{
					TextObject desription = new TextObject("Demands Fulfilled", null);
					bool flag3 = EconomyTweak_h_Dictionaries.EconomyTweak_h_TownDemandFulfilledDictionary[fortification] < 0f;
					if (flag3)
					{
						value = MathF.Pow(-EconomyTweak_h_Dictionaries.EconomyTweak_h_TownDemandFulfilledDictionary[fortification], EconomyTweak_h_globalConstants.EconomyTweak_h_TownDemandFulfilledProsperityExpValue);
					}
					else
					{
						value = MathF.Pow(EconomyTweak_h_Dictionaries.EconomyTweak_h_TownDemandFulfilledDictionary[fortification], EconomyTweak_h_globalConstants.EconomyTweak_h_TownDemandFulfilledProsperityExpValue);
					}
					value = MathF.Clamp(value, -num * 0.05f, num * 0.05f);
					explainedNumber.Add(value, desription, null);
					__result += explainedNumber.ResultNumber;
				}
				num2 = (float)gold * 0.95f + num * EconomyTweak_h_globalConstants.EconomyTweak_h_MarketGoldProsperityRatio * EconomyTweak_h_globalConstants.EconomyTweak_h_ValueOfProsperity * 0.05f;
				num3 = MBRandom.RoundRandomized(num2 - (float)gold);
				num2 = (float)(gold - num3) * 0.95f + num * EconomyTweak_h_globalConstants.EconomyTweak_h_MarketGoldProsperityRatio * EconomyTweak_h_globalConstants.EconomyTweak_h_ValueOfProsperity * 0.05f;
				num3 = MBRandom.RoundRandomized(num2 - (float)gold);
				bool flag4 = num3 < 0;
				string value3;
				if (flag4)
				{
					value3 = "Currency Investment";
				}
				else
				{
					value3 = "Currency Withdrawal";
				}
				TextObject desription2 = new TextObject(value3, null);
				explainedNumber2.Add((float)(-(float)num3) / EconomyTweak_h_globalConstants.EconomyTweak_h_ValueOfProsperity, desription2, null);
				__result += explainedNumber2.ResultNumber;
			}
			float num4 = foodStocks + foodChange * (float)EconomyTweak_h_globalConstants.EconomyTweak_h_OptimalStockPeriodFood - num / 50f;
			bool flag5 = foodChange < 0f || num4 < 0f;
			if (flag5)
			{
				TextObject desription3 = new TextObject("Food Supply Shortage", null);
				value2 = MathF.Clamp(foodChange - MathF.Pow(-Math.Min(0f, num4), EconomyTweak_h_globalConstants.EconomyTweak_h_FoodShortageProsperityExpValue), -num * 0.05f, 0f);
				explainedNumber3.Add(value2, desription3, null);
				__result += explainedNumber3.ResultNumber;
			}
			bool flag6 = EconomyTweak_h_globalConstants.EconomyTweak_h_DebugLevel > 0;
			if (flag6)
			{
				using (StreamWriter streamWriter = File.AppendText(EconomyTweak_h_globalConstants.EconomyTweak_h_path + "EconomyTweak_h_log.txt"))
				{
					streamWriter.WriteLine("EconomyTweak_h_CalculateProsperityChange");
				}
				bool economyTweak_h_DebugDisplay = EconomyTweak_h_globalConstants.EconomyTweak_h_DebugDisplay;
				if (economyTweak_h_DebugDisplay)
				{
					InformationManager.DisplayMessage(new InformationMessage("EconomyTweak_h_CalculateProsperityChange"));
				}
				bool flag7 = EconomyTweak_h_globalConstants.EconomyTweak_h_DebugLevel > 1;
				if (flag7)
				{
					using (StreamWriter streamWriter2 = File.AppendText(EconomyTweak_h_globalConstants.EconomyTweak_h_path + "EconomyTweak_h_log.txt"))
					{
						streamWriter2.WriteLine(string.Concat(new string[]
						{
							"fortification = ",
							fortification.ToString(),
							", EconomyTweak_h_TownProsperity = ",
							num.ToString(),
							", EconomyTweak_h_TownGold = ",
							gold.ToString(),
							", EconomyTweak_h_TownDemandFulfilledValue = ",
							value.ToString(),
							", explainedNumber_TownDemandFulfilled = ",
							explainedNumber.ResultNumber.ToString(),
							", EconomyTweak_h_TargetGold = ",
							num2.ToString(),
							", EconomyTweak_h_TargetGoldChange = ",
							num3.ToString(),
							", explainedNumber_TargetGoldChange = ",
							explainedNumber2.ResultNumber.ToString(),
							", EconomyTweak_h_FoodChange = ",
							foodChange.ToString(),
							", EconomyTweak_h_FoodStocks = ",
							foodStocks.ToString(),
							", EconomyTweak_h_FoodShortageProsperity = ",
							value2.ToString(),
							", explainedNumber_FoodShortageProsperity = ",
							explainedNumber3.ResultNumber.ToString(),
							", EconomyTweak_h_CalculateProsperityChange(result) = ",
							__result.ToString()
						}));
					}
				}
			}
		}
	}
}
