using System;
using Archeon.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x02000070 RID: 112
	public class UpperChargeShot : ModProjectile
	{
		// Token: 0x060001DD RID: 477 RVA: 0x000105AF File Offset: 0x0000E7AF
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Flaming UpCharger");
		}

		// Token: 0x060001DE RID: 478 RVA: 0x000105C4 File Offset: 0x0000E7C4
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

		// Token: 0x060001DF RID: 479 RVA: 0x00010640 File Offset: 0x0000E840
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.8f, 0.2f, 1.55f);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("UpperChargeDust"), base.projectile.velocity.X * -0.5f, base.projectile.velocity.Y * -0.5f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 80f;
			Main.dust[num].scale = 1.15f;
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + 1.57f;  //base.mod.DustType("UpperChargeDust")
			base.projectile.localAI[0] += 1f;
			if (base.projectile.localAI[0] > 260f)
			{
				base.projectile.Kill();
			}
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x00010798 File Offset: 0x0000E998
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item10, base.projectile.position);
			for (int i = 0; i < 5; i++)
			{
				Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, DustType<UpperChargeDust>(), 0f, 0f, 0, default(Color), 1f);
			}       																					//DustType<UpperChargeDust>()
		}
	}
}
