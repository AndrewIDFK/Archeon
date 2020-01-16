using System;
using Archeon.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x02000061 RID: 97
	public class RainChargeShot : ModProjectile
	{
		// Token: 0x060001AA RID: 426 RVA: 0x0000EF1F File Offset: 0x0000D11F
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Flaming RainCharger");
		}

		// Token: 0x060001AB RID: 427 RVA: 0x0000EF34 File Offset: 0x0000D134
		public override void SetDefaults()
		{
			base.projectile.width = 12;
			base.projectile.height = 12;
			base.projectile.friendly = true;
			base.projectile.penetrate = 1;
			base.projectile.hostile = false;
			base.projectile.magic = true;
			base.projectile.tileCollide = false;
			base.projectile.ignoreWater = true;
			base.projectile.hide = true;
		}

		// Token: 0x060001AC RID: 428 RVA: 0x0000EFB0 File Offset: 0x0000D1B0
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.62f, 0.84f, 2.15f);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("RainChargeDust"), base.projectile.velocity.X * -0.5f, base.projectile.velocity.Y * -0.5f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 80f;
			Main.dust[num].scale = 1.25f;
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + 1.57f; //base.mod.DustType("RainChargeDust")
			base.projectile.localAI[0] += 1f;
			if (base.projectile.localAI[0] > 260f)
			{
				base.projectile.Kill();
			}
		}

		// Token: 0x060001AD RID: 429 RVA: 0x0000F108 File Offset: 0x0000D308
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item10, base.projectile.position);
			for (int i = 0; i < 4; i++)
			{
				Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, DustType<RainChargeDust>(), 0f, 0f, 0, default(Color), 1f);
			}																						//DustType<RainChargeDust>()
		}
	}
}
