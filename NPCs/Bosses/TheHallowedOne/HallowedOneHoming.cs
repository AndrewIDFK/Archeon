using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.NPCs.Bosses.TheHallowedOne
{
	// Token: 0x020005AB RID: 1451
	public class HallowedOneHoming : ModProjectile
	{
		// Token: 0x060020B0 RID: 8368 RVA: 0x001A3B34 File Offset: 0x001A1D34
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Hallowed Homer");
		}

		// Token: 0x060020B1 RID: 8369 RVA: 0x001A3B48 File Offset: 0x001A1D48
		public override void SetDefaults()
		{
			base.projectile.width = 10;
			base.projectile.height = 14;
			base.projectile.hostile = true;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 375;
			projectile.scale = 1.35f;
		}

		
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.49f, 0.87f, 1.22f);
			int num21 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("HallowedHomingDust"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num21].velocity /= 160f;
			Main.dust[num21].scale = 1.05f;
			

			base.projectile.ai[1] += 1f;
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + 1.57f;
			float num = 85f;
			float scaleFactor = 15f;
			float num2 = 55f;
			if (base.projectile.alpha > 0)
			{
				base.projectile.alpha -= 10;
			}
			if (base.projectile.alpha < 0)
			{
				base.projectile.alpha = 0;
			}
			
			int num3 = (int)base.projectile.ai[0];
			if (num3 >= 0 && Main.player[num3].active && !Main.player[num3].dead)
			{
				if (base.projectile.Distance(Main.player[num3].Center) > num2)
				{
					Vector2 vector = base.projectile.DirectionTo(Main.player[num3].Center);
					if (vector.HasNaNs())
					{
						vector = Vector2.UnitY;
					}
					base.projectile.velocity = (base.projectile.velocity * (num - 1f) + vector * scaleFactor) / num;
					return;
				}
			}
			else
			{
				if (base.projectile.timeLeft > 30)
				{
					base.projectile.timeLeft = 30;
				}
				if (base.projectile.ai[0] != -1f)
				{
					base.projectile.ai[0] = -1f;
					base.projectile.netUpdate = true;
					return;
				}
			}
		}
		// Token: 0x060015C2 RID: 5570 RVA: 0x0011CCC0 File Offset: 0x0011AEC0
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(SoundID.Item38, base.projectile.position);
			for (int i = 0; i < 8; i++)
			{
				Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("HallowedHomingDust"), base.projectile.oldVelocity.X * 1.1f, base.projectile.oldVelocity.Y * 1.1f, 0, default(Color), 1f);
				Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("StroidDust2"), base.projectile.oldVelocity.X * 1.1f, base.projectile.oldVelocity.Y * 1.1f, 0, default(Color), 1f);
			}
			
			
		}
	}
}
