using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Tools
{
	public class OrdealPax : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ordeal Pax");
			Tooltip.SetDefault("You feel miserable while holding it");
		}

		public override void SetDefaults()
		{
			item.damage = 16;
			item.melee = true;
			item.width = 34;
			item.height = 34;
			item.useTime = 14;
			item.useAnimation = 14;
			item.pick = 100;
			item.axe = 15;
			item.useStyle = 1;
			item.knockBack = 7f;
			item.value = Item.buyPrice(0, 1, 30, 0);
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.scale = 1.2f;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("ShadoniumBar"), 20);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
