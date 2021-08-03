using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Consumables.Potions
{
	public class CorruptionPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corrupt Potion");
			Tooltip.SetDefault("You're not sure if you want to consume it \nDefense increased by 12");
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
			item.buffType = mod.BuffType("CorruptionPotionBuff");
			item.buffTime = 8000;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(2318, 1);
			modRecipe.AddIngredient(292, 1);
			modRecipe.AddIngredient(mod.ItemType("ShadoniumOre"), 2);
			modRecipe.AddTile(13);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
