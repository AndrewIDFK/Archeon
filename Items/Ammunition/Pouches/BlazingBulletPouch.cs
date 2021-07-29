using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Ammunition.Pouches
{
	public class BlazingBulletPouch : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blazing Bullet Pouch");
			Tooltip.SetDefault("An infinitely deep pouch full of Blazing Bullets");
		}

		public override void SetDefaults()
		{
			item.damage = 9;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.consumable = false;
			item.knockBack = 3f;
			item.value = Item.buyPrice(0, 8, 25, 0);
			item.rare = 2;
			item.shootSpeed = 14f;
			item.ammo = AmmoID.Bullet;
			item.shoot = base.mod.ProjectileType("BlazingBulletShot");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == 14)
			{
				type = base.mod.ProjectileType("BlazingBulletShot");
			}
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(175, 25);
			modRecipe.AddIngredient(mod.ItemType("BlazingBullet"), 3996);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
