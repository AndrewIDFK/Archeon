using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Tools
{
	public class GrimbringerPax : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Grimbringer Pax");
			Tooltip.SetDefault("You feel suicidal while holding it");
		}

		public override void SetDefaults()
		{
			item.damage = 24;
			item.melee = true;
			item.width = 34;
			item.height = 34;
			item.useTime = 15;
			item.useAnimation = 15;
			item.pick = 100;
			item.axe = 15;
			item.useStyle = 1;
			item.knockBack = 8f;
			item.value = Item.buyPrice(0, 1, 30, 0);
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.scale = 1.05f;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("VyssoniumBar"), 20);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
