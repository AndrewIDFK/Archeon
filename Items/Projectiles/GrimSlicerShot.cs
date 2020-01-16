using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x02000056 RID: 86
	public class GrimSlicerShot : ModProjectile
	{
		// Token: 0x06000177 RID: 375 RVA: 0x0000B7A4 File Offset: 0x000099A4
		public override void SetDefaults()
		{
			base.projectile.width = 32;
			base.projectile.height = 32;
			base.projectile.aiStyle = 3;
			base.projectile.friendly = true;
			base.projectile.ranged = true;
			base.projectile.magic = false;
			base.projectile.penetrate = -1;
			base.projectile.extraUpdates = 1;
		}

		// Token: 0x06000178 RID: 376 RVA: 0x0000B814 File Offset: 0x00009A14
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.475f, 0.02f, 0.015f);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 90, base.projectile.velocity.X * -0.5f, base.projectile.velocity.Y * -0.5f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 60f;
			Main.dust[num].scale = 0.4f;
		}
	}
}
