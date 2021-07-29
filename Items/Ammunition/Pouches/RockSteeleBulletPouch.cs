using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Ammunition.Pouches
{
	public class RockSteeleBulletPouch : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("RockSteele Bullet Pouch");
			Tooltip.SetDefault("Unlimited RockSteele Bullets");
		}

		public override void SetDefaults()
		{
			item.damage = 10;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.consumable = false;
			item.knockBack = 3f;
			item.value = Item.buyPrice(0, 15, 50, 0);
			item.rare = 4;
			item.shootSpeed = 14f;
			item.ammo = AmmoID.Bullet;
			item.shoot = base.mod.ProjectileType("RockSteeleBulletShot");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == 14)
			{
				type = base.mod.ProjectileType("RockSteeleBulletShot");
			}
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("RockSteeleBar"), 25);
			modRecipe.AddIngredient(mod.ItemType("RockSteeleBullet"), 3996);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
