using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Consumables.Potions
{
	public class PotionOfPower : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Potion of Power");
			Tooltip.SetDefault("A liquid that's almost pure adrenaline \nIncreases all damage by 35%");
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
			item.rare = 6;
			item.buffType = mod.BuffType("OverwhelmingPower");
			item.buffTime = 10000;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(126, 1);
			modRecipe.AddIngredient(313, 3);
			modRecipe.AddIngredient(999, 1);
			modRecipe.AddIngredient(318, 1);
			modRecipe.AddIngredient(1225, 2);
			modRecipe.AddTile(13);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
