using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Ranged.HM
{
	public class MeteorSixShooter : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cosmic Six-Shooter");
			Tooltip.SetDefault("Shoots 6 consecutive Meteor Shots");
		}

		public override void SetDefaults()
		{
			item.damage = 35;
			item.crit = 6;
			item.ranged = true;
			item.width = 16;
			item.height = 24;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 4.75f;
			item.value = Item.buyPrice(0, 4, 50, 0);
			item.rare = 5;
			item.UseSound = SoundID.Item41;
			item.autoReuse = true;
			item.shoot = 36;
			item.shootSpeed = 18f;
			item.useAmmo = AmmoID.Bullet;
			item.scale = 1.05f;
			item.useAnimation = 24;
			item.useTime = 4;
			item.reuseDelay = 18;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(new Vector2(4f, 0f));
		}
		
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(ItemID.Revolver, 1);
			modRecipe.AddIngredient(ItemID.MeteoriteBar, 20);
			modRecipe.AddIngredient(ItemID.SoulofLight, 5);
			modRecipe.AddTile(TileID.MythrilAnvil);
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
