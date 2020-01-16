using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.NPCs.Enemies.EarthElementWorm
{
	// Token: 0x020000CF RID: 207
	public class EarthElementWormHead : ModNPC
	{
		// Token: 0x060003CF RID: 975 RVA: 0x000220EE File Offset: 0x000202EE
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Earthen Hurter");
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x00022100 File Offset: 0x00020300
		public override void SetDefaults()
		{
			base.npc.lifeMax = 1050;
			base.npc.damage = 75;
			base.npc.defense = 23;
			base.npc.knockBackResist = 0f;
			base.npc.width = 24;
			base.npc.height = 26;
			base.npc.lavaImmune = true;
			base.npc.noGravity = true;
			base.npc.noTileCollide = true;
			base.npc.HitSound = SoundID.NPCHit7;
			base.npc.DeathSound = SoundID.NPCDeath43;
			Main.npcFrameCount[base.npc.type] = 1;
			base.npc.value = (float)Item.buyPrice(0, 0, 9, 10);
			base.npc.npcSlots = 1f;
			base.npc.netAlways = true;
			base.npc.behindTiles = true;
			base.npc.scale = 1.15f;
			base.npc.buffImmune[base.mod.BuffType("EarthElementDebuff")] = true;
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x000221F8 File Offset: 0x000203F8
		public override bool PreAI()
		{
			if (Main.netMode != 1 && base.npc.ai[0] == 0f)
			{
				base.npc.realLife = base.npc.whoAmI;
				int num = base.npc.whoAmI;
				int num2 = Main.rand.Next(8, 13);
				for (int i = 0; i < num2; i++)
				{
					num = NPC.NewNPC((int)base.npc.Center.X, (int)base.npc.Center.Y, base.mod.NPCType("EarthElementWormBody"), base.npc.whoAmI, 0f, (float)num, 0f, 0f, 255);
					Main.npc[num].realLife = base.npc.whoAmI;
					Main.npc[num].ai[3] = (float)base.npc.whoAmI;
				}
				num = NPC.NewNPC((int)base.npc.Center.X, (int)base.npc.Center.Y, base.mod.NPCType("EarthElementWormTail"), base.npc.whoAmI, 0f, (float)num, 0f, 0f, 255);
				Main.npc[num].realLife = base.npc.whoAmI;
				Main.npc[num].ai[3] = (float)base.npc.whoAmI;
				base.npc.ai[0] = 1f;
				base.npc.netUpdate = true;
			}
			int num3 = (int)((double)base.npc.position.X / 16.0) - 1;
			int num4 = (int)((double)(base.npc.position.X + (float)base.npc.width) / 16.0) + 2;
			int num5 = (int)((double)base.npc.position.Y / 16.0) - 1;
			int num6 = (int)((double)(base.npc.position.Y + (float)base.npc.height) / 16.0) + 2;
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 > Main.maxTilesX)
			{
				num4 = Main.maxTilesX;
			}
			if (num5 < 0)
			{
				num5 = 0;
			}
			if (num6 > Main.maxTilesY)
			{
				num6 = Main.maxTilesY;
			}
			bool flag = false;
			for (int j = num3; j < num4; j++)
			{
				for (int k = num5; k < num6; k++)
				{
					if (Main.tile[j, k] != null && ((Main.tile[j, k].nactive() && (Main.tileSolid[(int)Main.tile[j, k].type] || (Main.tileSolidTop[(int)Main.tile[j, k].type] && Main.tile[j, k].frameY == 0))) || Main.tile[j, k].liquid > 64))
					{
						Vector2 vector;
						vector.X = (float)(j * 16);
						vector.Y = (float)(k * 16);
						if (base.npc.position.X + (float)base.npc.width > vector.X && (double)base.npc.position.X < (double)vector.X + 16.0 && (double)(base.npc.position.Y + (float)base.npc.height) > (double)vector.Y && (double)base.npc.position.Y < (double)vector.Y + 16.0)
						{
							flag = true;
							if (Main.rand.Next(100) == 0 && Main.tile[j, k].nactive())
							{
								WorldGen.KillTile(j, k, true, true, false);
							}
						}
					}
				}
			}
			if (!flag)
			{
				Rectangle rectangle = new Rectangle((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height);
				int num7 = 1150;
				bool flag2 = true;
				for (int l = 0; l < 255; l++)
				{
					if (Main.player[l].active)
					{
						Rectangle value = new Rectangle((int)Main.player[l].position.X - num7, (int)Main.player[l].position.Y - num7, num7 * 2, num7 * 2);
						if (rectangle.Intersects(value))
						{
							flag2 = false;
							break;
						}
					}
				}
				if (flag2)
				{
					flag = true;
				}
			}
			float num8 = 16f;
			float num9 = 0.48f;
			Vector2 vector2 = new Vector2(base.npc.position.X + (float)base.npc.width * 0.5f, base.npc.position.Y + (float)base.npc.height * 0.5f);
			float num10 = Main.player[base.npc.target].position.X + (float)(Main.player[base.npc.target].width / 2);
			float num11 = Main.player[base.npc.target].position.Y + (float)(Main.player[base.npc.target].height / 2);
			float num12 = (float)((int)((double)num10 / 16.0) * 16);
			float num13 = (float)((int)((double)num11 / 16.0) * 16);
			vector2.X = (float)((int)((double)vector2.X / 16.0) * 16);
			vector2.Y = (float)((int)((double)vector2.Y / 16.0) * 16);
			float num14 = num12 - vector2.X;
			float num15 = num13 - vector2.Y;
			float num16 = (float)Math.Sqrt((double)(num14 * num14 + num15 * num15));
			if (!flag)
			{
				base.npc.TargetClosest(true);
				base.npc.velocity.Y = base.npc.velocity.Y + 0.11f;
				if (base.npc.velocity.Y > num8)
				{
					base.npc.velocity.Y = num8;
				}
				if ((double)(Math.Abs(base.npc.velocity.X) + Math.Abs(base.npc.velocity.Y)) < (double)num8 * 0.4)
				{
					if ((double)base.npc.velocity.X < 0.0)
					{
						base.npc.velocity.X = base.npc.velocity.X - num9 * 1.1f;
					}
					else
					{
						base.npc.velocity.X = base.npc.velocity.X + num9 * 1.1f;
					}
				}
				else if (base.npc.velocity.Y == num8)
				{
					if (base.npc.velocity.X < num14)
					{
						base.npc.velocity.X = base.npc.velocity.X + num9;
					}
					else if (base.npc.velocity.X > num14)
					{
						base.npc.velocity.X = base.npc.velocity.X - num9;
					}
				}
				else if ((double)base.npc.velocity.Y > 4.0)
				{
					if ((double)base.npc.velocity.X < 0.0)
					{
						base.npc.velocity.X = base.npc.velocity.X + num9 * 0.9f;
					}
					else
					{
						base.npc.velocity.X = base.npc.velocity.X - num9 * 0.9f;
					}
				}
			}
			else
			{
				if (base.npc.soundDelay == 0)
				{
					float num17 = num16 / 40f;
					if ((double)num17 < 10.0)
					{
						num17 = 10f;
					}
					if ((double)num17 > 20.0)
					{
						num17 = 20f;
					}
					base.npc.soundDelay = (int)num17;
					Main.PlaySound(15, (int)base.npc.position.X, (int)base.npc.position.Y, 1, 1f, 0f);
				}
				float num18 = Math.Abs(num14);
				float num19 = Math.Abs(num15);
				float num20 = num8 / num16;
				num14 *= num20;
				num15 *= num20;
				if (((double)base.npc.velocity.X > 0.0 && (double)num14 > 0.0) || ((double)base.npc.velocity.X < 0.0 && (double)num14 < 0.0) || ((double)base.npc.velocity.Y > 0.0 && (double)num15 > 0.0) || ((double)base.npc.velocity.Y < 0.0 && (double)num15 < 0.0))
				{
					if (base.npc.velocity.X < num14)
					{
						base.npc.velocity.X = base.npc.velocity.X + num9;
					}
					else if (base.npc.velocity.X > num14)
					{
						base.npc.velocity.X = base.npc.velocity.X - num9;
					}
					if (base.npc.velocity.Y < num15)
					{
						base.npc.velocity.Y = base.npc.velocity.Y + num9;
					}
					else if (base.npc.velocity.Y > num15)
					{
						base.npc.velocity.Y = base.npc.velocity.Y - num9;
					}
					if ((double)Math.Abs(num15) < (double)num8 * 0.2 && (((double)base.npc.velocity.X > 0.0 && (double)num14 < 0.0) || ((double)base.npc.velocity.X < 0.0 && (double)num14 > 0.0)))
					{
						if ((double)base.npc.velocity.Y > 0.0)
						{
							base.npc.velocity.Y = base.npc.velocity.Y + num9 * 2f;
						}
						else
						{
							base.npc.velocity.Y = base.npc.velocity.Y - num9 * 2f;
						}
					}
					if ((double)Math.Abs(num14) < (double)num8 * 0.2 && (((double)base.npc.velocity.Y > 0.0 && (double)num15 < 0.0) || ((double)base.npc.velocity.Y < 0.0 && (double)num15 > 0.0)))
					{
						if ((double)base.npc.velocity.X > 0.0)
						{
							base.npc.velocity.X = base.npc.velocity.X + num9 * 2f;
						}
						else
						{
							base.npc.velocity.X = base.npc.velocity.X - num9 * 2f;
						}
					}
				}
				else if (num18 > num19)
				{
					if (base.npc.velocity.X < num14)
					{
						base.npc.velocity.X = base.npc.velocity.X + num9 * 1.1f;
					}
					else if (base.npc.velocity.X > num14)
					{
						base.npc.velocity.X = base.npc.velocity.X - num9 * 1.1f;
					}
					if ((double)(Math.Abs(base.npc.velocity.X) + Math.Abs(base.npc.velocity.Y)) < (double)num8 * 0.5)
					{
						if ((double)base.npc.velocity.Y > 0.0)
						{
							base.npc.velocity.Y = base.npc.velocity.Y + num9;
						}
						else
						{
							base.npc.velocity.Y = base.npc.velocity.Y - num9;
						}
					}
				}
				else
				{
					if (base.npc.velocity.Y < num15)
					{
						base.npc.velocity.Y = base.npc.velocity.Y + num9 * 1.1f;
					}
					else if (base.npc.velocity.Y > num15)
					{
						base.npc.velocity.Y = base.npc.velocity.Y - num9 * 1.1f;
					}
					if ((double)(Math.Abs(base.npc.velocity.X) + Math.Abs(base.npc.velocity.Y)) < (double)num8 * 0.5)
					{
						if ((double)base.npc.velocity.X > 0.0)
						{
							base.npc.velocity.X = base.npc.velocity.X + num9;
						}
						else
						{
							base.npc.velocity.X = base.npc.velocity.X - num9;
						}
					}
				}
			}
			base.npc.rotation = (float)Math.Atan2((double)base.npc.velocity.Y, (double)base.npc.velocity.X) + 1.57f;
			if (flag)
			{
				if (base.npc.localAI[0] != 1f)
				{
					base.npc.netUpdate = true;
				}
				base.npc.localAI[0] = 1f;
			}
			else
			{
				if ((double)base.npc.localAI[0] != 0.0)
				{
					base.npc.netUpdate = true;
				}
				base.npc.localAI[0] = 0f;
			}
			if ((((double)base.npc.velocity.X > 0.0 && (double)base.npc.oldVelocity.X < 0.0) || ((double)base.npc.velocity.X < 0.0 && (double)base.npc.oldVelocity.X > 0.0) || ((double)base.npc.velocity.Y > 0.0 && (double)base.npc.oldVelocity.Y < 0.0) || ((double)base.npc.velocity.Y < 0.0 && (double)base.npc.oldVelocity.Y > 0.0)) && !base.npc.justHit)
			{
				base.npc.netUpdate = true;
			}
			return false;
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x00023254 File Offset: 0x00021454
		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			Texture2D texture2D = Main.npcTexture[base.npc.type];
			Vector2 origin = new Vector2((float)texture2D.Width * 0.5f, (float)texture2D.Height * 0.5f);
			Main.spriteBatch.Draw(texture2D, base.npc.Center - Main.screenPosition, null, drawColor, base.npc.rotation, origin, base.npc.scale, SpriteEffects.None, 0f);
			return false;
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x000232DC File Offset: 0x000214DC
		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			scale = 1.1f;
			return null;
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x000232FC File Offset: 0x000214FC
		public override void HitEffect(int hitDirection, double damage)
		{
			if (base.npc.life <= 0)
			{
				for (int i = 0; i < 10; i++)
				{
					int num = Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, base.mod.DustType("EarthElementDust2"), 0f, 0f, 0, default(Color), 1f);
					Dust dust = Main.dust[num];
					dust.velocity.X = dust.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust.velocity.Y = dust.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust.scale *= 0.9f + (float)Main.rand.Next(-31, 31) * 0.01f;
				}
			}
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x00023438 File Offset: 0x00021638
		public override void NPCLoot()
		{
			if (Main.expertMode)
			{
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("EarthElement"), 2, false, 0, false, false);
					return;
				}
			}
			if (!Main.expertMode)
			{
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("EarthElement"), 1, false, 0, false, false);
					return;
				}
			}
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x0002352C File Offset: 0x0002172C
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return NPC.downedMechBoss3 && Main.hardMode ? SpawnCondition.Cavern.Chance * 0.015f : 0f;
		}		
	}
}
