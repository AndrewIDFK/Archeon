using System;
using Archeon.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x0200004E RID: 78
	public class CoolSwordStar2 : ModProjectile
	{
		// Token: 0x06000150 RID: 336 RVA: 0x00008D1F File Offset: 0x00006F1F
		public override void SetDefaults()
		{
			base.projectile.CloneDefaults(503);
			this.aiType = 503;
			base.projectile.penetrate = 1;
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00008D48 File Offset: 0x00006F48
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item10, base.projectile.position);
			for (int i = 0; i < 5; i++)
			{
				Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, DustType<LunarDust>(), 0f, 0f, 0, default(Color), 1f);
			}
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00008DC2 File Offset: 0x00006FC2
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[base.projectile.owner] = 0;
		}

	}
}
