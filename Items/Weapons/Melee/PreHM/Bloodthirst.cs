using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Melee.PreHM
{
	public class Bloodthirst : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloodthirst");
			Tooltip.SetDefault("Shatters into blood in the air");
		}

		public override void SetDefaults()
		{
			item.damage = 28;
			item.melee = true;
			item.width = 38;
			item.height = 38;
			item.useTime = 29;
			item.useAnimation = 29;
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.knockBack = 2f;
			item.value = Item.buyPrice(0, 2, 30, 0);
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("BloodthirstProj");
			item.shootSpeed = 15.5f;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("VyssoniumBar"), 20);
			modRecipe.AddTile(TileID.Anvils);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
