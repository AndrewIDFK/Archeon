using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Projectiles.Melee.DeepSea
{
	public class DSGSpear : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 26;
			projectile.aiStyle = 19;
			projectile.scale = 1.2f;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.timeLeft = 140;
			projectile.hide = true;
			projectile.alpha = 0;
		}

		public float movementFactor
		{
			get
			{
				return projectile.ai[0];
			}
			set
			{
				projectile.ai[0] = value;
			}
		}
		int Timer;
		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
			projectile.direction = player.direction;
			player.heldProj = projectile.whoAmI;
			player.itemTime = player.itemAnimation;
			projectile.position.X = vector.X - (float)(projectile.width / 2);
			projectile.position.Y = vector.Y - (float)(projectile.height / 2);
			if (!player.frozen)
			{
				if (movementFactor == 0f)
				{
					movementFactor = 1.8f;
					projectile.netUpdate = true;
				}
				if (player.itemAnimation < player.itemAnimationMax / 3)
				{
					movementFactor -= 1.9f;
				}
				else
				{
					movementFactor += 1.6f;
				}
			}
			Timer++;
			if(Utils.NextBool(Main.rand, 6))
			{
				if(Timer >= 10)
				{
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X * 3.75f, projectile.velocity.Y * 3.75f, mod.ProjectileType("DSGSpray"), projectile.damage, 0, player.whoAmI, 0f, 0f);
					Timer = 0;
				}
			}
			if(player.direction == -1)
			{
				projectile.spriteDirection = -1;
			}
			else projectile.spriteDirection = 0;
			projectile.position += projectile.velocity * movementFactor;
			if (player.itemAnimation == 0)
			{
				projectile.Kill();
			}
			projectile.rotation = Utils.ToRotation(projectile.velocity) + MathHelper.ToRadians(135f);
			if (projectile.spriteDirection == -1)
			{
				projectile.rotation -= MathHelper.ToRadians(90f);
			}
			if (Utils.NextBool(Main.rand, 4))
			{
				Dust dust2 = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 15, 0f, 0f, 88, default(Color), 0.3f);
				dust2.velocity += projectile.velocity * 0.5f;
				dust2.velocity *= 0.5f;
			}
		}
	}
}
