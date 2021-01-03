using System;
using System.Collections.Generic;
using System.IO;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace EconomyTweak_h
{
	// Token: 0x02000006 RID: 6
	[HarmonyPatch(typeof(DefaultSettlementEconomyModel), "GetDailyDemandForCategory")]
	internal class EconomyTweak_h_GetDailyDemandForCategory_patch
	{
		// Token: 0x0600002D RID: 45 RVA: 0x0000287C File Offset: 0x00000A7C
		[HarmonyPrefix]
		public static bool EconomyTweak_h_GetDailyDemandForCategory(Town town, ItemCategory category, int extraProsperity, ref float __result)
		{
			float num = 0f;
			for (int i = 0; i < town.Workshops.Length; i++)
			{
				for (int j = 0; j < town.Workshops[i].WorkshopType.Productions.Count; j++)
				{
					IEnumerable<ValueTuple<ItemCategory, int>> inputs = town.Workshops[i].WorkshopType.Productions[j].Inputs;
					foreach (ValueTuple<ItemCategory, int> valueTuple in inputs)
					{
						bool flag = category == valueTuple.Item1;
						if (flag)
						{
							float averageValue = category.AverageValue;
							num += town.Workshops[i].WorkshopType.Productions[j].ConversionSpeed / averageValue;
						}
					}
				}
			}
			float num2 = Math.Max(1f, town.Prosperity);
			float num3 = Math.Max(1f, num2 - 3000f);
			float num4 = category.BaseDemand * EconomyTweak_h_globalConstants.EconomyTweak_h_DemandMultiplier * num2;
			float num5 = category.LuxuryDemand * EconomyTweak_h_globalConstants.EconomyTweak_h_DemandMultiplier * num3;
			float num6 = num4 + num5;
			bool flag2 = category.BaseDemand < 1E-08f;
			if (flag2)
			{
				num6 = num2 * 0.01f;
			}
			EconomyTweak_h_Dictionaries.EconomyTweak_h_TownCategoryWorkshopPriceFactorDictionary[new ValueTuple<Town, ItemCategory>(town, category)] = MathF.Clamp(1f + num / (category.BaseDemand / 2f + category.LuxuryDemand / 2f + num), 0.5f, 1.5f);
			num6 *= EconomyTweak_h_Dictionaries.EconomyTweak_h_TownCategoryWorkshopPriceFactorDictionary[new ValueTuple<Town, ItemCategory>(town, category)];
			EconomyTweak_h_Dictionaries.EconomyTweak_h_TownCategoryProsperityPriceFactorDictionary[new ValueTuple<Town, ItemCategory>(town, category)] = MathF.Clamp(MathF.Pow(3000f / (town.Prosperity + 1f), EconomyTweak_h_globalConstants.EconomyTweak_h_ProsperityPriceFactorExpValue), 0.5f, 1.5f);
			num6 *= EconomyTweak_h_Dictionaries.EconomyTweak_h_TownCategoryProsperityPriceFactorDictionary[new ValueTuple<Town, ItemCategory>(town, category)];
			float num7 = 0f;
			float num8 = town.FoodStocks + town.FoodChange * (float)EconomyTweak_h_globalConstants.EconomyTweak_h_OptimalStockPeriodFood - town.Prosperity / 50f;
			bool flag3 = num8 < 0f;
			if (flag3)
			{
				bool flag4 = category.Properties == ItemCategory.Property.BonusToFoodStores;
				if (flag4)
				{
					num7 = Math.Min(-num8, num6 * 0.1f);
					num6 += num7;
				}
			}
			bool flag5 = !category.IsTradeGood;
			if (flag5)
			{
				num6 *= EconomyTweak_h_globalConstants.EconomyTweak_h_EquipmentDemandMultiplier;
			}
			__result = num6;
			bool flag6 = EconomyTweak_h_globalConstants.EconomyTweak_h_DebugLevel > 0;
			if (flag6)
			{
				using (StreamWriter streamWriter = File.AppendText(EconomyTweak_h_globalConstants.EconomyTweak_h_path + "EconomyTweak_h_log.txt"))
				{
					streamWriter.WriteLine("EconomyTweak_h_GetDailyDemandForCategory");
				}
				bool economyTweak_h_DebugDisplay = EconomyTweak_h_globalConstants.EconomyTweak_h_DebugDisplay;
				if (economyTweak_h_DebugDisplay)
				{
					InformationManager.DisplayMessage(new InformationMessage("EconomyTweak_h_GetDailyDemandForCategory"));
				}
				bool flag7 = EconomyTweak_h_globalConstants.EconomyTweak_h_DebugLevel > 1;
				if (flag7)
				{
					using (StreamWriter streamWriter2 = File.AppendText(EconomyTweak_h_globalConstants.EconomyTweak_h_path + "EconomyTweak_h_log.txt"))
					{
						streamWriter2.WriteLine(string.Concat(new string[]
						{
							"town = ",
							town.ToString(),
							", category = ",
							category.ToString(),
							", EconomyTweak_h_workShopProduction = ",
							num.ToString(),
							", BaseDemand(num3) = ",
							num4.ToString(),
							", LuxuryDemand(num4) = ",
							num5.ToString(),
							", EconomyTweak_h_TownCategoryWorkshopPriceFactorDictionary = ",
							EconomyTweak_h_Dictionaries.EconomyTweak_h_TownCategoryWorkshopPriceFactorDictionary[new ValueTuple<Town, ItemCategory>(town, category)].ToString(),
							", EconomyTweak_h_TownCategoryProsperityPriceFactorDictionary = ",
							EconomyTweak_h_Dictionaries.EconomyTweak_h_TownCategoryProsperityPriceFactorDictionary[new ValueTuple<Town, ItemCategory>(town, category)].ToString(),
							", EconomyTweak_h_foodShortageDemand = ",
							num7.ToString(),
							", category.IsTradeGood = ",
							category.IsTradeGood.ToString(),
							", EconomyTweak_h_GetDailyDemandForCategory(result) = ",
							__result.ToString()
						}));
					}
				}
			}
			return false;
		}
	}
}
