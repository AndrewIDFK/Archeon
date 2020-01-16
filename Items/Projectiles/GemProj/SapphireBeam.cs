using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles.GemProj
{
	
	public class SapphireBeam : ModProjectile
	{
		
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Beam Scatter");
		}

		public override void SetDefaults()
		{
			base.projectile.width = 16;
			base.projectile.height = 0;
			base.projectile.friendly = true;
			base.projectile.magic = true;
			base.projectile.penetrate = 1;
			base.projectile.extraUpdates = 22;
			base.projectile.timeLeft = 30;
			base.projectile.hide = true;
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
					int num = Dust.NewDust(vector, 1, 1, 59, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num].noGravity = true;
					Main.dust[num].position = vector;
					Main.dust[num].scale = (float)Main.rand.Next(45, 65) * 0.02675f;
					Main.dust[num].velocity *= 0.4f;
				}
				return;
			}
		}
	}
}
