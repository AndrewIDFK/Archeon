using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Thrown.PreHM
{
	public class GrimSlicerThrown : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Grim Slicer");
		}

		public override void SetDefaults()
		{
			item.damage = 25;
			item.thrown = true;
			item.width = 30;
			item.height = 30;
			item.useTime = 18;
			item.useAnimation = 18;
			item.noUseGraphic = true;
			item.useStyle = 1;
			item.knockBack = 6f;
			item.value = Item.buyPrice(0, 1, 0, 0);
			item.rare = 4;
			item.shootSpeed = 10f;
			item.shoot = mod.ProjectileType("GrimSlicerThrownProj");
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("VyssoniumBar"), 12);
			modRecipe.AddIngredient(836, 10);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("GrimSlicer"), 1);
			modRecipe.AddTile(TileID.Anvils);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			
		}
	}
}
