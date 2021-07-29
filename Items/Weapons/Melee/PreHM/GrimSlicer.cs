using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Melee.PreHM
{
	public class GrimSlicer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Grim Slicer");
		}

		public override void SetDefaults()
		{
			item.damage = 25;
			item.melee = true;
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
			item.shoot = mod.ProjectileType("GrimSlicerProj");
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
			modRecipe.AddIngredient(mod.ItemType("GrimSlicerThrown"), 1);
			modRecipe.AddTile(TileID.Anvils);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
