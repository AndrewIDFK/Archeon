using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items
{
	public class AmpedDiamond : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Amplified Diamond");
			base.Tooltip.SetDefault("A diamond amplified by Luminite");
		}
		
		public override void SetDefaults()
		{
			base.item.width = 12;
			base.item.height = 12;
			base.item.rare = 6;
			base.item.value = Item.buyPrice(0, 0, 75, 0);
			base.item.value = Item.sellPrice(0, 0, 75, 0);
			base.item.maxStack = 99;
		}
		
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(182, 1);
			modRecipe.AddIngredient(3460, 1);
			modRecipe.AddTile(mod.TileType("GemConstructorTile"));
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
