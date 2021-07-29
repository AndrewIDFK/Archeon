using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Materials.OresBars
{
	public class VyssoniumOre : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vyssonium Ore");
			Tooltip.SetDefault("It has been nearly completely infected");
		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 12;
			item.useTime = 10;
			item.useAnimation = 15;
			item.rare = 4;
			item.useStyle = 1;
			item.value = Item.buyPrice(0, 0, 5, 0);
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = mod.TileType("VyssoniumTile");
			item.maxStack = 999;
			item.UseSound = SoundID.Item1;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("ShadoniumOre"), 1);
			modRecipe.AddTile(77);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
