using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x0200004A RID: 74
	public class ShroomiteBulletShot : ModProjectile
	{
		// Token: 0x0600013E RID: 318 RVA: 0x00008805 File Offset: 0x00006A05
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Shroomite Bullet");
			ProjectileID.Sets.TrailCacheLength[base.projectile.type] = 8;
			ProjectileID.Sets.TrailingMode[base.projectile.type] = 1;
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
			base.projectile.timeLeft = 720;
			base.projectile.alpha = 255;
			base.projectile.light = 0.65f;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = true;
			base.projectile.extraUpdates = 1;
			this.aiType = 14;
		}
		
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.13f, 0.2f, 0.65f);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 59, base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 100f;
			Main.dust[num].scale = 0.55f;
			Main.dust[num].noGravity = true;
		}

		

		// Token: 0x06000141 RID: 321 RVA: 0x0000890C File Offset: 0x00006B0C
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(SoundID.Item10, base.projectile.position);
		}
	}
}
