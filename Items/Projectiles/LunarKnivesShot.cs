using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x02000058 RID: 88
	public class LunarKnivesShot : ModProjectile
	{
		// Token: 0x06000180 RID: 384 RVA: 0x0000BAF0 File Offset: 0x00009CF0
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Lunar Knife");
		}

		// Token: 0x06000181 RID: 385 RVA: 0x0000BB04 File Offset: 0x00009D04
		public override void SetDefaults()
		{
			base.projectile.width = 20;
			base.projectile.height = 20;
			base.projectile.aiStyle = 2;
			base.projectile.friendly = true;
			base.projectile.hostile = false;
			base.projectile.ranged = true;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 39;
			base.projectile.light = 0.4f;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = true;
			base.projectile.extraUpdates = 0;
			this.aiType = 304;
		}

		// Token: 0x06000182 RID: 386 RVA: 0x0000BBB4 File Offset: 0x00009DB4
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.3f, 0.505f, 0.61f);
			base.projectile.ai[0] += 1f;
			if (base.projectile.ai[0] > 50f)
			{
				base.projectile.alpha += 25;
				if (base.projectile.alpha > 255)
				{
					base.projectile.alpha = 255;
					return;
				}
			}
			else
			{
				base.projectile.alpha -= 21;
				if (base.projectile.alpha < 100)
				{
					base.projectile.alpha = 100;
				}
			}
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000BC80 File Offset: 0x00009E80
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(SoundID.Item10, base.projectile.position);
		}
	}
}
