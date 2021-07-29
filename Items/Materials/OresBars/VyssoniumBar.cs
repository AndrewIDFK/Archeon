using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Materials.OresBars
{
	public class VyssoniumBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vyssonium Bar");
			Tooltip.SetDefault("Crimson has fully infected it");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.useTime = 15;
			item.useAnimation = 15;
			item.rare = 3;
			item.useStyle = 1;
			item.value = Item.buyPrice(0, 0, 35, 0);
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = mod.TileType("VyssoniumBarTile");
			item.maxStack = 99;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("VyssoniumOre"), 3);
			modRecipe.AddTile(77);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("ShadoniumBar"), 1);
			modRecipe.AddTile(77);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(836, 1);
			modRecipe.AddTile(114);
			modRecipe.SetResult(61, 1);
			modRecipe.AddRecipe();
		}
	}
}
