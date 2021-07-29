using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Armor.Feral
{
	[AutoloadEquip(EquipType.Head)]
	public class FeralMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Feral Mask");
			Tooltip.SetDefault("Increases minion damage by 15% and your max amount of minions by 1");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 2, 80, 0);
			item.rare = 7;
			item.defense = 8;
		}

		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.15f;
			player.maxMinions++;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("FeralChestplate") && legs.type == mod.ItemType("FeralGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases minion damage by 20% and your max amount of minions by 1\nMinions inflict Poison and Venom \nSummons 2 minions to protect you";
			
			player.GetModPlayer<MyPlayer>().feralArmorDebuffs = true;
			player.GetModPlayer<MyPlayer>().feralSlimes = true;
			
			if (player.whoAmI == Main.myPlayer)
			{
				if (player.FindBuffIndex(mod.BuffType("FeralArmorMinions")) == -1)
				{
					player.AddBuff(mod.BuffType("FeralArmorMinions"), 1, true);
				}	
				
				if (player.ownedProjectileCounts[mod.ProjectileType("FeralArmorMinion1")] < 1 && player.ownedProjectileCounts[mod.ProjectileType("FeralArmorMinion2")] < 1)
				{
					Projectile.NewProjectile(player.Center.X + 20, player.Center.Y - 15, 0f, -1f, mod.ProjectileType("FeralArmorMinion1"), 0, 0f, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(player.Center.X - 20, player.Center.Y - 15, 0f, -1f, mod.ProjectileType("FeralArmorMinion2"), 0, 0f, Main.myPlayer, 0f, 0f);
				}
			}
			
			player.minionDamage += 0.2f;
			player.maxMinions++;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("FeralShard"), 10);
			modRecipe.AddIngredient(1006, 14); //Chloro Bar
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
		
		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowSubtle = true;
			player.armorEffectDrawShadowLokis = true;
			player.armorEffectDrawShadowEOCShield = true;
		}
	}
}
