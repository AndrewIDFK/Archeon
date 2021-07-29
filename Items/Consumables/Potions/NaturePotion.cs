using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Consumables.Potions
{
	public class NaturePotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nature Potion");
			Tooltip.SetDefault("A potion that replicates the essence of the Dryad \nGrants Dryad's Blessing");
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
			item.value = Item.buyPrice(0, 0, 45, 0);
			item.rare = 4;
			item.buffType = mod.BuffType("DryadBlessingBuff");
			item.buffTime = 18000;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(66, 15);
			modRecipe.AddIngredient(313, 5);
			modRecipe.AddIngredient(126, 1);
			modRecipe.AddTile(13);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
