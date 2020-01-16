using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x0200005D RID: 93
	public class PlantasmoidShot : ModProjectile
	{
		// Token: 0x06000196 RID: 406 RVA: 0x0000DB5B File Offset: 0x0000BD5B
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("ThornBallPlantasmoid");
		}

		// Token: 0x06000197 RID: 407 RVA: 0x0000DB70 File Offset: 0x0000BD70
		public override void SetDefaults()
		{
			base.projectile.width = 38;
			base.projectile.height = 38;
			base.projectile.friendly = true;
			base.projectile.penetrate = 6;
			base.projectile.hostile = false;
			base.projectile.magic = true;
			base.projectile.tileCollide = true;
			base.projectile.ignoreWater = true;
			base.projectile.scale = 1f;
			base.projectile.aiStyle = 14;
		}

		// Token: 0x06000198 RID: 408 RVA: 0x0000DBFC File Offset: 0x0000BDFC
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

		// Token: 0x06000199 RID: 409 RVA: 0x0000DCB0 File Offset: 0x0000BEB0
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 1.65f, 0.1f, 0.45f);
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
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 58, base.projectile.velocity.X * -0.5f, base.projectile.velocity.Y * -0.5f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 60f;
			Main.dust[num].scale = 1f;
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + 1.1f;
			base.projectile.localAI[0] += 1f;
		}

		// Token: 0x0600019A RID: 410 RVA: 0x0000DE98 File Offset: 0x0000C098
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 72, base.projectile.velocity.X * 33.9f, base.projectile.velocity.Y * 21.9f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 80f;
			Main.dust[num].scale = 1f;
			int num2 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 86, base.projectile.velocity.X * -22.4f, base.projectile.velocity.Y * -13.6f, 0, default(Color), 1f);
			Main.dust[num2].velocity /= 80f;
			Main.dust[num2].scale = 1f;
			int num3 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 86, base.projectile.velocity.X * -30.2f, base.projectile.velocity.Y * -14.7f, 0, default(Color), 1f);
			Main.dust[num3].velocity /= 80f;
			Main.dust[num3].scale = 1f;
			int num4 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 73, base.projectile.velocity.X * -10.2f, base.projectile.velocity.Y * -17.7f, 0, default(Color), 1f);
			Main.dust[num4].velocity /= 80f;
			Main.dust[num4].scale = 1f;
			int num5 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 72, base.projectile.velocity.X * 33.9f, base.projectile.velocity.Y * 21.9f, 0, default(Color), 1f);
			Main.dust[num5].velocity /= 80f;
			Main.dust[num5].scale = 1f;
			int num6 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 86, base.projectile.velocity.X * -22.4f, base.projectile.velocity.Y * -13.6f, 0, default(Color), 1f);
			Main.dust[num6].velocity /= 80f;
			Main.dust[num6].scale = 1f;
		}
	}
}
