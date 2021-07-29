using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Melee.PreHM
{
	public class DeepSeaGlaive : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Deep Sea Glaive");
			Tooltip.SetDefault("Glaive powerful enough to slice the oceans apart \nUnfortunately it's just a poor imitation");
		}

		public override void SetDefaults()
		{
			item.melee = true;
			item.width = 54;
			item.height = 60;
			item.knockBack = 6f;
			item.value = Item.buyPrice(0, 2, 0, 0);
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.useTime = 30;
			item.useAnimation = 30;
			item.damage = 26;
			item.shootSpeed = 4.5f;
			item.useStyle = 5;
			item.noUseGraphic = true;
			item.shoot = mod.ProjectileType("DSGSpear");
		}
		
		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[item.shoot] < 1;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(275, 10);
			modRecipe.AddIngredient(154, 25);
			modRecipe.AddIngredient(mod.ItemType("VyssoniumBar"), 8);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(275, 10);
			modRecipe.AddIngredient(154, 25);
			modRecipe.AddIngredient(mod.ItemType("ShadoniumBar"), 8);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
