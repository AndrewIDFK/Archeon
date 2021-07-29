using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Ammunition.Pouches
{
	public class LuminiteBulletPouch : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Luminite Bullet Pouch");
			Tooltip.SetDefault("An infinitely deep pouch full of Luminite Bullets");
		}

		public override void SetDefaults()
		{
			item.damage = 20;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.consumable = false;
			item.knockBack = 3f;
			item.value = Item.buyPrice(0, 22, 50, 0);
			item.rare = 9;
			item.shootSpeed = 18f;
			item.ammo = AmmoID.Bullet;
			item.shoot = 638;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == 14)
			{
				type = 638;
			}
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(1006, 20);
			modRecipe.AddIngredient(3567, 3996);
			modRecipe.AddTile(412);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
