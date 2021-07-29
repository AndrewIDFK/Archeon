using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Materials
{
	public class FeralShard : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Feral Shard");
			Tooltip.SetDefault("The crystalized tissue of a beautiful creature");
		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 12;
			item.rare = 7;
			item.value = Item.buyPrice(0, 0, 50, 0);
			item.maxStack = 99;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("FeralShard"), 5);
			modRecipe.AddTile(114);
			modRecipe.SetResult(211, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("FeralShard"), 12);
			modRecipe.AddTile(134);
			modRecipe.SetResult(758, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("FeralShard"), 14);
			modRecipe.AddTile(134);
			modRecipe.SetResult(1255, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("FeralShard"), 10);
			modRecipe.AddTile(134);
			modRecipe.SetResult(788, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("FeralShard"), 11);
			modRecipe.AddTile(134);
			modRecipe.SetResult(1178, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("FeralShard"), 12);
			modRecipe.AddTile(134);
			modRecipe.SetResult(1259, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("FeralShard"), 13);
			modRecipe.AddTile(134);
			modRecipe.SetResult(1155, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("FeralShard"), 15);
			modRecipe.AddTile(134);
			modRecipe.SetResult(3018, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("FeralShard"), 15);
			modRecipe.AddTile(134);
			modRecipe.SetResult(3018, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(2273);
			modRecipe.AddIngredient(3514);
			modRecipe.AddTile(16);
			modRecipe.SetResult(3349);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(2273);
			modRecipe.AddIngredient(3490);
			modRecipe.AddTile(16);
			modRecipe.SetResult(3349);
			modRecipe.AddRecipe();
		}
	}
}
