using System;
using System.IO;
using System.Xml.Serialization;

namespace EconomyTweak_h
{
	// Token: 0x02000004 RID: 4
	public class EconomyTweak_h_Configuration
	{
		// Token: 0x06000007 RID: 7 RVA: 0x0000257F File Offset: 0x0000077F
		public EconomyTweak_h_Configuration()
		{
			EconomyTweak_h_Configuration._EconomyTweak_h_DebugLevel = 0;
			EconomyTweak_h_Configuration._EconomyTweak_h_DebugDisplay = true;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002598 File Offset: 0x00000798
		public static void Serialize(string file, EconomyTweak_h_Configuration EconomyTweak_h_config)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(EconomyTweak_h_config.GetType());
			StreamWriter streamWriter = File.CreateText(file);
			xmlSerializer.Serialize(streamWriter, EconomyTweak_h_config);
			streamWriter.Flush();
			streamWriter.Close();
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000025D0 File Offset: 0x000007D0
		public static EconomyTweak_h_Configuration Deserialize(string file)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(EconomyTweak_h_Configuration));
			StreamReader streamReader = File.OpenText(file);
			EconomyTweak_h_Configuration result = (EconomyTweak_h_Configuration)xmlSerializer.Deserialize(streamReader);
			streamReader.Close();
			return result;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000A RID: 10 RVA: 0x00002610 File Offset: 0x00000810
		// (set) Token: 0x0600000B RID: 11 RVA: 0x00002627 File Offset: 0x00000827
		public int EconomyTweak_h_OptimalStockPeriodPrice
		{
			get
			{
				return EconomyTweak_h_Configuration._EconomyTweak_h_OptimalStockPeriodPrice;
			}
			set
			{
				EconomyTweak_h_Configuration._EconomyTweak_h_OptimalStockPeriodPrice = value;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000C RID: 12 RVA: 0x00002630 File Offset: 0x00000830
		// (set) Token: 0x0600000D RID: 13 RVA: 0x00002647 File Offset: 0x00000847
		public float EconomyTweak_h_LongtermPriceMultiplierExpValue
		{
			get
			{
				return EconomyTweak_h_Configuration._EconomyTweak_h_LongtermPriceMultiplierExpValue;
			}
			set
			{
				EconomyTweak_h_Configuration._EconomyTweak_h_LongtermPriceMultiplierExpValue = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000E RID: 14 RVA: 0x00002650 File Offset: 0x00000850
		// (set) Token: 0x0600000F RID: 15 RVA: 0x00002667 File Offset: 0x00000867
		public float EconomyTweak_h_ShorttermPriceMultiplierExpValue
		{
			get
			{
				return EconomyTweak_h_Configuration._EconomyTweak_h_ShorttermPriceMultiplierExpValue;
			}
			set
			{
				EconomyTweak_h_Configuration._EconomyTweak_h_ShorttermPriceMultiplierExpValue = value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000010 RID: 16 RVA: 0x00002670 File Offset: 0x00000870
		// (set) Token: 0x06000011 RID: 17 RVA: 0x00002687 File Offset: 0x00000887
		public float EconomyTweak_h_ProsperityPriceFactorExpValue
		{
			get
			{
				return EconomyTweak_h_Configuration._EconomyTweak_h_ProsperityPriceFactorExpValue;
			}
			set
			{
				EconomyTweak_h_Configuration._EconomyTweak_h_ProsperityPriceFactorExpValue = value;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000012 RID: 18 RVA: 0x00002690 File Offset: 0x00000890
		// (set) Token: 0x06000013 RID: 19 RVA: 0x000026A7 File Offset: 0x000008A7
		public int EconomyTweak_h_OptimalStockPeriodOverconsumption
		{
			get
			{
				return EconomyTweak_h_Configuration._EconomyTweak_h_OptimalStockPeriodOverconsumption;
			}
			set
			{
				EconomyTweak_h_Configuration._EconomyTweak_h_OptimalStockPeriodOverconsumption = value;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000014 RID: 20 RVA: 0x000026B0 File Offset: 0x000008B0
		// (set) Token: 0x06000015 RID: 21 RVA: 0x000026C7 File Offset: 0x000008C7
		public float EconomyTweak_h_DemandMultiplier
		{
			get
			{
				return EconomyTweak_h_Configuration._EconomyTweak_h_DemandMultiplier;
			}
			set
			{
				EconomyTweak_h_Configuration._EconomyTweak_h_DemandMultiplier = value;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000016 RID: 22 RVA: 0x000026D0 File Offset: 0x000008D0
		// (set) Token: 0x06000017 RID: 23 RVA: 0x000026E7 File Offset: 0x000008E7
		public float EconomyTweak_h_EquipmentDemandMultiplier
		{
			get
			{
				return EconomyTweak_h_Configuration._EconomyTweak_h_EquipmentDemandMultiplier;
			}
			set
			{
				EconomyTweak_h_Configuration._EconomyTweak_h_EquipmentDemandMultiplier = value;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000018 RID: 24 RVA: 0x000026F0 File Offset: 0x000008F0
		// (set) Token: 0x06000019 RID: 25 RVA: 0x00002707 File Offset: 0x00000907
		public float EconomyTweak_h_ProductionMultiplier
		{
			get
			{
				return EconomyTweak_h_Configuration._EconomyTweak_h_ProductionMultiplier;
			}
			set
			{
				EconomyTweak_h_Configuration._EconomyTweak_h_ProductionMultiplier = value;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600001A RID: 26 RVA: 0x00002710 File Offset: 0x00000910
		// (set) Token: 0x0600001B RID: 27 RVA: 0x00002727 File Offset: 0x00000927
		public int EconomyTweak_h_OptimalStockPeriodFood
		{
			get
			{
				return EconomyTweak_h_Configuration._EconomyTweak_h_OptimalStockPeriodFood;
			}
			set
			{
				EconomyTweak_h_Configuration._EconomyTweak_h_OptimalStockPeriodFood = value;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600001C RID: 28 RVA: 0x00002730 File Offset: 0x00000930
		// (set) Token: 0x0600001D RID: 29 RVA: 0x00002747 File Offset: 0x00000947
		public float EconomyTweak_h_FoodShortageProsperityExpValue
		{
			get
			{
				return EconomyTweak_h_Configuration._EconomyTweak_h_FoodShortageProsperityExpValue;
			}
			set
			{
				EconomyTweak_h_Configuration._EconomyTweak_h_FoodShortageProsperityExpValue = value;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600001E RID: 30 RVA: 0x00002750 File Offset: 0x00000950
		// (set) Token: 0x0600001F RID: 31 RVA: 0x00002767 File Offset: 0x00000967
		public float EconomyTweak_h_TownDemandFulfilledProsperityExpValue
		{
			get
			{
				return EconomyTweak_h_Configuration._EconomyTweak_h_TownDemandFulfilledProsperityExpValue;
			}
			set
			{
				EconomyTweak_h_Configuration._EconomyTweak_h_TownDemandFulfilledProsperityExpValue = value;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000020 RID: 32 RVA: 0x00002770 File Offset: 0x00000970
		// (set) Token: 0x06000021 RID: 33 RVA: 0x00002787 File Offset: 0x00000987
		public float EconomyTweak_h_ValueOfProsperity
		{
			get
			{
				return EconomyTweak_h_Configuration._EconomyTweak_h_ValueOfProsperity;
			}
			set
			{
				EconomyTweak_h_Configuration._EconomyTweak_h_ValueOfProsperity = value;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000022 RID: 34 RVA: 0x00002790 File Offset: 0x00000990
		// (set) Token: 0x06000023 RID: 35 RVA: 0x000027A7 File Offset: 0x000009A7
		public float EconomyTweak_h_MarketGoldProsperityRatio
		{
			get
			{
				return EconomyTweak_h_Configuration._EconomyTweak_h_MarketGoldProsperityRatio;
			}
			set
			{
				EconomyTweak_h_Configuration._EconomyTweak_h_MarketGoldProsperityRatio = value;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000024 RID: 36 RVA: 0x000027B0 File Offset: 0x000009B0
		// (set) Token: 0x06000025 RID: 37 RVA: 0x000027C7 File Offset: 0x000009C7
		public int EconomyTweak_h_AdditionalCaravansPerHero
		{
			get
			{
				return EconomyTweak_h_Configuration._EconomyTweak_h_AdditionalCaravansPerHero;
			}
			set
			{
				EconomyTweak_h_Configuration._EconomyTweak_h_AdditionalCaravansPerHero = value;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000026 RID: 38 RVA: 0x000027D0 File Offset: 0x000009D0
		// (set) Token: 0x06000027 RID: 39 RVA: 0x000027E7 File Offset: 0x000009E7
		public int EconomyTweak_h_DebugLevel
		{
			get
			{
				return EconomyTweak_h_Configuration._EconomyTweak_h_DebugLevel;
			}
			set
			{
				EconomyTweak_h_Configuration._EconomyTweak_h_DebugLevel = value;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000028 RID: 40 RVA: 0x000027F0 File Offset: 0x000009F0
		// (set) Token: 0x06000029 RID: 41 RVA: 0x00002807 File Offset: 0x00000A07
		public bool EconomyTweak_h_DebugDisplay
		{
			get
			{
				return EconomyTweak_h_Configuration._EconomyTweak_h_DebugDisplay;
			}
			set
			{
				EconomyTweak_h_Configuration._EconomyTweak_h_DebugDisplay = value;
			}
		}

		// Token: 0x04000012 RID: 18
		public static int _EconomyTweak_h_OptimalStockPeriodPrice;

		// Token: 0x04000013 RID: 19
		public static float _EconomyTweak_h_LongtermPriceMultiplierExpValue;

		// Token: 0x04000014 RID: 20
		public static float _EconomyTweak_h_ShorttermPriceMultiplierExpValue;

		// Token: 0x04000015 RID: 21
		public static float _EconomyTweak_h_ProsperityPriceFactorExpValue;

		// Token: 0x04000016 RID: 22
		public static int _EconomyTweak_h_OptimalStockPeriodOverconsumption;

		// Token: 0x04000017 RID: 23
		public static float _EconomyTweak_h_DemandMultiplier;

		// Token: 0x04000018 RID: 24
		public static float _EconomyTweak_h_EquipmentDemandMultiplier;

		// Token: 0x04000019 RID: 25
		public static float _EconomyTweak_h_ProductionMultiplier;

		// Token: 0x0400001A RID: 26
		public static int _EconomyTweak_h_OptimalStockPeriodFood;

		// Token: 0x0400001B RID: 27
		public static float _EconomyTweak_h_FoodShortageProsperityExpValue;

		// Token: 0x0400001C RID: 28
		public static float _EconomyTweak_h_TownDemandFulfilledProsperityExpValue;

		// Token: 0x0400001D RID: 29
		public static float _EconomyTweak_h_ValueOfProsperity;

		// Token: 0x0400001E RID: 30
		public static float _EconomyTweak_h_MarketGoldProsperityRatio;

		// Token: 0x0400001F RID: 31
		public static int _EconomyTweak_h_AdditionalCaravansPerHero;

		// Token: 0x04000020 RID: 32
		public static int _EconomyTweak_h_DebugLevel;

		// Token: 0x04000021 RID: 33
		public static bool _EconomyTweak_h_DebugDisplay;
	}
}
