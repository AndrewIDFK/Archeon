using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	public class PumpkinChunker : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Pumpkin Chunker");
		}

		public override void SetDefaults()
		{
			base.projectile.width = 32;
			base.projectile.height = 38;
			base.projectile.friendly = true;
			base.projectile.penetrate = 2;
			base.projectile.hostile = false;
			base.projectile.magic = true;
			base.projectile.tileCollide = true;
			base.projectile.ignoreWater = true;
			base.projectile.scale = 1f;
			base.projectile.aiStyle = 1;
		
		}

		
		

		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.25f, 0.23f, 0.23f);
			base.projectile.rotation += 0.2f * (float)base.projectile.direction;
			base.projectile.ai[0] += 1f;
			if (base.projectile.ai[0] >= 15f)
			{
				base.projectile.ai[0] = 15f;
				base.projectile.velocity.Y = base.projectile.velocity.Y + 0.2f;
			}
			if (base.projectile.velocity.Y > 16f)
			{
				base.projectile.velocity.Y = 16f;
			}
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, mod.DustType("HalloweenDust1"), base.projectile.velocity.X * -0.5f, base.projectile.velocity.Y * -0.5f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 60f;
			Main.dust[num].scale = 1f;
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + 1.1f;
			base.projectile.localAI[0] += 1f;
		}

		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, mod.DustType("HalloweenDust1"), base.projectile.velocity.X * 33.9f, base.projectile.velocity.Y * 21.9f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 80f;
			Main.dust[num].scale = 1f;
			int num2 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, mod.DustType("HalloweenDust1"), base.projectile.velocity.X * -22.4f, base.projectile.velocity.Y * -13.6f, 0, default(Color), 1f);
			Main.dust[num2].velocity /= 80f;
			Main.dust[num2].scale = 1f;
			int num3 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, mod.DustType("HalloweenDust1"), base.projectile.velocity.X * -30.2f, base.projectile.velocity.Y * -14.7f, 0, default(Color), 1f);
			Main.dust[num3].velocity /= 80f;
			Main.dust[num3].scale = 1f;
			int num4 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, mod.DustType("HalloweenDust1"), base.projectile.velocity.X * -10.2f, base.projectile.velocity.Y * -17.7f, 0, default(Color), 1f);
			Main.dust[num4].velocity /= 80f;
			Main.dust[num4].scale = 1f;
			int num5 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, mod.DustType("HalloweenDust1"), base.projectile.velocity.X * 33.9f, base.projectile.velocity.Y * 21.9f, 0, default(Color), 1f);
			Main.dust[num5].velocity /= 80f;
			Main.dust[num5].scale = 1f;
			int num6 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, mod.DustType("HalloweenDust1"), base.projectile.velocity.X * -22.4f, base.projectile.velocity.Y * -13.6f, 0, default(Color), 1f);
			Main.dust[num6].velocity /= 80f;
			Main.dust[num6].scale = 1f;
		}
	}
}
