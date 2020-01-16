using System;
using Archeon.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x0200004D RID: 77
	public class CoolSwordStar : ModProjectile
	{
		// Token: 0x0600014C RID: 332 RVA: 0x00008C5F File Offset: 0x00006E5F
		public override void SetDefaults()
		{
			base.projectile.CloneDefaults(503);
			this.aiType = 503;
			base.projectile.penetrate = 1;
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00008C88 File Offset: 0x00006E88
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item10, base.projectile.position);
			for (int i = 0; i < 5; i++)
			{
				Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, DustType<LunarDust>(), 0f, 0f, 0, default(Color), 1f);
			}
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00008D02 File Offset: 0x00006F02
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[base.projectile.owner] = 1;
		}
	}
}
