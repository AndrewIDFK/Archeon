using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Accessories
{
	public class BuilderMania : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Builder's Maniacal Essence");
			Tooltip.SetDefault("Become a master builder!\nSignificantly increases placement Speed and Range");
		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 16;
			item.value = Item.buyPrice(0, 3, 50, 0);
			item.rare = 7;
			item.accessory = true;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(2325, 1);
			modRecipe.AddIngredient(407, 1);
			modRecipe.AddRecipeGroup("GoldOrPlatinumBar", 20);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(1071, 1);
			modRecipe.AddRecipeGroup("SilverOrTungstenBar", 20);
			modRecipe.AddTile(16);
			modRecipe.SetResult(2216, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(133, 15);
			modRecipe.AddRecipeGroup("SilverOrTungstenBar", 5);
			modRecipe.AddTile(16);
			modRecipe.SetResult(2217, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(154, 5);
			modRecipe.AddRecipeGroup("SilverOrTungstenBar", 15);
			modRecipe.AddTile(16);
			modRecipe.SetResult(2215, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(530, 2);
			modRecipe.AddRecipeGroup("GoldOrPlatinumBar", 10);
			modRecipe.AddTile(16);
			modRecipe.SetResult(2214, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(530, 10);
			modRecipe.AddRecipeGroup("GoldOrPlatinumBar", 15);
			modRecipe.AddTile(16);
			modRecipe.SetResult(3624, 1);
			modRecipe.AddRecipe();
		}


		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.tileSpeed += 0.45f;
			player.wallSpeed += 0.65f;
			player.blockRange += 2;
		}
	}
}
