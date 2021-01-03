using System;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace EconomyTweak_h
{
	// Token: 0x02000005 RID: 5
	public class EconomyTweak_h_Dictionaries
	{
		// Token: 0x0600002A RID: 42 RVA: 0x00002810 File Offset: 0x00000A10
		public static void EconomyTweak_h_TownDemandFulfilledAdd(Town town, float demandFulfilled)
		{
			bool flag = EconomyTweak_h_Dictionaries.EconomyTweak_h_TownDemandFulfilledDictionary.ContainsKey(town);
			if (flag)
			{
				Dictionary<Town, float> economyTweak_h_TownDemandFulfilledDictionary = EconomyTweak_h_Dictionaries.EconomyTweak_h_TownDemandFulfilledDictionary;
				economyTweak_h_TownDemandFulfilledDictionary[town] += demandFulfilled;
			}
			else
			{
				EconomyTweak_h_Dictionaries.EconomyTweak_h_TownDemandFulfilledDictionary[town] = demandFulfilled;
			}
		}

		// Token: 0x04000022 RID: 34
		public static Dictionary<ValueTuple<Town, ItemCategory>, float> EconomyTweak_h_TownCategoryWorkshopPriceFactorDictionary = new Dictionary<ValueTuple<Town, ItemCategory>, float>();

		// Token: 0x04000023 RID: 35
		public static Dictionary<ValueTuple<Town, ItemCategory>, float> EconomyTweak_h_TownCategoryProsperityPriceFactorDictionary = new Dictionary<ValueTuple<Town, ItemCategory>, float>();

		// Token: 0x04000024 RID: 36
		public static Dictionary<Town, float> EconomyTweak_h_TownDemandFulfilledDictionary = new Dictionary<Town, float>();
	}
}
