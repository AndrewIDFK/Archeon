using System;
using Archeon.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x0200004C RID: 76
	public class CoolSwordShot : ModProjectile
	{
		// Token: 0x06000147 RID: 327 RVA: 0x00008A68 File Offset: 0x00006C68
		public override void SetDefaults()
		{
			base.projectile.extraUpdates = 0;
			base.projectile.width = 16;
			base.projectile.height = 16;
			base.projectile.aiStyle = 27;
			base.projectile.friendly = true;
			base.projectile.penetrate = 3;
			base.projectile.melee = true;
			base.projectile.soundDelay = 3;
			Main.PlaySound(SoundID.Item69, base.projectile.position);
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00008AF0 File Offset: 0x00006CF0
		public override void AI()
		{
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("LunarDust"), base.projectile.velocity.X * -0.5f, base.projectile.velocity.Y * -0.5f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 80f;
			Main.dust[num].scale = 0.6f;
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00008BAC File Offset: 0x00006DAC
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item10, base.projectile.position);
			for (int i = 0; i < 5; i++)
			{
				Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, DustType<LunarDust>(), 0f, 0f, 0, default(Color), 1f);
			}
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00008C26 File Offset: 0x00006E26
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[base.projectile.owner] = 2;
			target.AddBuff(base.mod.BuffType("LunarDebuff"), 300, false);
		}
	}
}
