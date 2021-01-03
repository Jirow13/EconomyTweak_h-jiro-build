using System;
using System.IO;
using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace EconomyTweak_h
{
	// Token: 0x02000008 RID: 8
	[HarmonyPatch(typeof(DefaultTradeItemPriceFactorModel), "GetBasePriceFactor")]
	internal class EconomyTweak_h_GetBasePriceFactor_patch
	{
		// Token: 0x06000031 RID: 49 RVA: 0x00002F48 File Offset: 0x00001148
		[HarmonyPrefix]
		public static bool EconomyTweak_h_GetBasePriceFactor(ItemCategory itemCategory, float inStoreValue, float supply, float demand, bool isSelling, int transferValue, ref float __result)
		{
			bool flag = isSelling;
			if (flag)
			{
				inStoreValue += (float)transferValue;
			}
			float num = (float)EconomyTweak_h_globalConstants.EconomyTweak_h_OptimalStockPeriodPrice * demand;
			float num2 = MathF.Pow((num + demand + 1f) / (inStoreValue + demand + 1f), EconomyTweak_h_globalConstants.EconomyTweak_h_ShorttermPriceMultiplierExpValue);
			bool flag2 = supply <= 10f;
			if (flag2)
			{
				num2 *= supply;
			}
			bool flag3 = itemCategory == DefaultItemCategories.Unassigned;
			if (flag3)
			{
				num2 = MathF.Clamp(num2, 0.2f, 10f);
			}
			num2 = MathF.Clamp(num2, 0.01f, 100f);
			__result = num2;
			bool flag4 = EconomyTweak_h_globalConstants.EconomyTweak_h_DebugLevel > 2;
			if (flag4)
			{
				using (StreamWriter streamWriter = File.AppendText(EconomyTweak_h_globalConstants.EconomyTweak_h_path + "EconomyTweak_h_log.txt"))
				{
					streamWriter.WriteLine("EconomyTweak_h_GetBasePriceFactor");
				}
				bool economyTweak_h_DebugDisplay = EconomyTweak_h_globalConstants.EconomyTweak_h_DebugDisplay;
				if (economyTweak_h_DebugDisplay)
				{
					InformationManager.DisplayMessage(new InformationMessage("EconomyTweak_h_GetBasePriceFactor"));
				}
				bool flag5 = EconomyTweak_h_globalConstants.EconomyTweak_h_DebugLevel > 3;
				if (flag5)
				{
					using (StreamWriter streamWriter2 = File.AppendText(EconomyTweak_h_globalConstants.EconomyTweak_h_path + "EconomyTweak_h_log.txt"))
					{
						streamWriter2.WriteLine(string.Concat(new string[]
						{
							"itemCategory = ",
							itemCategory.ToString(),
							", inStoreValue = ",
							inStoreValue.ToString(),
							", supply = ",
							supply.ToString(),
							", demand = ",
							demand.ToString(),
							", isSelling = ",
							isSelling.ToString(),
							", transferValue = ",
							transferValue.ToString(),
							", EconomyTweak_h_OptimalStockValue = ",
							num.ToString(),
							", EconomyTweak_h_GetBasePriceFactor(result) = ",
							__result.ToString()
						}));
					}
				}
			}
			return false;
		}
	}
}
