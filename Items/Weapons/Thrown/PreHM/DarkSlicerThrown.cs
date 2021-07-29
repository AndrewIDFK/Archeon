using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Thrown.PreHM
{
	public class DarkSlicerThrown : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Slicer");
		}

		public override void SetDefaults()
		{
			item.damage = 20;
			item.thrown = true;
			item.width = 30;
			item.height = 30;
			item.useTime = 16;
			item.useAnimation = 16;
			item.noUseGraphic = true;
			item.useStyle = 1;
			item.knockBack = 5f;
			item.value = Item.buyPrice(0, 1, 0, 0);
			item.rare = 4;
			item.shootSpeed = 12f;
			item.shoot = mod.ProjectileType("DarkSlicerThrownProj");
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("ShadoniumBar"), 12);
			modRecipe.AddIngredient(61, 10);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("DarkSlicer"), 1);
			modRecipe.AddTile(TileID.Anvils);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
