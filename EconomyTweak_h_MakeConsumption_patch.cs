using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors;
using TaleWorlds.Core;

namespace EconomyTweak_h
{
	// Token: 0x02000009 RID: 9
	[HarmonyPatch(typeof(ItemConsumptionBehavior), "MakeConsumption")]
	internal class EconomyTweak_h_MakeConsumption_patch
	{
		// Token: 0x06000033 RID: 51 RVA: 0x00003144 File Offset: 0x00001344
		[HarmonyPrefix]
		public static bool EconomyTweak_h_MakeConsumption(Town town, Dictionary<ItemCategory, float> categoryDemand, Dictionary<ItemCategory, int> saleLog)
		{
			bool flag = EconomyTweak_h_globalConstants.EconomyTweak_h_DebugLevel > 0;
			if (flag)
			{
				using (StreamWriter streamWriter = File.AppendText(EconomyTweak_h_globalConstants.EconomyTweak_h_path + "EconomyTweak_h_log.txt"))
				{
					streamWriter.WriteLine("EconomyTweak_h_MakeConsumption");
				}
				bool economyTweak_h_DebugDisplay = EconomyTweak_h_globalConstants.EconomyTweak_h_DebugDisplay;
				if (economyTweak_h_DebugDisplay)
				{
					InformationManager.DisplayMessage(new InformationMessage("EconomyTweak_h_MakeConsumption"));
				}
			}
			EconomyTweak_h_Dictionaries.EconomyTweak_h_TownDemandFulfilledDictionary[town] = 0f;
			saleLog.Clear();
			TownMarketData marketData = town.MarketData;
			ItemRoster itemRoster = town.Owner.ItemRoster;
			List<int> list = Enumerable.Range(0, itemRoster.Count - 1).ToList<int>();
			list.Shuffle<int>();
			foreach (int num in list)
			{
				ItemObject itemAtIndex = itemRoster.GetItemAtIndex(num);
				if (itemAtIndex is not null)
				{
					int elementNumber = itemRoster.GetElementNumber(num);
					ItemCategory itemCategory = itemAtIndex.GetItemCategory();
					float num2 = categoryDemand[itemCategory];
					bool flag2 = EconomyTweak_h_Dictionaries.EconomyTweak_h_TownCategoryWorkshopPriceFactorDictionary.ContainsKey(new ValueTuple<Town, ItemCategory>(town, itemCategory));
					if (flag2)
					{
						num2 /= EconomyTweak_h_Dictionaries.EconomyTweak_h_TownCategoryWorkshopPriceFactorDictionary[new ValueTuple<Town, ItemCategory>(town, itemCategory)];
					}
					bool flag3 = EconomyTweak_h_Dictionaries.EconomyTweak_h_TownCategoryProsperityPriceFactorDictionary.ContainsKey(new ValueTuple<Town, ItemCategory>(town, itemCategory));
					if (flag3)
					{
						num2 /= EconomyTweak_h_Dictionaries.EconomyTweak_h_TownCategoryProsperityPriceFactorDictionary[new ValueTuple<Town, ItemCategory>(town, itemCategory)];
					}
					float num3 = (float)EconomyTweak_h_globalConstants.EconomyTweak_h_OptimalStockPeriodOverconsumption * num2 / (float)itemAtIndex.Value;
					float num4 = num2;
					bool flag4 = (float)elementNumber > num3;
					if (flag4)
					{
						num4 = (float)MBRandom.RoundRandomized(num4 * (float)elementNumber / num3);
					}
					bool flag5 = num4 > 0.01f;
					if (flag5)
					{
						int price = marketData.GetPrice(itemAtIndex, null, false, null);
						int num5 = MBRandom.RoundRandomized(num4 / (float)itemAtIndex.Value);
						int num6 = num5;
						bool flag6 = num5 > elementNumber;
						if (flag6)
						{
							num6 = elementNumber;
						}
						bool flag7 = num6 > elementNumber;
						if (flag7)
						{
							num6 = elementNumber;
						}
						//itemRoster.AddToCountsAtIndex(num, -num6);
						itemRoster.AddToCounts(itemAtIndex, -num6);
						town.ChangeGold(num6 * price);
						int num7 = 0;
						saleLog.TryGetValue(itemCategory, out num7);
						saleLog[itemCategory] = num7 + num6;
						bool isTradeGood = itemCategory.IsTradeGood;
						if (isTradeGood)
						{
							EconomyTweak_h_Dictionaries.EconomyTweak_h_TownDemandFulfilledAdd(town, (float)(num6 * itemAtIndex.Value) / EconomyTweak_h_globalConstants.EconomyTweak_h_ValueOfProsperity);
						}
						categoryDemand[itemCategory] = (float)((num5 - num6) * itemAtIndex.Value);
						bool flag8 = EconomyTweak_h_globalConstants.EconomyTweak_h_DebugLevel > 1;
						if (flag8)
						{
							using (StreamWriter streamWriter2 = File.AppendText(EconomyTweak_h_globalConstants.EconomyTweak_h_path + "EconomyTweak_h_log.txt"))
							{
								streamWriter2.WriteLine(string.Concat(new string[]
								{
									"EconomyTweak_h_MakeConsumption itemRoster.Count, i = ",
									num.ToString(),
									": , town = ",
									town.ToString(),
									", itemAtIndex.Name = ",
									itemAtIndex.Name.ToString(),
									", itemAtIndex.Value = ",
									itemAtIndex.Value.ToString(),
									", elementNumber = ",
									elementNumber.ToString(),
									", itemCategory = ",
									itemCategory.ToString(),
									", DemandValue(num) = ",
									num4.ToString(),
									", DemandCount(num2) = ",
									num5.ToString(),
									", DemandCountAvail(num3) = ",
									num6.ToString(),
									", SoldBefore(num4) = ",
									num7.ToString(),
									", categoryDemand[itemCategory] = ",
									categoryDemand[itemCategory].ToString()
								}));
							}
						}
					}
				}
			}
			foreach (ItemObject item in ItemObject.All)
			{
				ItemCategory itemCategory2 = item.GetItemCategory();
				bool flag9 = categoryDemand[itemCategory2] > 0f;
				if (flag9)
				{
					bool isTradeGood2 = itemCategory2.IsTradeGood;
					if (isTradeGood2)
					{
						EconomyTweak_h_Dictionaries.EconomyTweak_h_TownDemandFulfilledAdd(town, -categoryDemand[itemCategory2] / EconomyTweak_h_globalConstants.EconomyTweak_h_ValueOfProsperity);
						categoryDemand[itemCategory2] = 0f;
					}
				}
			}
			//itemRoster.RemoveZeroCounts();
			typeof(ItemRoster).GetMethod("RemoveZeroCounts", BindingFlags.NonPublic | BindingFlags.Static).Invoke(null, null);
			List<Town.SellLog> list2 = new List<Town.SellLog>();
			foreach (KeyValuePair<ItemCategory, int> keyValuePair in saleLog)
			{
				bool flag10 = keyValuePair.Value > 0;
				if (flag10)
				{
					list2.Add(new Town.SellLog(keyValuePair.Key, keyValuePair.Value));
				}
			}
			Town.SellLog[] value = new Town.SellLog[0];
			value = list2.ToArray<Town.SellLog>();
			FieldInfo field = typeof(Town).GetField("_soldItems", BindingFlags.Instance | BindingFlags.NonPublic);
			field.SetValue(town, value);
			bool flag11 = EconomyTweak_h_globalConstants.EconomyTweak_h_DebugLevel > 1;
			if (flag11)
			{
				foreach (Town.SellLog sellLog in town.SoldItems)
				{
					using (StreamWriter streamWriter3 = File.AppendText(EconomyTweak_h_globalConstants.EconomyTweak_h_path + "EconomyTweak_h_log.txt"))
					{
						streamWriter3.WriteLine(string.Concat(new string[]
						{
							"EconomyTweak_h_MakeConsumption town.SoldItems: town = ",
							town.ToString(),
							", sellLog.Category = ",
							sellLog.Category.ToString(),
							", sellLog.Number = ",
							sellLog.Number.ToString()
						}));
					}
				}
			}
			return false;
		}
	}
}
