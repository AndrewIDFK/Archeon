using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items
{
	public class AmpedAmethyst : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Amplified Amethyst");
			base.Tooltip.SetDefault("An amethyst amplified by a Nightly Soul");
		}

		public override void SetDefaults()
		{
			base.item.width = 12;
			base.item.height = 12;
			base.item.rare = 6;
			base.item.value = Item.buyPrice(0, 0, 35, 0);
			base.item.value = Item.sellPrice(0, 0, 35, 0);
			base.item.maxStack = 99;
		}
		
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(181, 1);
			modRecipe.AddIngredient(521, 1);
			modRecipe.AddTile(mod.TileType("GemConstructorTile"));
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
