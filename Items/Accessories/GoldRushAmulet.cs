using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Accessories
{
	public class GoldRushAmulet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gold Rush Amulet");
			Tooltip.SetDefault("Increases mining speed by 30%");
		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 16;
			item.value = Item.buyPrice(0, 1, 40, 0);
			item.rare = 5;
			item.accessory = true;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(19, 25);
			modRecipe.AddIngredient(3491, 1);
			modRecipe.AddIngredient(85, 5);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(706, 25);
			modRecipe.AddIngredient(3491, 1);
			modRecipe.AddIngredient(85, 5);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(19, 25);
			modRecipe.AddIngredient(3515, 1);
			modRecipe.AddIngredient(85, 5);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(706, 25);
			modRecipe.AddIngredient(3515, 1);
			modRecipe.AddIngredient(85, 5);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.pickSpeed -= 0.3f;
		}
	}
}
