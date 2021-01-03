using System;
using System.IO;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace EconomyTweak_h
{
	// Token: 0x02000003 RID: 3
	public class EconomyTweak_h_globalConstants
	{
		// Token: 0x06000004 RID: 4 RVA: 0x00002098 File Offset: 0x00000298
		public static void EconomyTweak_h_globalConstants_read()
		{
			EconomyTweak_h_Configuration economyTweak_h_Configuration = new EconomyTweak_h_Configuration();
			economyTweak_h_Configuration.EconomyTweak_h_OptimalStockPeriodPrice = 30;
			economyTweak_h_Configuration.EconomyTweak_h_LongtermPriceMultiplierExpValue = 0.1f;
			economyTweak_h_Configuration.EconomyTweak_h_ShorttermPriceMultiplierExpValue = 0.5f;
			economyTweak_h_Configuration.EconomyTweak_h_ProsperityPriceFactorExpValue = 0.2f;
			economyTweak_h_Configuration.EconomyTweak_h_OptimalStockPeriodOverconsumption = 15;
			economyTweak_h_Configuration.EconomyTweak_h_DemandMultiplier = 0.5f;
			economyTweak_h_Configuration.EconomyTweak_h_EquipmentDemandMultiplier = 4f;
			economyTweak_h_Configuration.EconomyTweak_h_ProductionMultiplier = 1.5f;
			economyTweak_h_Configuration.EconomyTweak_h_OptimalStockPeriodFood = 15;
			economyTweak_h_Configuration.EconomyTweak_h_FoodShortageProsperityExpValue = 0.5f;
			economyTweak_h_Configuration.EconomyTweak_h_TownDemandFulfilledProsperityExpValue = 0.5f;
			economyTweak_h_Configuration.EconomyTweak_h_ValueOfProsperity = 100f;
			economyTweak_h_Configuration.EconomyTweak_h_MarketGoldProsperityRatio = 0.1f;
			economyTweak_h_Configuration.EconomyTweak_h_AdditionalCaravansPerHero = 1;
			economyTweak_h_Configuration.EconomyTweak_h_DebugLevel = 0;
			economyTweak_h_Configuration.EconomyTweak_h_DebugDisplay = true;
			EconomyTweak_h_Configuration.Serialize(EconomyTweak_h_globalConstants.EconomyTweak_h_path + "config_default.xml", economyTweak_h_Configuration);
			using (StreamWriter streamWriter = File.AppendText(EconomyTweak_h_globalConstants.EconomyTweak_h_path + "config_default.xml"))
			{
				streamWriter.WriteLine("\r\n<!-- Description of constants:\r\nEconomyTweak_h_OptimalStockPeriodPrice - Period in days used to calculate prices: towns will have prices below item value if the current stock is more than enough to fulfill demands for that period, above item value if not enough;\r\nEconomyTweak_h_LongtermPriceMultiplierExpValue - Long-term price multiplier will be exponentiated by MathF.Pow with that value;\r\nEconomyTweak_h_ShorttermPriceMultiplierExpValue - Short-term price multiplier will be exponentiated by MathF.Pow with that value;\r\nEconomyTweak_h_ProsperityPriceFactorExpValue - Prices in towns with < 3000 prosperity are slightly increased, with > 3000 prosperity slightly decreased, multiplier will be exponentiated by MathF.Pow with that value;\r\nEconomyTweak_h_OptimalStockPeriodOverconsumption - Period in days used to calculate overconsumption: towns will faster consume stocks above amount needed for that period;\r\nEconomyTweak_h_DemandMultiplier - Demand is multiplied by this value;\r\nEconomyTweak_h_EquipmentDemandMultiplier - Equipment demand is additionally multiplied by this value;\r\nEconomyTweak_h_ProductionMultiplier - Production is multiplied by that value;\r\nEconomyTweak_h_OptimalStockPeriodFood - Towns will be more wary of food shortages when they have not enough food for that period;\r\nEconomyTweak_h_FoodShortageProsperityExpValue - Prosperity change due to food shortage will be exponentiated by MathF.Pow with that value;\r\nEconomyTweak_h_TownDemandFulfilledProsperityExpValue - Prosperity change due to demands fulfilled will be exponentiated by MathF.Pow with that value;\r\nEconomyTweak_h_ValueOfProsperity - 1 prosperity = 1 gold * EconomyTweak_h_ValueOfProsperity;\r\nEconomyTweak_h_MarketGoldProsperityRatio - Towns aspire to have Prospetity / ValueOfProsperity * MarketGoldProsperityRatio gold at market;\r\nEconomyTweak_h_AdditionalCaravansPerHero - Defines a number of additional NPC caravans per NPC hero;\r\nEconomyTweak_h_DebugLevel - Defines debug level: how much will be written to 'EconomyTweak_h_log.txt';\r\nEconomyTweak_h_DebugDisplay - Defines debug level: when true, info about methods to run will be displayed in game.\r\nDefault values in 'config_default.xml' file. -->");
			}
			bool flag = File.Exists(EconomyTweak_h_globalConstants.EconomyTweak_h_path + "config.xml");
			EconomyTweak_h_Configuration economyTweak_h_Configuration2;
			if (flag)
			{
				using (StreamWriter streamWriter2 = File.CreateText(EconomyTweak_h_globalConstants.EconomyTweak_h_path + "EconomyTweak_h_log.txt"))
				{
					streamWriter2.WriteLine("Settings are loaded from the file '" + EconomyTweak_h_globalConstants.EconomyTweak_h_path + "config.xml'");
				}
				economyTweak_h_Configuration2 = EconomyTweak_h_Configuration.Deserialize(EconomyTweak_h_globalConstants.EconomyTweak_h_path + "config.xml");
			}
			else
			{
				using (StreamWriter streamWriter3 = File.CreateText(EconomyTweak_h_globalConstants.EconomyTweak_h_path + "EconomyTweak_h_log.txt"))
				{
					streamWriter3.WriteLine(string.Concat(new string[]
					{
						"File '",
						EconomyTweak_h_globalConstants.EconomyTweak_h_path,
						"config.xml' does not exist. Using the default settings from '",
						EconomyTweak_h_globalConstants.EconomyTweak_h_path,
						"config_default.xml'."
					}));
				}
				economyTweak_h_Configuration2 = EconomyTweak_h_Configuration.Deserialize(EconomyTweak_h_globalConstants.EconomyTweak_h_path + "config_default.xml");
			}
			EconomyTweak_h_globalConstants.EconomyTweak_h_OptimalStockPeriodPrice = economyTweak_h_Configuration2.EconomyTweak_h_OptimalStockPeriodPrice;
			EconomyTweak_h_globalConstants.EconomyTweak_h_LongtermPriceMultiplierExpValue = economyTweak_h_Configuration2.EconomyTweak_h_LongtermPriceMultiplierExpValue;
			EconomyTweak_h_globalConstants.EconomyTweak_h_ShorttermPriceMultiplierExpValue = economyTweak_h_Configuration2.EconomyTweak_h_ShorttermPriceMultiplierExpValue;
			EconomyTweak_h_globalConstants.EconomyTweak_h_ProsperityPriceFactorExpValue = economyTweak_h_Configuration2.EconomyTweak_h_ProsperityPriceFactorExpValue;
			EconomyTweak_h_globalConstants.EconomyTweak_h_OptimalStockPeriodOverconsumption = economyTweak_h_Configuration2.EconomyTweak_h_OptimalStockPeriodOverconsumption;
			EconomyTweak_h_globalConstants.EconomyTweak_h_DemandMultiplier = economyTweak_h_Configuration2.EconomyTweak_h_DemandMultiplier;
			EconomyTweak_h_globalConstants.EconomyTweak_h_EquipmentDemandMultiplier = economyTweak_h_Configuration2.EconomyTweak_h_EquipmentDemandMultiplier;
			EconomyTweak_h_globalConstants.EconomyTweak_h_ProductionMultiplier = economyTweak_h_Configuration2.EconomyTweak_h_ProductionMultiplier;
			EconomyTweak_h_globalConstants.EconomyTweak_h_OptimalStockPeriodFood = economyTweak_h_Configuration2.EconomyTweak_h_OptimalStockPeriodFood;
			EconomyTweak_h_globalConstants.EconomyTweak_h_FoodShortageProsperityExpValue = economyTweak_h_Configuration2.EconomyTweak_h_FoodShortageProsperityExpValue;
			EconomyTweak_h_globalConstants.EconomyTweak_h_TownDemandFulfilledProsperityExpValue = economyTweak_h_Configuration2.EconomyTweak_h_TownDemandFulfilledProsperityExpValue;
			EconomyTweak_h_globalConstants.EconomyTweak_h_ValueOfProsperity = economyTweak_h_Configuration2.EconomyTweak_h_ValueOfProsperity;
			EconomyTweak_h_globalConstants.EconomyTweak_h_MarketGoldProsperityRatio = economyTweak_h_Configuration2.EconomyTweak_h_MarketGoldProsperityRatio;
			EconomyTweak_h_globalConstants.EconomyTweak_h_AdditionalCaravansPerHero = economyTweak_h_Configuration2.EconomyTweak_h_AdditionalCaravansPerHero;
			EconomyTweak_h_globalConstants.EconomyTweak_h_DebugLevel = economyTweak_h_Configuration2.EconomyTweak_h_DebugLevel;
			EconomyTweak_h_globalConstants.EconomyTweak_h_DebugDisplay = economyTweak_h_Configuration2.EconomyTweak_h_DebugDisplay;
			bool economyTweak_h_DebugDisplay = EconomyTweak_h_globalConstants.EconomyTweak_h_DebugDisplay;
			if (economyTweak_h_DebugDisplay)
			{
				InformationManager.DisplayMessage(new InformationMessage("EconomyTweak_h_globalConstants_read"));
			}
			using (StreamWriter streamWriter4 = File.AppendText(EconomyTweak_h_globalConstants.EconomyTweak_h_path + "EconomyTweak_h_log.txt"))
			{
				streamWriter4.WriteLine(string.Concat(new string[]
				{
					"EconomyTweak settings loaded:\r\nEconomyTweak_h_OptimalStockPeriodPrice = ",
					EconomyTweak_h_globalConstants.EconomyTweak_h_OptimalStockPeriodPrice.ToString(),
					", EconomyTweak_h_LongtermPriceMultiplierExpValue = ",
					EconomyTweak_h_globalConstants.EconomyTweak_h_LongtermPriceMultiplierExpValue.ToString(),
					", EconomyTweak_h_ShorttermPriceMultiplierExpValue = ",
					EconomyTweak_h_globalConstants.EconomyTweak_h_ShorttermPriceMultiplierExpValue.ToString(),
					", EconomyTweak_h_ProsperityPriceFactorExpValue = ",
					EconomyTweak_h_globalConstants.EconomyTweak_h_ProsperityPriceFactorExpValue.ToString(),
					", EconomyTweak_h_OptimalStockPeriodOverconsumption = ",
					EconomyTweak_h_globalConstants.EconomyTweak_h_OptimalStockPeriodOverconsumption.ToString(),
					", EconomyTweak_h_DemandMultiplier = ",
					EconomyTweak_h_globalConstants.EconomyTweak_h_DemandMultiplier.ToString(),
					", EconomyTweak_h_EquipmentDemandMultiplier = ",
					EconomyTweak_h_globalConstants.EconomyTweak_h_EquipmentDemandMultiplier.ToString(),
					", EconomyTweak_h_ProductionMultiplier = ",
					EconomyTweak_h_globalConstants.EconomyTweak_h_ProductionMultiplier.ToString(),
					", EconomyTweak_h_OptimalStockPeriodFood = ",
					EconomyTweak_h_globalConstants.EconomyTweak_h_OptimalStockPeriodFood.ToString(),
					", EconomyTweak_h_FoodShortageProsperityExpValue = ",
					EconomyTweak_h_globalConstants.EconomyTweak_h_FoodShortageProsperityExpValue.ToString(),
					", EconomyTweak_h_TownDemandFulfilledProsperityExpValue = ",
					EconomyTweak_h_globalConstants.EconomyTweak_h_TownDemandFulfilledProsperityExpValue.ToString(),
					", EconomyTweak_h_ValueOfProsperity = ",
					EconomyTweak_h_globalConstants.EconomyTweak_h_ValueOfProsperity.ToString(),
					", EconomyTweak_h_MarketGoldProsperityRatio = ",
					EconomyTweak_h_globalConstants.EconomyTweak_h_MarketGoldProsperityRatio.ToString(),
					", EconomyTweak_h_AdditionalCaravansPerHero = ",
					EconomyTweak_h_globalConstants.EconomyTweak_h_AdditionalCaravansPerHero.ToString(),
					", EconomyTweak_h_DebugLevel = ",
					EconomyTweak_h_globalConstants.EconomyTweak_h_DebugLevel.ToString(),
					", EconomyTweak_h_DebugDisplay = ",
					EconomyTweak_h_globalConstants.EconomyTweak_h_DebugDisplay.ToString()
				}));
			}
		}

		// Token: 0x04000001 RID: 1
		public static int EconomyTweak_h_OptimalStockPeriodPrice;

		// Token: 0x04000002 RID: 2
		public static float EconomyTweak_h_LongtermPriceMultiplierExpValue;

		// Token: 0x04000003 RID: 3
		public static float EconomyTweak_h_ShorttermPriceMultiplierExpValue;

		// Token: 0x04000004 RID: 4
		public static float EconomyTweak_h_ProsperityPriceFactorExpValue;

		// Token: 0x04000005 RID: 5
		public static int EconomyTweak_h_OptimalStockPeriodOverconsumption;

		// Token: 0x04000006 RID: 6
		public static float EconomyTweak_h_DemandMultiplier;

		// Token: 0x04000007 RID: 7
		public static float EconomyTweak_h_EquipmentDemandMultiplier;

		// Token: 0x04000008 RID: 8
		public static float EconomyTweak_h_ProductionMultiplier;

		// Token: 0x04000009 RID: 9
		public static int EconomyTweak_h_OptimalStockPeriodFood;

		// Token: 0x0400000A RID: 10
		public static float EconomyTweak_h_FoodShortageProsperityExpValue;

		// Token: 0x0400000B RID: 11
		public static float EconomyTweak_h_TownDemandFulfilledProsperityExpValue;

		// Token: 0x0400000C RID: 12
		public static float EconomyTweak_h_ValueOfProsperity;

		// Token: 0x0400000D RID: 13
		public static float EconomyTweak_h_MarketGoldProsperityRatio;

		// Token: 0x0400000E RID: 14
		public static int EconomyTweak_h_AdditionalCaravansPerHero;

		// Token: 0x0400000F RID: 15
		public static int EconomyTweak_h_DebugLevel;

		// Token: 0x04000010 RID: 16
		public static bool EconomyTweak_h_DebugDisplay;

		// Token: 0x04000011 RID: 17
		public static string EconomyTweak_h_path = BasePath.Name + "Modules/EconomyTweak_h/";
	}
}
