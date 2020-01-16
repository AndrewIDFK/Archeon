using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	
	public class BOOMBEAM : ModProjectile
	{
		
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("BOOM Beam");
		}

		public override void SetDefaults()
		{
			base.projectile.width = 16;
			base.projectile.height = 0;
			base.projectile.friendly = true;
			base.projectile.ranged = true;
			base.projectile.penetrate = -1;
			base.projectile.extraUpdates = 25;
			base.projectile.timeLeft = 185;
		}

		public override void AI()
		{
			base.projectile.localAI[0] += 1f;
			if (base.projectile.localAI[0] > 3f)
			{
				for (int i = 0; i < 7; i++)
				{
					Vector2 vector = base.projectile.position;
					vector -= base.projectile.velocity * ((float)i * 0.25f);
					base.projectile.alpha = 255;
					int num = Dust.NewDust(vector, 1, 1, mod.DustType("HalloweenDust1"), 0f, 0f, 0, default(Color), 1f);
					Main.dust[num].noGravity = true;
					Main.dust[num].position = vector;
					Main.dust[num].scale = (float)Main.rand.Next(45, 65) * 0.02675f;
					Main.dust[num].velocity *= 0.4f;
				}
				return;
			}
		}

		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[base.projectile.owner] = 1;
			Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, base.mod.ProjectileType("BOOMBEAMBOOM"), base.projectile.damage, base.projectile.knockBack, Main.myPlayer, 0f, 0f);
		}
	}
}
