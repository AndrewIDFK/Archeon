using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Consumables.Potions
{
	public class Tantrum : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tantrum");
			Tooltip.SetDefault("Dude, you're a grown man, why are you throwing a tantrum? \nIncreased movement speed and all damage by 20%");
		}

		public override void SetDefaults()
		{
			item.UseSound = SoundID.Item3;
			item.useStyle = 2;
			item.useTurn = true;
			item.useAnimation = 17;
			item.useTime = 17;
			item.maxStack = 30;
			item.consumable = true;
			item.width = 20;
			item.height = 28;
			item.value = Item.buyPrice(0, 1, 75, 0);
			item.rare = 7;
			item.buffType = mod.BuffType("TANTRUMBUFF");
			item.buffTime = 10000;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(126, 1);
			modRecipe.AddIngredient(mod.ItemType("FeralShard"), 1);
			modRecipe.AddIngredient(1339, 3);
			modRecipe.AddTile(13);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
