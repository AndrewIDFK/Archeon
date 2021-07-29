using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Accessories
{
	public class KnightEmblem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Knight Emblem");
			Tooltip.SetDefault("Harness the power of a faceless knight \nImmune to most vanilla debuffs \n20% increased melee damage and 15% increased melee speed \nMelee attacks ignite enemies and increased melee knockback");
		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 16;
			item.value = Item.buyPrice(0, 10, 50, 0);
			item.rare = 8;
			item.accessory = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(1612, 1);
			modRecipe.AddIngredient(1322, 1);
			modRecipe.AddIngredient(490, 1);
			modRecipe.AddIngredient(548, 15);
			modRecipe.AddIngredient(1225, 5);
			modRecipe.AddIngredient(536, 1);
			modRecipe.AddTile(114);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.magmaStone = true;
			player.kbGlove = true;
			player.meleeDamage += 0.2f;
			player.meleeSpeed += 0.15f;
			player.buffImmune[33] = true;
			player.buffImmune[36] = true;
			player.buffImmune[30] = true;
			player.buffImmune[20] = true;
			player.buffImmune[32] = true;
			player.buffImmune[31] = true;
			player.buffImmune[35] = true;
			player.buffImmune[23] = true;
			player.buffImmune[22] = true;
		}
	}
}
