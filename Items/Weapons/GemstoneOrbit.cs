using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	
	public class GemstoneOrbit : ModItem
	{
		
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Gemstone Orbit");
			base.Tooltip.SetDefault("Summons 3 gems to orbit around the player");
		}

		
		public override void SetDefaults()
		{
			base.item.damage = 32;
			base.item.melee = true;
			base.item.width = 34;
			base.item.height = 40;
			base.item.useStyle = 1;
			base.item.knockBack = 5.75f;
			base.item.value = Item.buyPrice(0, 0, 65, 0);
			base.item.value = Item.sellPrice(0, 0, 65, 0);
			base.item.rare = 4;
			base.item.shootSpeed = 12f;
			base.item.shoot = base.mod.ProjectileType("EmeraldCircleShot");
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
			base.item.scale = 1.15f;
			base.item.useAnimation = 90;
			base.item.useTime = 30;
			base.item.reuseDelay = 30;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 1;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.ToRadians(120f * i));
				if (player.ownedProjectileCounts[base.mod.ProjectileType("EmeraldCircleShot")] < 1 && player.ownedProjectileCounts[base.mod.ProjectileType("RubyCircleShot")] < 1 && player.ownedProjectileCounts[base.mod.ProjectileType("TopazCircleShot")] < 1)
				{
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI, i);
				}
				if (player.ownedProjectileCounts[base.mod.ProjectileType("EmeraldCircleShot")] > 0 && player.ownedProjectileCounts[base.mod.ProjectileType("RubyCircleShot")] < 1)
				{
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("RubyCircleShot"), damage, knockBack, player.whoAmI, i);
				}
				if (player.ownedProjectileCounts[base.mod.ProjectileType("RubyCircleShot")] > 0 && player.ownedProjectileCounts[base.mod.ProjectileType("EmeraldCircleShot")] > 0 && player.ownedProjectileCounts[base.mod.ProjectileType("TopazCircleShot")] < 1)
				{
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("TopazCircleShot"), damage, knockBack, player.whoAmI, i);
				}
				if (player.ownedProjectileCounts[base.mod.ProjectileType("RubyCircleShot")] > 0 && player.ownedProjectileCounts[base.mod.ProjectileType("EmeraldCircleShot")] > 0 && player.ownedProjectileCounts[base.mod.ProjectileType("TopazCircleShot")] > 0)
				{		
				}
			}
			return false;
		}

		

		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Utils.NextBool(Main.rand, 5))
			{
				Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 60, 0f, 0f, 0, default(Color), 1f);
				Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 61, 0f, 0f, 0, default(Color), 1f);
				Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 64, 0f, 0f, 0, default(Color), 1f);
			}
		}
	}
}
