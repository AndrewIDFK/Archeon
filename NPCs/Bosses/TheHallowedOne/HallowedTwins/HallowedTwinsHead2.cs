using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using Archeon.Tiles;
using Archeon;
using Archeon.Items;
using Archeon.NPCs;
using System.Linq;

namespace Archeon.NPCs.Bosses.TheHallowedOne.HallowedTwins
{
	// Token: 0x020000C8 RID: 200

	public class HallowedTwinsHead2 : ModNPC
	{

		private int Timer = 345;
		
		// Token: 0x0600039F RID: 927 RVA: 0x0001E70E File Offset: 0x0001C90E
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Hallowed Twin");
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x0001E720 File Offset: 0x0001C920
		public override void SetDefaults()
		{
			base.npc.lifeMax = 15000;
			base.npc.damage = 95;
			base.npc.defense = 36;
			base.npc.aiStyle = 5;
			this.aiType = -1;
			base.npc.knockBackResist = 0f;
			base.npc.width = 42;
			base.npc.height = 56;
			base.npc.boss = true;
			base.npc.lavaImmune = true;
			base.npc.noGravity = true;
			base.npc.noTileCollide = true;
			base.npc.HitSound = SoundID.NPCHit53;
			base.npc.DeathSound = SoundID.NPCDeath43;
			Main.npcFrameCount[base.npc.type] = 1;
			base.npc.value = (float)Item.buyPrice(0, 8, 30, 30);
			base.npc.npcSlots = 1f;
			base.npc.netAlways = true;
			base.npc.behindTiles = true;
			for (int i = 0; i < base.npc.buffImmune.Length; i++)
			{
				base.npc.buffImmune[i] = true;
			}
			base.npc.aiStyle = -1;
			if (Main.expertMode)
			{
				base.npc.scale = 1.1f;
			}
			else
			{
				base.npc.scale = 1f;
			}
		}
		
		
		
		

		public override void BossLoot(ref string name, ref int potionType)
		{
			name = "A Hallowed Twin";
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x0001EAFC File Offset: 0x0001CCFC
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			base.npc.lifeMax = (int)((double)base.npc.lifeMax * 0.55 * (double)bossLifeScale);
			base.npc.damage = (int)((float)base.npc.damage * 1.08f);
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x0001EB4C File Offset: 0x0001CD4C
		public override bool PreAI()
		{
			ModGlobalNPC.hallowedTwin1 = base.npc.whoAmI;
			Lighting.AddLight(base.npc.position, 0f, 0f, 0f);
			Player player = Main.player[base.npc.target];
			if (base.npc.target < 0 || base.npc.target == 255 || player.dead || !player.active || Main.dayTime)
			{
				base.npc.TargetClosest(true);
				player = Main.player[base.npc.target];
				base.npc.netUpdate = true;
				if (!player.active || player.dead || Main.dayTime)
				{
					base.npc.velocity = new Vector2(12f, 38f);
					if (base.npc.timeLeft > 250)
					{
						base.npc.timeLeft = 250;
					}
				}
			}
			if (Main.netMode != 1 && base.npc.ai[0] == 0f)
			{
				base.npc.realLife = base.npc.whoAmI;
				int num = base.npc.whoAmI;
				int num2 = Main.rand.Next(26, 30); //How Long the boi is
				for (int i = 0; i < num2; i++)
				{
					num = NPC.NewNPC((int)base.npc.Center.X, (int)base.npc.Center.Y, base.mod.NPCType("HallowedTwinsBody1"), base.npc.whoAmI, 0f, (float)num, 0f, 0f, 255);
					Main.npc[num].realLife = base.npc.whoAmI;
					Main.npc[num].ai[3] = (float)base.npc.whoAmI;
				}
				num = NPC.NewNPC((int)base.npc.Center.X, (int)base.npc.Center.Y, base.mod.NPCType("HallowedTwinsTail1"), base.npc.whoAmI, 0f, (float)num, 0f, 0f, 255);
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
			
			//speed
			float num7 = Main.expertMode ? 29 : 26;
			// Acceleration
			float num8 = Main.expertMode ? 0.58f : 0.445f;

			Vector2 vector2 = new Vector2(base.npc.position.X + (float)base.npc.width * 0.5f, base.npc.position.Y + (float)base.npc.height * 0.5f);
			float num9 = Main.player[base.npc.target].position.X + (float)(Main.player[base.npc.target].width / 2);
			float num10 = Main.player[base.npc.target].position.Y + (float)(Main.player[base.npc.target].height / 2);
			float num11 = (float)((int)((double)num9 / 16.0) * 16);
			float num12 = (float)((int)((double)num10 / 16.0) * 16);
			vector2.X = (float)((int)((double)vector2.X / 16.0) * 16);
			vector2.Y = (float)((int)((double)vector2.Y / 16.0) * 16);
			float num13 = num11 - vector2.X;
			float num14 = num12 - vector2.Y;
			float num15 = (float)Math.Sqrt((double)(num13 * num13 + num14 * num14));
			if (!flag)
			{
				base.npc.TargetClosest(true);
				base.npc.velocity.Y = base.npc.velocity.Y + 0.11f;
				if (base.npc.velocity.Y > num7)
				{
					base.npc.velocity.Y = num7;
				}
				if ((double)(Math.Abs(base.npc.velocity.X) + Math.Abs(base.npc.velocity.Y)) < (double)num7 * 0.4)
				{
					if ((double)base.npc.velocity.X < 0.0)
					{
						base.npc.velocity.X = base.npc.velocity.X - num8 * 1.1f;
					}
					else
					{
						base.npc.velocity.X = base.npc.velocity.X + num8 * 1.1f;
					}
				}
				else if (base.npc.velocity.Y == num7)
				{
					if (base.npc.velocity.X < num13)
					{
						base.npc.velocity.X = base.npc.velocity.X + num8;
					}
					else if (base.npc.velocity.X > num13)
					{
						base.npc.velocity.X = base.npc.velocity.X - num8;
					}
				}
				else if ((double)base.npc.velocity.Y > 4.0)
				{
					if ((double)base.npc.velocity.X < 0.0)
					{
						base.npc.velocity.X = base.npc.velocity.X + num8 * 0.9f;
					}
					else
					{
						base.npc.velocity.X = base.npc.velocity.X - num8 * 0.9f;
					}
				}
			}
			else
			{
				if (base.npc.soundDelay == 0)
				{
					float num16 = num15 / 40f;
					if ((double)num16 < 10.0)
					{
						num16 = 10f;
					}
					if ((double)num16 > 20.0)
					{
						num16 = 20f;
					}
					base.npc.soundDelay = (int)num16;
					Main.PlaySound(15, (int)base.npc.position.X, (int)base.npc.position.Y, 1, 1f, 0f);
				}
				float num17 = Math.Abs(num13);
				float num18 = Math.Abs(num14);
				float num19 = num7 / num15;
				num13 *= num19;
				num14 *= num19;
				if (((double)base.npc.velocity.X > 0.0 && (double)num13 > 0.0) || ((double)base.npc.velocity.X < 0.0 && (double)num13 < 0.0) || ((double)base.npc.velocity.Y > 0.0 && (double)num14 > 0.0) || ((double)base.npc.velocity.Y < 0.0 && (double)num14 < 0.0))
				{
					if (base.npc.velocity.X < num13)
					{
						base.npc.velocity.X = base.npc.velocity.X + num8;
					}
					else if (base.npc.velocity.X > num13)
					{
						base.npc.velocity.X = base.npc.velocity.X - num8;
					}
					if (base.npc.velocity.Y < num14)
					{
						base.npc.velocity.Y = base.npc.velocity.Y + num8;
					}
					else if (base.npc.velocity.Y > num14)
					{
						base.npc.velocity.Y = base.npc.velocity.Y - num8;
					}
					if ((double)Math.Abs(num14) < (double)num7 * 0.2 && (((double)base.npc.velocity.X > 0.0 && (double)num13 < 0.0) || ((double)base.npc.velocity.X < 0.0 && (double)num13 > 0.0)))
					{
						if ((double)base.npc.velocity.Y > 0.0)
						{
							base.npc.velocity.Y = base.npc.velocity.Y + num8 * 2f;
						}
						else
						{
							base.npc.velocity.Y = base.npc.velocity.Y - num8 * 2f;
						}
					}
					if ((double)Math.Abs(num13) < (double)num7 * 0.2 && (((double)base.npc.velocity.Y > 0.0 && (double)num14 < 0.0) || ((double)base.npc.velocity.Y < 0.0 && (double)num14 > 0.0)))
					{
						if ((double)base.npc.velocity.X > 0.0)
						{
							base.npc.velocity.X = base.npc.velocity.X + num8 * 2f;
						}
						else
						{
							base.npc.velocity.X = base.npc.velocity.X - num8 * 2f;
						}
					}
				}
				else if (num17 > num18)
				{
					if (base.npc.velocity.X < num13)
					{
						base.npc.velocity.X = base.npc.velocity.X + num8 * 1.1f;
					}
					else if (base.npc.velocity.X > num13)
					{
						base.npc.velocity.X = base.npc.velocity.X - num8 * 1.1f;
					}
					if ((double)(Math.Abs(base.npc.velocity.X) + Math.Abs(base.npc.velocity.Y)) < (double)num7 * 0.5)
					{
						if ((double)base.npc.velocity.Y > 0.0)
						{
							base.npc.velocity.Y = base.npc.velocity.Y + num8;
						}
						else
						{
							base.npc.velocity.Y = base.npc.velocity.Y - num8;
						}
					}
				}
				else
				{
					if (base.npc.velocity.Y < num14)
					{
						base.npc.velocity.Y = base.npc.velocity.Y + num8 * 1.1f;
					}
					else if (base.npc.velocity.Y > num14)
					{
						base.npc.velocity.Y = base.npc.velocity.Y - num8 * 1.1f;
					}
					if ((double)(Math.Abs(base.npc.velocity.X) + Math.Abs(base.npc.velocity.Y)) < (double)num7 * 0.5)
					{
						if ((double)base.npc.velocity.X > 0.0)
						{
							base.npc.velocity.X = base.npc.velocity.X + num8;
						}
						else
						{
							base.npc.velocity.X = base.npc.velocity.X - num8;
						}
					}
				}
			}
			
			this.Timer--;
			if (this.Timer <= Main.rand.Next(45, 125))
			{
				if (!Main.expertMode)
				{
					Projectile.NewProjectile(base.npc.position, new Vector2(11f), base.mod.ProjectileType("HallowedOneHoming"), 22, 6f, 255, 0f, 0f);
				}
				else
				{
					Projectile.NewProjectile(base.npc.position, new Vector2(9f), base.mod.ProjectileType("HallowedOneHoming"), 31, 6f, 255, 0f, 0f);
				
					Projectile.NewProjectile(base.npc.position, new Vector2(11f), base.mod.ProjectileType("HallowedOneHoming"), 27, 6f, 255, 0f, 0f);
				}
				
				this.Timer = Main.rand.Next(325, 415);
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
		
		
	
		// Token: 0x060003A5 RID: 933 RVA: 0x0001FBCC File Offset: 0x0001DDCC
		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			Texture2D texture2D = Main.npcTexture[base.npc.type];
			Vector2 origin = new Vector2((float)texture2D.Width * 0.5f, (float)texture2D.Height * 0.5f);
			Main.spriteBatch.Draw(texture2D, base.npc.Center - Main.screenPosition, null, drawColor, base.npc.rotation, origin, base.npc.scale, SpriteEffects.None, 0f);
			return false;
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x0001FC54 File Offset: 0x0001DE54
		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			scale = 1.1f;
			return null;
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x0001FC74 File Offset: 0x0001DE74
		public override void HitEffect(int hitDirection, double damage)
		{
			if (base.npc.life <= 0)
			{
				for (int i = 0; i < 7; i++)
				{
					int num = Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, base.mod.DustType("StroidDust2"), 0f, 0f, 0, default(Color), 1f);
					Dust dust = Main.dust[num];
					dust.velocity.X = dust.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust.velocity.Y = dust.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust.scale *= 1.85f + (float)Main.rand.Next(-31, 31) * 0.01f;
				}
			}
		}
	}
}
