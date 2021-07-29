﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Thrown.PreHM
{
	public class QueensGambitThrown : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Queen's Gambit");
			Tooltip.SetDefault("Occasionaly summons killer bees as it travels");
		}

		public override void SetDefaults()
		{
			item.damage = 25;
			item.thrown = true;
			item.width = 38;
			item.height = 38;
			item.useTime = 19;
			item.useAnimation = 19;
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.knockBack = 1.5f;
			item.value = Item.buyPrice(0, 2, 05, 0);
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("QueensGambitThrownProj");
			item.shootSpeed = 14f;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(ItemID.BeeWax, 25);
			modRecipe.AddIngredient(ItemID.Stinger, 5);
			modRecipe.AddIngredient(ItemID.Obsidian, 10);
			modRecipe.AddTile(TileID.Anvils);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("QueensGambit"), 1);
			modRecipe.AddTile(TileID.Anvils);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
