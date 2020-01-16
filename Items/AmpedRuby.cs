using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items
{
	public class AmpedRuby : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Amplified Ruby");
			base.Tooltip.SetDefault("A ruby amplified by a durable material");
		}

		public override void SetDefaults()
		{
			base.item.width = 12;
			base.item.height = 12;
			base.item.rare = 6;
			base.item.value = Item.buyPrice(0, 0, 60, 0);
			base.item.value = Item.sellPrice(0, 0, 60, 0);
			base.item.maxStack = 99;
		}
		
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(178, 1);
			modRecipe.AddIngredient(366, 1);
			modRecipe.AddTile(mod.TileType("GemConstructorTile"));
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(178, 1);
			modRecipe.AddIngredient(1106, 1);
			modRecipe.AddTile(mod.TileType("GemConstructorTile"));
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
