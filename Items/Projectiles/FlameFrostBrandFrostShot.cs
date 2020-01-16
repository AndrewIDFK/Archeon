using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x02000054 RID: 84
	public class FlameFrostBrandFrostShot : ModProjectile
	{
		// Token: 0x0600016E RID: 366 RVA: 0x0000AEBC File Offset: 0x000090BC
		public override void SetDefaults()
		{
			base.projectile.scale = 1.3f;
			base.projectile.extraUpdates = 0;
			base.projectile.width = 18;
			base.projectile.height = 18;
			base.projectile.aiStyle = 27;
			base.projectile.friendly = true;
			base.projectile.penetrate = 1;
			base.projectile.melee = true;
			Main.PlaySound(SoundID.Item15, base.projectile.position);
			base.projectile.hide = true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(44, 480, false);
		}
		
		// Token: 0x0600016F RID: 367 RVA: 0x0000AF54 File Offset: 0x00009154
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 1.09f, 0.37f, 0.23f);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("FlameFrostBrandFrostDust"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 160f;
			Main.dust[num].scale = 1.45f;
			int num2 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("FlameFrostBrandFrostDust"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num2].velocity /= 160f;
			Main.dust[num2].scale = 1.45f;
			int num3 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("FlameFrostBrandFrostDust"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num3].velocity /= 160f;
			Main.dust[num3].scale = 1.45f;
		}

		// Token: 0x06000170 RID: 368 RVA: 0x0000B190 File Offset: 0x00009390
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(SoundID.Item10, base.projectile.position);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 186, base.projectile.velocity.X, base.projectile.velocity.Y, 0, default(Color), 1f);
			Main.dust[num].velocity /= 15f;
			Main.dust[num].scale = 1.1f;
			int num2 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 186, base.projectile.velocity.X, base.projectile.velocity.Y, 0, default(Color), 1f);
			Main.dust[num2].velocity /= 15f;
			Main.dust[num2].scale = 1.1f;
			int num3 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 186, base.projectile.velocity.X, base.projectile.velocity.Y, 0, default(Color), 1f);
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
		}
	}
}
