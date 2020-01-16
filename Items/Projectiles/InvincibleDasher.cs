using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x0200022F RID: 559
	public class InvincibleDasher : ModProjectile
	{
		// Token: 0x06000C63 RID: 3171 RVA: 0x0008B581 File Offset: 0x00089781
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("RockSteele Shard");
		}

		// Token: 0x06000C64 RID: 3172 RVA: 0x0008B594 File Offset: 0x00089794
		public override void SetDefaults()
		{
			base.projectile.width = 12;
			base.projectile.height = 12;
			base.projectile.scale = 1.1f;
			base.projectile.friendly = true;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 24;
			base.projectile.melee = true;
			base.projectile.hide = true;
		}

		// Token: 0x06000C65 RID: 3173 RVA: 0x0008B60C File Offset: 0x0008980C
		public override void AI()
		{
			Projectile projectile = base.projectile;
			projectile.velocity.X = projectile.velocity.X + base.projectile.ai[0];
			Projectile projectile2 = base.projectile;
			projectile2.velocity.Y = projectile2.velocity.Y + base.projectile.ai[1];
			if (Main.rand.NextFloat() < 1f)
			{
				Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("AirElementDust"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			}
		}
	}
}
