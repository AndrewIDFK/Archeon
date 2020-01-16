using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x0200005B RID: 91
	public class LunarPhantomArrowHoming : ModProjectile
	{
		// Token: 0x0600018E RID: 398 RVA: 0x0000C610 File Offset: 0x0000A810
		public override void SetDefaults()
		{
			base.projectile.width = 8;
			base.projectile.height = 8;
			base.projectile.friendly = true;
			base.projectile.hostile = false;
			base.projectile.tileCollide = true;
			base.projectile.ignoreWater = true;
			base.projectile.ranged = true;
			base.projectile.penetrate = 1;
			base.projectile.aiStyle = 0;
			base.projectile.scale = 1.15f;
		}

		// Token: 0x0600018F RID: 399 RVA: 0x0000C69C File Offset: 0x0000A89C
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.3f, 0.505f, 0.61f);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("LunarDust"), base.projectile.velocity.X * -0.5f, base.projectile.velocity.Y * -0.5f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 80f;
			Main.dust[num].scale = 0.4f;
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + MathHelper.ToRadians(270f);
			float num2 = (float)Math.Sqrt((double)(base.projectile.velocity.X * base.projectile.velocity.X + base.projectile.velocity.Y * base.projectile.velocity.Y));
			float num3 = base.projectile.localAI[0];
			if (num3 == 0f)
			{
				base.projectile.localAI[0] = num2;
				num3 = num2;
			}
			float num4 = base.projectile.position.X;
			float num5 = base.projectile.position.Y;
			float num6 = 300f;
			bool flag = false;
			int num7 = 0;
			if (base.projectile.ai[1] == 0f)
			{
				for (int i = 0; i < 200; i++)
				{
					if (Main.npc[i].CanBeChasedBy(this, false) && (base.projectile.ai[1] == 0f || base.projectile.ai[1] == (float)(i + 1)))
					{
						float num8 = Main.npc[i].position.X + (float)(Main.npc[i].width / 2);
						float num9 = Main.npc[i].position.Y + (float)(Main.npc[i].height / 2);
						float num10 = Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num8) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num9);
						if (num10 < num6 && Collision.CanHit(new Vector2(base.projectile.position.X + (float)(base.projectile.width / 2), base.projectile.position.Y + (float)(base.projectile.height / 2)), 1, 1, Main.npc[i].position, Main.npc[i].width, Main.npc[i].height))
						{
							num6 = num10;
							num4 = num8;
							num5 = num9;
							flag = true;
							num7 = i;
						}
					}
				}
				if (flag)
				{
					base.projectile.ai[1] = (float)(num7 + 1);
				}
				flag = false;
			}
			if (base.projectile.ai[1] > 0f)
			{
				int num11 = (int)(base.projectile.ai[1] - 1f);
				if (Main.npc[num11].active && Main.npc[num11].CanBeChasedBy(this, true) && !Main.npc[num11].dontTakeDamage)
				{
					float num12 = Main.npc[num11].position.X + (float)(Main.npc[num11].width / 2);
					float num13 = Main.npc[num11].position.Y + (float)(Main.npc[num11].height / 2);
					if (Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num12) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num13) < 1000f)
					{
						flag = true;
						num4 = Main.npc[num11].position.X + (float)(Main.npc[num11].width / 2);
						num5 = Main.npc[num11].position.Y + (float)(Main.npc[num11].height / 2);
					}
				}
				else
				{
					base.projectile.ai[1] = 0f;
				}
			}
			if (!base.projectile.friendly)
			{
				flag = false;
			}
			if (flag)
			{
				float num14 = num3;
				Vector2 vector = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
				float num15 = num4 - vector.X;
				float num16 = num5 - vector.Y;
				float num17 = (float)Math.Sqrt((double)(num15 * num15 + num16 * num16));
				num17 = num14 / num17;
				num15 *= num17;
				num16 *= num17;
				int num18 = 8;
				base.projectile.velocity.X = (base.projectile.velocity.X * (float)(num18 - 1) + num15) / (float)num18;
				base.projectile.velocity.Y = (base.projectile.velocity.Y * (float)(num18 - 1) + num16) / (float)num18;
			}
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0000CC74 File Offset: 0x0000AE74
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(SoundID.Item10, base.projectile.position);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("LunarDust"), base.projectile.velocity.X * -30.2f, base.projectile.velocity.Y * -14.7f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 80f;
			Main.dust[num].scale = 1.1f;
			int num2 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("LunarDust"), base.projectile.velocity.X * -10.4f, base.projectile.velocity.Y * 2.9f, 0, default(Color), 1f);
			Main.dust[num2].velocity /= 80f;
			Main.dust[num2].scale = 1.1f;
			int num3 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("LunarDust"), base.projectile.velocity.X * 30.9f, base.projectile.velocity.Y * -21.9f, 0, default(Color), 1f);
			Main.dust[num3].velocity /= 80f;
			Main.dust[num3].scale = 1.1f;
			int num4 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("LunarDust"), base.projectile.velocity.X * -22.4f, base.projectile.velocity.Y * 11.6f, 0, default(Color), 1f);
			Main.dust[num4].velocity /= 80f;
			Main.dust[num4].scale = 1.1f;
			int num5 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("LunarDust"), base.projectile.velocity.X * -20.2f, base.projectile.velocity.Y * -10.7f, 0, default(Color), 1f);
			Main.dust[num5].velocity /= 80f;
			Main.dust[num5].scale = 1.1f;
		}
	}
}
