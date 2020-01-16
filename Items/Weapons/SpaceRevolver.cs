using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	
	public class SpaceRevolver : ModItem
	{
		
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Space Revolver");
			base.Tooltip.SetDefault("Shoots 6 consecutive Meteor Shots");
		}

		public override void SetDefaults()
		{
			base.item.damage = 35;
			base.item.crit = 6;
			base.item.ranged = true;
			base.item.width = 16;
			base.item.height = 24;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 4.75f;
			base.item.value = Item.buyPrice(0, 2, 25, 0);
			base.item.value = Item.sellPrice(0, 2, 25, 0);
			base.item.rare = 6;
			base.item.UseSound = SoundID.Item41;
			base.item.autoReuse = true;
			base.item.shoot = 36;
			base.item.shootSpeed = 18f;
			base.item.useAmmo = AmmoID.Bullet;
			
			base.item.useAnimation = 36;
			base.item.useTime = 6;
			base.item.reuseDelay = 26;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("AmpedTopaz"), 2);
			modRecipe.AddIngredient(117, 12);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 value = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + value, 0, 0))
			{
				position += value;
			}
			Main.PlaySound(SoundID.Item41);
			float speedXX = speedX + (float)Main.rand.Next(-40, 41) * 0.0285f;
			float speedYY = speedY + (float)Main.rand.Next(-40, 41) * 0.0285f;
			Projectile.NewProjectile(position.X, position.Y, speedXX, speedYY, 36, damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
	}
}
