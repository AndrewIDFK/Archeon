using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x02000062 RID: 98
	public class RockSteeleBulletShot : ModProjectile
	{
		// Token: 0x060001AF RID: 431 RVA: 0x0000F18A File Offset: 0x0000D38A
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("RockSteele Bullet");
			ProjectileID.Sets.TrailCacheLength[base.projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[base.projectile.type] = 0;
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x0000F1C0 File Offset: 0x0000D3C0
		public override void SetDefaults()
		{
			base.projectile.width = 8;
			base.projectile.height = 8;
			base.projectile.aiStyle = 1;
			base.projectile.friendly = true;
			base.projectile.hostile = false;
			base.projectile.ranged = true;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft = 4444;
			base.projectile.alpha = 255;
			base.projectile.light = 0.4f;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = true;
			base.projectile.extraUpdates = 1;
			this.aiType = 14;
		}
		
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.3f, 0.485f, 0.61f);
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x0000F280 File Offset: 0x0000D480
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(SoundID.Item10, base.projectile.position);
		}
	}
}
