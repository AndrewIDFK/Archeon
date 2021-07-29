using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Materials.OresBars
{
	public class RockSteeleBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("RockSteele Bar");
			Tooltip.SetDefault("It's surprisingly heavy");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.useTime = 15;
			item.useAnimation = 15;
			item.rare = 3;
			item.useStyle = 1;
			item.value = Item.buyPrice(0, 0, 40, 0);
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = mod.TileType("RockSteeleBarTile");
			item.maxStack = 99;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("RockSteeleOre"), 4);
			modRecipe.AddTile(133);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
