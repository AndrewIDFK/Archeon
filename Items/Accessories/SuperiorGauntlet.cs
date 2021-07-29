using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Accessories
{
	public class SuperiorGauntlet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Superior Gauntlet");
			Tooltip.SetDefault("You enjoy the fear in your enemies eyes \n6% increased melee critical hit chance, 9% increased melee damage and 10% increased melee speed \nMaximum health increased by 10 and enemies are more likely to target you");
		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 16;
			item.value = Item.buyPrice(0, 6, 0, 0);
			item.rare = 8;
			item.accessory = true;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("ThaniteBar"), 15);
			modRecipe.AddIngredient(1343, 1);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.aggro += 300;
			player.meleeCrit += 6;
			player.meleeDamage += 0.09f;
			player.meleeSpeed += 0.1f;
			player.statLifeMax2 += 10;
		}
	}
}
