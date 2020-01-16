using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x02000050 RID: 80
	public class DarkSlicerShot : ModProjectile
	{
		// Token: 0x0600015C RID: 348 RVA: 0x00009638 File Offset: 0x00007838
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

		// Token: 0x0600015D RID: 349 RVA: 0x000096A8 File Offset: 0x000078A8
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.125f, 0.035f, 0.575f);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 179, base.projectile.velocity.X * -0.5f, base.projectile.velocity.Y * -0.5f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 60f;
			Main.dust[num].scale = 0.4f;
		}
	}
}
