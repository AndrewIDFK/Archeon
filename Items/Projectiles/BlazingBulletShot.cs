using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x0200004A RID: 74
	public class BlazingBulletShot : ModProjectile
	{
		// Token: 0x0600013E RID: 318 RVA: 0x00008805 File Offset: 0x00006A05
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Blazing Bullet");
			ProjectileID.Sets.TrailCacheLength[base.projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[base.projectile.type] = 0;
		}

		// Token: 0x0600013F RID: 319 RVA: 0x0000883C File Offset: 0x00006A3C
		public override void SetDefaults()
		{
			base.projectile.width = 8;
			base.projectile.height = 20;
			base.projectile.aiStyle = 1;
			base.projectile.friendly = true;
			base.projectile.hostile = false;
			base.projectile.ranged = true;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 60000;
			base.projectile.alpha = 255;
			base.projectile.light = 0.55f;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = true;
			base.projectile.extraUpdates = 1;
			this.aiType = 14;
		}
		
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 1.13f, 0.2f, 0.24f);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("FlamebrandDust"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 100f;
			Main.dust[num].scale = 0.45f;
			Main.dust[num].noGravity = true;
			int num2 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("FlamebrandDust"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num2].velocity /= 100f;
			Main.dust[num2].scale = 0.52f;
			Main.dust[num2].noGravity = true;
		}

		// Token: 0x06000140 RID: 320 RVA: 0x000088FA File Offset: 0x00006AFA
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(24, 180, false);
		}

		// Token: 0x06000141 RID: 321 RVA: 0x0000890C File Offset: 0x00006B0C
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(SoundID.Item10, base.projectile.position);
		}
	}
}
