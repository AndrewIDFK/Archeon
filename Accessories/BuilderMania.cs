using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Accessories
{
	// Token: 0x02000008 RID: 8
	public class BuilderMania : ModItem
	{
		// Token: 0x06000034 RID: 52 RVA: 0x00003BF0 File Offset: 0x00001DF0
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Mania Builder");
			base.Tooltip.SetDefault("Become a master builder!\nSignificantly increases placement Speed and Range!");
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00003C14 File Offset: 0x00001E14
		public override void SetDefaults()
		{
			base.item.width = 12;
			base.item.height = 16;
			base.item.value = Item.buyPrice(0, 3, 50, 0);
			base.item.value = Item.sellPrice(0, 3, 50, 0);
			base.item.rare = 8;
			base.item.accessory = true;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00003C80 File Offset: 0x00001E80
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(2325, 1);
			modRecipe.AddIngredient(407, 1);
			modRecipe.AddRecipeGroup("GoldOrPlatinumBar", 20);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(1071, 1);
			modRecipe.AddRecipeGroup("SilverOrTungstenBar", 20);
			modRecipe.AddTile(16);
			modRecipe.SetResult(2216, 1);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(133, 15);
			modRecipe.AddRecipeGroup("SilverOrTungstenBar", 5);
			modRecipe.AddTile(16);
			modRecipe.SetResult(2217, 1);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(154, 5);
			modRecipe.AddRecipeGroup("SilverOrTungstenBar", 15);
			modRecipe.AddTile(16);
			modRecipe.SetResult(2215, 1);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(530, 2);
			modRecipe.AddRecipeGroup("GoldOrPlatinumBar", 10);
			modRecipe.AddTile(16);
			modRecipe.SetResult(2214, 1);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(530, 10);
			modRecipe.AddRecipeGroup("GoldOrPlatinumBar", 15);
			modRecipe.AddTile(16);
			modRecipe.SetResult(3624, 1);
			modRecipe.AddRecipe();
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00003E10 File Offset: 0x00002010
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.tileSpeed += 0.45f;
			player.wallSpeed += 0.65f;
			player.blockRange += 2;
		}
	}
}
