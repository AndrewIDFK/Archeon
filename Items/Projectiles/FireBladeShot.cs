using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x02000053 RID: 83
	public class FireBladeShot : ModProjectile
	{
		// Token: 0x0600016A RID: 362 RVA: 0x0000A580 File Offset: 0x00008780
		public override void SetDefaults()
		{
			base.projectile.scale = 0.85f;
			base.projectile.extraUpdates = 0;
			base.projectile.width = 16;
			base.projectile.height = 16;
			base.projectile.aiStyle = 27;
			base.projectile.friendly = true;
			base.projectile.penetrate = 1;
			base.projectile.melee = true;
			Main.PlaySound(SoundID.Item15, base.projectile.position);
			base.projectile.hide = true;
		}

		// Token: 0x0600016B RID: 363 RVA: 0x0000A618 File Offset: 0x00008818
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 1.13f, 0.2f, 0.24f);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("FlamebrandDust"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 100f;
			Main.dust[num].scale = 1.15f;
			int num2 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("FlamebrandDust"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num2].velocity /= 100f;
			Main.dust[num2].scale = 1.15f;
			int num3 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("FlamebrandDust"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num3].velocity /= 100f;
			Main.dust[num3].scale = 1.15f;
		}

		// Token: 0x0600016C RID: 364 RVA: 0x0000A854 File Offset: 0x00008A54
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(SoundID.Item10, base.projectile.position);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 269, base.projectile.velocity.X, base.projectile.velocity.Y, 0, default(Color), 1f);
			Main.dust[num].velocity /= 15f;
			Main.dust[num].scale = 1.1f;
			int num2 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 269, base.projectile.velocity.X, base.projectile.velocity.Y, 0, default(Color), 1f);
			Main.dust[num2].velocity /= 15f;
			Main.dust[num2].scale = 1.1f;
			int num3 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 269, base.projectile.velocity.X, base.projectile.velocity.Y, 0, default(Color), 1f);
			Main.dust[num3].velocity /= 15f;
			Main.dust[num3].scale = 1.1f;
			int num4 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 269, base.projectile.velocity.X, base.projectile.velocity.Y, 0, default(Color), 1f);
			Main.dust[num4].velocity /= 15f;
			Main.dust[num4].scale = 1.1f;
			int num5 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 269, base.projectile.velocity.X, base.projectile.velocity.Y, 0, default(Color), 1f);
			Main.dust[num5].velocity /= 15f;
			Main.dust[num5].scale = 1.1f;
			int num6 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 269, base.projectile.velocity.X, base.projectile.velocity.Y, 0, default(Color), 1f);
			Main.dust[num6].velocity /= 15f;
			Main.dust[num6].scale = 1.1f;
			int num7 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 269, base.projectile.velocity.X, base.projectile.velocity.Y, 0, default(Color), 1f);
			Main.dust[num7].velocity /= 15f;
			Main.dust[num7].scale = 1.1f;
			int num8 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 269, base.projectile.velocity.X, base.projectile.velocity.Y, 0, default(Color), 1f);
			Main.dust[num8].velocity /= 15f;
			Main.dust[num8].scale = 1.1f;
			int num9 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 269, base.projectile.velocity.X, base.projectile.velocity.Y, 0, default(Color), 1f);
			Main.dust[num9].velocity /= 15f;
			Main.dust[num9].scale = 1.1f;
			int num10 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 269, base.projectile.velocity.X, base.projectile.velocity.Y, 0, default(Color), 1f);
			Main.dust[num10].velocity /= 15f;
			Main.dust[num10].scale = 1.1f;
		}
	}
}
