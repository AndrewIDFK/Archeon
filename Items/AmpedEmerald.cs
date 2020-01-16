using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items
{
	public class AmpedEmerald : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Amplified Emerald");
			base.Tooltip.SetDefault("An emerald amplified by Chlorophyte");
		}
		
		public override void SetDefaults()
		{
			base.item.width = 12;
			base.item.height = 12;
			base.item.rare = 6;
			base.item.value = Item.buyPrice(0, 0, 50, 0);
			base.item.value = Item.sellPrice(0, 0, 50, 0);
			base.item.maxStack = 99;
		}
		
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(179, 1);
			modRecipe.AddIngredient(947, 2);
			modRecipe.AddTile(mod.TileType("GemConstructorTile"));
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
