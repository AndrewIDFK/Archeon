using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x02000051 RID: 81
	public class DeepSeaGlaivePearl : ModProjectile
	{
		// Token: 0x0600015F RID: 351 RVA: 0x00009780 File Offset: 0x00007980
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("DeepSeaGlaivePearl");
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00009794 File Offset: 0x00007994
		public override void SetDefaults()
		{
			base.projectile.width = 18;
			base.projectile.height = 18;
			base.projectile.friendly = true;
			base.projectile.penetrate = 2;
			base.projectile.hostile = false;
			base.projectile.magic = true;
			base.projectile.tileCollide = true;
			base.projectile.ignoreWater = true;
			base.projectile.scale = 1.4f;
			base.projectile.aiStyle = 14;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00009820 File Offset: 0x00007A20
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			base.projectile.penetrate--;
			if (base.projectile.penetrate <= 0)
			{
				base.projectile.Kill();
			}
			else
			{
				if (base.projectile.velocity.X != oldVelocity.X)
				{
					base.projectile.velocity.X = -oldVelocity.X;
				}
				if (base.projectile.velocity.Y != oldVelocity.Y)
				{
					base.projectile.velocity.Y = -oldVelocity.Y;
				}
				Main.PlaySound(SoundID.Item10, base.projectile.position);
			}
			return false;
		}

		// Token: 0x06000162 RID: 354 RVA: 0x000098D4 File Offset: 0x00007AD4
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.65f, 0.1f, 1.35f);
			base.projectile.rotation += 0.3f * (float)base.projectile.direction;
			base.projectile.ai[0] += 1f;
			if (base.projectile.ai[0] >= 13f)
			{
				base.projectile.ai[0] = 13f;
				base.projectile.velocity.Y = base.projectile.velocity.Y + 0.25f;
			}
			if (base.projectile.velocity.Y > 14f)
			{
				base.projectile.velocity.Y = 14f;
			}
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 15, base.projectile.velocity.X * -0.5f, base.projectile.velocity.Y * -0.5f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 80f;
			Main.dust[num].scale = 1.1f;
			Main.dust[num].noGravity = true;
			int num2 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 34, base.projectile.velocity.X * -22.4f, base.projectile.velocity.Y * -13.6f, 0, default(Color), 1f);
			Main.dust[num2].velocity /= 80f;
			Main.dust[num2].scale = 1.1f;
			Main.dust[num2].noGravity = true;
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + 0.6f;
			base.projectile.localAI[0] += 1f;
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00009B78 File Offset: 0x00007D78
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 15, base.projectile.velocity.X * 33.9f, base.projectile.velocity.Y * 21.9f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 80f;
			Main.dust[num].scale = 1.15f;
			int num2 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 34, base.projectile.velocity.X * -22.4f, base.projectile.velocity.Y * -13.6f, 0, default(Color), 1f);
			Main.dust[num2].velocity /= 80f;
			Main.dust[num2].scale = 1.15f;
			int num3 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 15, base.projectile.velocity.X * -30.2f, base.projectile.velocity.Y * -14.7f, 0, default(Color), 1f);
			Main.dust[num3].velocity /= 80f;
			Main.dust[num3].scale = 1.15f;
			int num4 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 15, base.projectile.velocity.X * -10.2f, base.projectile.velocity.Y * -17.7f, 0, default(Color), 1f);
			Main.dust[num4].velocity /= 80f;
			Main.dust[num4].scale = 1.15f;
			int num5 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 15, base.projectile.velocity.X * 33.9f, base.projectile.velocity.Y * 21.9f, 0, default(Color), 1f);
			Main.dust[num5].velocity /= 80f;
			Main.dust[num5].scale = 1.15f;
			int num6 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 34, base.projectile.velocity.X * -22.4f, base.projectile.velocity.Y * -13.6f, 0, default(Color), 1f);
			Main.dust[num6].velocity /= 80f;
			Main.dust[num6].scale = 1.15f;
			int num7 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 15, base.projectile.velocity.X, base.projectile.velocity.Y, 0, default(Color), 1f);
			Main.dust[num7].velocity /= 55f;
			Main.dust[num7].scale = 1.15f;
			int num8 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 34, base.projectile.velocity.X, base.projectile.velocity.Y, 0, default(Color), 1f);
			Main.dust[num8].velocity /= 55f;
			Main.dust[num8].scale = 1.15f;
			int num9 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 15, base.projectile.velocity.X, base.projectile.velocity.Y, 0, default(Color), 1f);
			Main.dust[num9].velocity /= 55f;
			Main.dust[num9].scale = 1f;
			int num10 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 15, base.projectile.velocity.X, base.projectile.velocity.Y, 0, default(Color), 1f);
			Main.dust[num10].velocity /= 55f;
			Main.dust[num10].scale = 1f;
		}
	}
}
