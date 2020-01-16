using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles.Minions
{
	// Token: 0x02000279 RID: 633
	public class DarkMatterTornado1 : ModProjectile
	{
		// Token: 0x06000DFD RID: 3581 RVA: 0x000ADB0C File Offset: 0x000ABD0C
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Shadow's Cyclone");
			Main.projFrames[base.projectile.type] = 6;
			ProjectileID.Sets.MinionSacrificable[base.projectile.type] = true;
			ProjectileID.Sets.MinionTargettingFeature[base.projectile.type] = true;
		}

		// Token: 0x06000DFE RID: 3582 RVA: 0x000ADB60 File Offset: 0x000ABD60
		public override void SetDefaults()
		{
			base.projectile.width = 42;
			base.projectile.height = 42;
			base.projectile.netImportant = true;
			base.projectile.friendly = true;
			base.projectile.ignoreWater = true;
			base.projectile.minionSlots = 0.5f;
			base.projectile.timeLeft = 25000;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft *= 5;
			base.projectile.minion = true;
			base.projectile.tileCollide = false;
			base.projectile.usesLocalNPCImmunity = true;
			base.projectile.localNPCHitCooldown = 12;
		}

		// Token: 0x06000DFF RID: 3583 RVA: 0x000ADC1C File Offset: 0x000ABE1C
		public override void AI()
		{
			if (base.projectile.localAI[1] == 0f)
			{
				
				int num = 28;
				for (int i = 0; i < num; i++)
				{
					Vector2 value = (Vector2.Normalize(base.projectile.velocity) * new Vector2((float)base.projectile.width / 2f, (float)base.projectile.height) * 0.75f).RotatedBy((double)((float)(i - (num / 2 - 1)) * 6.28318548f / (float)num), default(Vector2)) + base.projectile.Center;
					Vector2 vector = value - base.projectile.Center;
					int num2 = Dust.NewDust(value + vector, 0, 0, base.mod.DustType("DarkMatterDust1"), vector.X * 1.5f, vector.Y * 1.5f, 100, default(Color), 1.4f);
					Main.dust[num2].noGravity = true;
					Main.dust[num2].noLight = true;
					Main.dust[num2].velocity = vector;
				}
				base.projectile.localAI[1] += 1f;
			}
			
			int num666 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, base.mod.DustType("DarkMatterDust1"), 0f, 0f, 0, default(Color), 1f);
			Main.dust[num666].velocity *= 0.1f;
			Main.dust[num666].scale = 1.4f;
			Main.dust[num666].noGravity = true;
			
			bool flag = base.projectile.type == base.mod.ProjectileType("DarkMatterTornado1");
			Player player = Main.player[base.projectile.owner];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			player.AddBuff(base.mod.BuffType("DarkMatterTornadoBuff"), 3600, true);
			if (flag)
			{
				if (player.dead)
				{
					modPlayer.DarkMatterTornado = false;
				}
				if (modPlayer.DarkMatterTornado)
				{
					base.projectile.timeLeft = 2;
				}
			}
			float num3 = 0.2f;
			float num4 = (float)base.projectile.width * 2f;
			for (int j = 0; j < 1000; j++)
			{
				if (j != base.projectile.whoAmI && Main.projectile[j].active && Main.projectile[j].owner == base.projectile.owner && Main.projectile[j].type == base.projectile.type && Math.Abs(base.projectile.position.X - Main.projectile[j].position.X) + Math.Abs(base.projectile.position.Y - Main.projectile[j].position.Y) < num4)
				{
					if (base.projectile.position.X < Main.projectile[j].position.X)
					{
						base.projectile.velocity.X = base.projectile.velocity.X - num3;
					}
					else
					{
						base.projectile.velocity.X = base.projectile.velocity.X + num3;
					}
					if (base.projectile.position.Y < Main.projectile[j].position.Y)
					{
						base.projectile.velocity.Y = base.projectile.velocity.Y - num3;
					}
					else
					{
						base.projectile.velocity.Y = base.projectile.velocity.Y + num3;
					}
				}
			}
			Vector2 vector2 = base.projectile.position;
			float num5 = 400f;
			bool flag2 = false;
			if (Collision.SolidCollision(base.projectile.position, base.projectile.width, base.projectile.height))
			{
				base.projectile.alpha += 20;
				if (base.projectile.alpha > 150)
				{
					base.projectile.alpha = 150;
				}
			}
			else
			{
				base.projectile.alpha -= 50;
				if (base.projectile.alpha < 60)
				{
					base.projectile.alpha = 60;
				}
			}
			Vector2 center = Main.player[base.projectile.owner].Center;
			Vector2 value2 = new Vector2(0.5f);
			if (player.HasMinionAttackTargetNPC)
			{
				NPC npc = Main.npc[player.MinionAttackTargetNPC];
				if (npc.CanBeChasedBy(base.projectile, false))
				{
					Vector2 vector3 = npc.position + npc.Size * value2;
					float num6 = Vector2.Distance(vector3, center);
					if (((Vector2.Distance(center, vector2) > num6 && num6 < num5) || !flag2) && Collision.CanHitLine(base.projectile.position, base.projectile.width, base.projectile.height, npc.position, npc.width, npc.height))
					{
						vector2 = vector3;
						flag2 = true;
						int whoAmI = npc.whoAmI;
					}
				}
			}
			else
			{
				for (int k = 0; k < 200; k++)
				{
					NPC npc2 = Main.npc[k];
					if (npc2.CanBeChasedBy(base.projectile, false))
					{
						Vector2 vector4 = npc2.position + npc2.Size * value2;
						float num7 = Vector2.Distance(vector4, center);
						if (((Vector2.Distance(center, vector2) > num7 && num7 < num5) || !flag2) && Collision.CanHitLine(base.projectile.position, base.projectile.width, base.projectile.height, npc2.position, npc2.width, npc2.height))
						{
							num5 = num7;
							vector2 = vector4;
							flag2 = true;
						}
					}
				}
			}
			int num8 = 400;
			if (flag2)
			{
				num8 = 900;
			}
			if (Vector2.Distance(player.Center, base.projectile.Center) > (float)num8)
			{
				base.projectile.ai[0] = 1f;
				base.projectile.netUpdate = true;
			}
			if (flag2 && base.projectile.ai[0] == 0f)
			{
				Vector2 vector5 = vector2 - base.projectile.Center;
				float num9 = vector5.Length();
				vector5.Normalize();
				if (num9 > 400f)
				{
					float scaleFactor = 4f;
					vector5 *= scaleFactor;
					base.projectile.velocity = (base.projectile.velocity * 20f + vector5) / 21f;
				}
				else
				{
					base.projectile.velocity *= 0.87f;
				}
				if (num9 > 200f)
				{
					float scaleFactor2 = 7f;
					vector5 *= scaleFactor2;
					base.projectile.velocity.X = (base.projectile.velocity.X * 40f + vector5.X) / 41f;
					base.projectile.velocity.Y = (base.projectile.velocity.Y * 40f + vector5.Y) / 41f;
				}
				if (base.projectile.velocity.Y > -1f)
				{
					base.projectile.velocity.Y = base.projectile.velocity.Y - 0.48f;
				}
			}
			else
			{
				if (!Collision.CanHitLine(base.projectile.Center, 1, 1, Main.player[base.projectile.owner].Center, 1, 1))
				{
					base.projectile.ai[0] = 1f;
				}
				float num10 = 11f;
				Vector2 center2 = base.projectile.Center;
				Vector2 vector6 = player.Center - center2 + new Vector2(0f, -60f) + new Vector2(0f, 40f);
				float num11 = vector6.Length();
				if (num11 > 200f && num10 < 9f)
				{
					num10 = 10f;
				}
				if (num11 < 100f && base.projectile.ai[0] == 1f && !Collision.SolidCollision(base.projectile.position, base.projectile.width, base.projectile.height))
				{
					base.projectile.ai[0] = 0f;
					base.projectile.netUpdate = true;
				}
				if (num11 > 2000f)
				{
					base.projectile.position.X = Main.player[base.projectile.owner].Center.X - (float)(base.projectile.width / 2);
					base.projectile.position.Y = Main.player[base.projectile.owner].Center.Y - (float)(base.projectile.width / 2);
				}
				if (Math.Abs(vector6.X) > 40f || Math.Abs(vector6.Y) > 10f)
				{
					vector6.Normalize();
					vector6 *= num10;
					vector6 *= new Vector2(1.25f, 0.65f);
					base.projectile.velocity = (base.projectile.velocity * 20f + vector6) / 21f;
				}
				else
				{
					if (base.projectile.velocity.X == 0f && base.projectile.velocity.Y == 0f)
					{
						base.projectile.velocity.X = -0.11f;
						base.projectile.velocity.Y = -0.06f;
					}
					base.projectile.velocity *= 0.95f;
				}
			}
			base.projectile.rotation = base.projectile.velocity.X * 0.05f;
			base.projectile.frameCounter++;
			int num12 = 2;
			if (base.projectile.frameCounter >= 6 * num12)
			{
				base.projectile.frameCounter = 0;
			}
			base.projectile.frame = base.projectile.frameCounter / num12;
			if (Main.rand.Next(4) == 0)
			{
				int num13 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, base.mod.DustType("DarkMatterDust1"), 0f, 0f, 100, default(Color), 2f);
				Main.dust[num13].velocity *= 0.4f;
				Main.dust[num13].noGravity = true;
				Main.dust[num13].noLight = true;
			}
			if (base.projectile.velocity.X > 0f)
			{
				base.projectile.spriteDirection = (base.projectile.direction = -1);
			}
			else if (base.projectile.velocity.X < 0f)
			{
				base.projectile.spriteDirection = (base.projectile.direction = 1);
			}
			if (base.projectile.ai[1] > 0f)
			{
				base.projectile.ai[1] += 1f;
				if (Main.rand.Next(3) != 0)
				{
					base.projectile.ai[1] += 1f;
				}
			}
			if (base.projectile.ai[1] > 60f)
			{
				base.projectile.ai[1] = 0f;
				base.projectile.netUpdate = true;
			}
			
			if (base.projectile.ai[0] == 0f)
			{
				float scaleFactor3 = 9f;
				int type = base.mod.ProjectileType("DarkMatterTornadoShot2");
				if (flag2 && !Collision.SolidCollision(base.projectile.position, base.projectile.width, base.projectile.height) && base.projectile.ai[1] == 0f)
				{
					base.projectile.ai[1] += 1f;
					if (Main.myPlayer == base.projectile.owner)
					{
						Vector2 vector7 = vector2 - base.projectile.Center;
						vector7.Normalize();
						vector7 *= scaleFactor3;
						int num14 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, vector7.X - 6, vector7.Y - 6, type, base.projectile.damage, 0f, Main.myPlayer, 0f, 0f);
						Main.projectile[num14].timeLeft = 140;
						Main.projectile[num14].netUpdate = true;
						
						int num16 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, vector7.X - 2, vector7.Y - 2, type, base.projectile.damage, 0f, Main.myPlayer, 0f, 0f);
						Main.projectile[num16].timeLeft = 140;
						
						int num17 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, vector7.X + 2, vector7.Y + 2, type, base.projectile.damage, 0f, Main.myPlayer, 0f, 0f);
						Main.projectile[num17].timeLeft = 140;
						
						int num18 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, vector7.X + 6, vector7.Y + 6, type, base.projectile.damage, 0f, Main.myPlayer, 0f, 0f);
						Main.projectile[num18].timeLeft = 140;
						base.projectile.netUpdate = true;
					}
				}
			}
		}

		// Token: 0x06000E00 RID: 3584 RVA: 0x000AEA44 File Offset: 0x000ACC44
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.projectileTexture[base.projectile.type];
			int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
			int y = num * base.projectile.frame;
			Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 0f);
			return false;
		}

		// Token: 0x06000E01 RID: 3585 RVA: 0x00037948 File Offset: 0x00035B48
		public override bool CanDamage()
		{
			return false;
		}
	}
}
