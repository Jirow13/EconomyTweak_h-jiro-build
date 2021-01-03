using System;
using System.Linq;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors;

namespace EconomyTweak_h
{
	// Token: 0x0200000D RID: 13
	[HarmonyPatch(typeof(CaravansCampaignBehavior), "SpawnCaravans")]
	internal class EconomyTweak_h_SpawnCaravans_patch
	{
		// Token: 0x0600003B RID: 59 RVA: 0x00003D58 File Offset: 0x00001F58
		[HarmonyPrefix]
		public static bool EconomyTweak_h_SpawnCaravans(bool initialSpawn = false)
		{
			bool flag = EconomyTweak_h_globalConstants.EconomyTweak_h_AdditionalCaravansPerHero > 0;
			bool result;
			if (flag)
			{
				foreach (Hero hero in Hero.All)
				{
					bool flag2 = hero.PartyBelongedTo == null && hero.IsMerchant && (hero.IsFugitive || hero.IsReleased || hero.IsNotSpawned || hero.IsActive) && !hero.IsTemplate && !hero.IsOccupiedByAnEvent();
					//bool flag3 = hero != Hero.MainHero && flag2 && hero.OwnedCaravans.Count<MobileParty>() <= EconomyTweak_h_globalConstants.EconomyTweak_h_AdditionalCaravansPerHero;
					bool flag3 = hero != Hero.MainHero && flag2 && hero.OwnedCaravans.Count <= EconomyTweak_h_globalConstants.EconomyTweak_h_AdditionalCaravansPerHero;
					if (flag3)
					{
						Settlement settlement = hero.HomeSettlement.IsFortification ? hero.HomeSettlement : hero.HomeSettlement.GetComponent<Village>().TradeBound;
						//MobileParty.InitializeCaravanForHero(hero, settlement, initialSpawn, null, null, 0);
						CaravanPartyComponent.CreateCaravanParty(hero, settlement, initialSpawn, null, null, 0);
						bool flag4 = !initialSpawn && hero.Power >= 50f;
						if (flag4)
						{
							hero.AddPower(-50f);
						}
					}
				}
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}
	}
}
