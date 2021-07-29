using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Accessories
{
	public class SupremeManiaBuilder : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Builder's Maniacal Contraption");
			Tooltip.SetDefault("A relic used to rebuild the world \nUnbelivable placement speed, range and has the ability to automatically paint");
		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 16;
			item.value = Item.buyPrice(0, 5, 90, 0);
			item.rare = 9;
			item.accessory = true;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(3061, 1);
			modRecipe.AddIngredient(1225, 8);
			modRecipe.AddIngredient(mod.ItemType("BuilderMania"), 1);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.tileSpeed += 0.85f;
			player.wallSpeed += 1.25f;
			player.blockRange += 5;
			player.autoPaint = true;
		}
	}
}
