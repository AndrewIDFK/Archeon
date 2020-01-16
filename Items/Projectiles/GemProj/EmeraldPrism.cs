using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles.GemProj
{
	
	public class EmeraldPrism : ModProjectile
	{
		
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Beam Scatter");
		}

		public override void SetDefaults()
		{
			base.projectile.width = 20;
			base.projectile.height = 0;
			base.projectile.friendly = true;
			base.projectile.magic = true;
			base.projectile.penetrate = 1;
			base.projectile.extraUpdates = 20;
			base.projectile.timeLeft = 26;
			base.projectile.hide = true;
		}

		public override void AI()
		{
			base.projectile.localAI[0] += 1f;
			if (base.projectile.localAI[0] > 3f)
			{
				for (int i = 0; i < 8; i++)
				{
					Vector2 vector = base.projectile.position;
					vector -= base.projectile.velocity * ((float)i * 0.25f);
					base.projectile.alpha = 255;
					int num = Dust.NewDust(vector, 1, 1, 61, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num].noGravity = true;
					Main.dust[num].position = vector;
					Main.dust[num].scale = (float)Main.rand.Next(58, 74) * 0.0265f;
					Main.dust[num].velocity *= 0.65f;
				}
				return;
			}
		}
		
		public override void Kill(int Timeleft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			
			int numberProjectiles = 1;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 value = Utils.RotatedByRandom(new Vector2(projectile.velocity.X, projectile.velocity.Y), (double)MathHelper.ToRadians(48f));
				float scaleFactor = 1.29f - Utils.NextFloat(Main.rand) * 0.88f;
				value *= scaleFactor;
				Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, value.X, value.Y, base.mod.ProjectileType("EmeraldPrism2"), base.projectile.damage, base.projectile.knockBack, Main.myPlayer, 0f, 0f);
			}
			base.projectile.netUpdate = true;
			Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 12, 1f, 0f);
			base.projectile.ai[0] = -50f;
		}
	}
}
