using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x02000357 RID: 855
	public class ShroomSharkFlame : ModProjectile
	{
		// Token: 0x060012F7 RID: 4855 RVA: 0x0007E1A7 File Offset: 0x0007C3A7
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Shroomshark Flame");
		}

		// Token: 0x060012F8 RID: 4856 RVA: 0x000F3F04 File Offset: 0x000F2104
		public override void SetDefaults()
		{
			base.projectile.width = 10;
			base.projectile.height = 10;
			base.projectile.friendly = true;
			base.projectile.ignoreWater = true;
			base.projectile.ranged = true;
			base.projectile.penetrate = -1;
			base.projectile.extraUpdates = 3;
			base.projectile.timeLeft = 72;
			projectile.hide = true;
		}

		// Token: 0x060012F9 RID: 4857 RVA: 0x000F3F6C File Offset: 0x000F216C
		public override void AI()
		{
			if (base.projectile.scale <= 1.2f)
			{
				base.projectile.scale *= 1.45f;
			}
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.25f / 255f, (float)(255 - base.projectile.alpha) * 0.05f / 255f, (float)(255 - base.projectile.alpha) * 0.05f / 255f);
			if (base.projectile.timeLeft > 90)
			{
				base.projectile.timeLeft = 90;
			}
			if (base.projectile.ai[0] > 7f)
			{
				float num = 1f;
				if (base.projectile.ai[0] == 8f)
				{
					num = 0.25f;
				}
				else if (base.projectile.ai[0] == 9f)
				{
					num = 0.5f;
				}
				else if (base.projectile.ai[0] == 10f)
				{
					num = 0.75f;
				}
				base.projectile.ai[0] += 1f;
				int type = 59;
				if (Main.rand.Next(2) == 0)
				{
					for (int i = 0; i < 1; i++)
					{
						int num2 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, type, base.projectile.velocity.X * 0.2f, base.projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
						if (Main.rand.Next(3) == 0)
						{
							Main.dust[num2].noGravity = true;
							Main.dust[num2].scale *= 4.15f;
							Dust dust = Main.dust[num2];
							dust.velocity.X = dust.velocity.X * 2f;
							Dust dust2 = Main.dust[num2];
							dust2.velocity.Y = dust2.velocity.Y * 2f;
						}
						else
						{
							Main.dust[num2].scale *= 3.45f;
							Main.dust[num2].noGravity = true;
						}
						Dust dust3 = Main.dust[num2];
						dust3.velocity.X = dust3.velocity.X * 1.2f;
						Dust dust4 = Main.dust[num2];
						dust4.velocity.Y = dust4.velocity.Y * 1.2f;
						Main.dust[num2].scale *= num;
						Main.dust[num2].velocity += base.projectile.velocity;
						if (!Main.dust[num2].noGravity)
						{
							Main.dust[num2].velocity *= 0.5f;
						}
					}
				}
			}
			else
			{
				base.projectile.ai[0] += 1f;
			}
			base.projectile.rotation += 0.3f * (float)base.projectile.direction;
		}

		

		// Token: 0x060012FB RID: 4859 RVA: 0x000F4138 File Offset: 0x000F2338
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int num2 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, mod.DustType("ShroomSharkFlameDust"), base.projectile.oldVelocity.X * 0.5f, base.projectile.oldVelocity.Y * 0.5f, 0, default(Color), 1f);
				Main.dust[num2].noGravity = true;
			}
		}

		// Token: 0x060012FC RID: 4860 RVA: 0x000F41C5 File Offset: 0x000F23C5
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[base.projectile.owner] = 5;
			
		}
	}
}
