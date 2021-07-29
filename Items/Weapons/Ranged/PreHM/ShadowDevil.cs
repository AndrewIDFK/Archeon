﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Ranged.PreHM
{
	public class ShadowDevil : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadow Devil");
			//Tooltip.SetDefault("");
		}
		
		public override void SetDefaults()
		{
			item.damage = 18;
			item.noMelee = true;
			item.ranged = true;
			item.width = 26;
			item.height = 46;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 5;
			item.shoot = AmmoID.Arrow;
			item.useAmmo = AmmoID.Arrow;
			item.knockBack = 1f;
			item.value = Item.buyPrice(0, 0, 95, 0);
			item.rare = 4;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shootSpeed = 7.25f;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if(type == ProjectileID.WoodenArrowFriendly)
			{
				type = mod.ProjectileType("ShadoniumArrowProj");
			}
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(new Vector2(2f, 1f));
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(ItemID.DemonBow, 1);
			modRecipe.AddIngredient(mod.ItemType("ShadoniumBar"), 14);
			modRecipe.AddTile(TileID.DemonAltar);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
