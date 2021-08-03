using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Consumables.Potions
{
	public class CrimsonPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Infectious Potion");
			Tooltip.SetDefault("You can see something moving around in it \nIncreases all damage by 20%");
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
			item.value = Item.buyPrice(0, 0, 60, 0);
			item.rare = 5;
			item.buffType = mod.BuffType("CrimsonPotionBuff");
			item.buffTime = 8000;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(2305, 1);
			modRecipe.AddIngredient(2349, 1);
			modRecipe.AddIngredient(mod.ItemType("VyssoniumOre"), 2);
			modRecipe.AddTile(13);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
