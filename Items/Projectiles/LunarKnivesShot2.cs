using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x02000059 RID: 89
	public class LunarKnivesShot2 : ModProjectile
	{
		// Token: 0x06000185 RID: 389 RVA: 0x0000BCDC File Offset: 0x00009EDC
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Lunar Knives Knife 2");
		}

		// Token: 0x06000186 RID: 390 RVA: 0x0000BCF0 File Offset: 0x00009EF0
		public override void SetDefaults()
		{
			base.projectile.width = 16;
			base.projectile.height = 20;
			base.projectile.aiStyle = 1;
			base.projectile.friendly = true;
			base.projectile.hostile = false;
			base.projectile.ranged = true;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 300;
			base.projectile.light = 0.4f;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = true;
			base.projectile.extraUpdates = 0;
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0000BD98 File Offset: 0x00009F98
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.3f, 0.5f, 1.56f);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 15, base.projectile.velocity.X * -0.5f, base.projectile.velocity.Y * -0.5f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 50f;
			Main.dust[num].scale = 0.3f;
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0000BE68 File Offset: 0x0000A068
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(SoundID.Item10, base.projectile.position);
		}
	}
}
