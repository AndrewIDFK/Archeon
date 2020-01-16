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


namespace Archeon.NPCs.Bosses.MarbleBoss
{
	// Token: 0x020000C6 RID: 198
	[AutoloadBossHead]
	public class MarbleBoss : ModNPC
	{
		
		private int Timer = 500;
		
		private float bossLife;
		
		private int marbieHeal;
		
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Promethea");
			Main.npcFrameCount[base.npc.type] = 4;
		}

		public override void SetDefaults()
		{
			base.npc.aiStyle = 14;
			//this.aiType = -1;
			base.npc.lifeMax = 7500;
			base.npc.damage = 32;
			base.npc.defense = 22;
			base.npc.knockBackResist = 0f;
			base.npc.width = 60;
			base.npc.height = 120;
			this.animationType = 152;
			base.npc.value = (float)Item.buyPrice(0, 6, 60, 40);
			base.npc.lavaImmune = true;
			base.npc.noGravity = true;
			base.npc.noTileCollide = true;
			base.npc.HitSound = SoundID.NPCHit53;
			base.npc.DeathSound = SoundID.NPCDeath43;
			base.npc.buffImmune[24] = true;
			base.npc.netAlways = true;
			base.npc.boss = true;
			base.npc.scale = 1.2f;
			
			music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/MarbleBossThemePlaceholder");
			
			base.npc.npcSlots = 6f;
			for (int i = 0; i < base.npc.buffImmune.Length; i++)
			{
				base.npc.buffImmune[i] = true;
			}
			bossBag = base.mod.ItemType("MarbleBossBossBag");
		}
		
		public override void BossLoot(ref string name, ref int potionType)
		{
			int choice = Main.rand.Next(2);
			
			potionType = ItemID.HealingPotion;
	
			if (choice == 0)
			{
				Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("AttackOrbAccessory"), Main.rand.Next(10, 20), false, 0, false, false);
			}
			if (choice == 1)
			{
				Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("DefenseOrbAccessory"), Main.rand.Next(10, 20), false, 0, false, false);
			}
			
		}
		
		public override void NPCLoot()
		{
			int choice = Main.rand.Next(3);
			
			if(Main.expertMode)
			{
				npc.DropBossBags();
			}
			else
			{
				if (choice == 0)
				{
					Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("AttackOrbAccessory"), Main.rand.Next(10, 20), false, 0, false, false);
				}
				if (choice == 1)
				{
					Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("DefenseOrbAccessory"), Main.rand.Next(10, 20), false, 0, false, false);
				}
			}
		}
		
		public void AutoloadHead(ref string headTexture, ref string bossHeadTexture)
		{
			bossHeadTexture = "Archeon/NPCs/Bosses/MarbleBoss/MarbleBoss_Head_Boss";
		}
		
		
		
		public override void AI()
		{
			
			Lighting.AddLight((int)((base.npc.position.X + (float)(base.npc.width / 2)) / 16f), (int)((base.npc.position.Y + (float)(base.npc.height / 2)) / 16f), 0.1f, 0.1f, 0.1f);
			Player player = Main.player[base.npc.target];
			bool expertBoomer = Main.expertMode || !Main.expertMode;
			
			
			
			int numxd = Dust.NewDust(base.npc.position + base.npc.velocity, base.npc.width, base.npc.height, mod.DustType("MarbleBossTrailDust"), base.npc.velocity.X * 2f, base.npc.velocity.Y * 2f, 100, default(Color), 1.4f);
			Main.dust[numxd].velocity /= 60f;
			Main.dust[numxd].scale = 1.25f;
			Main.dust[numxd].noGravity = true;
			Main.dust[numxd].fadeIn = 1.2f;
			
			int numxdd = Dust.NewDust(base.npc.position + base.npc.velocity, base.npc.width, base.npc.height, 76, base.npc.velocity.X * 2f, base.npc.velocity.Y * 2f, 100, default(Color), 1.4f);
			Main.dust[numxdd].velocity /= 60f;
			Main.dust[numxdd].scale = 0.8f;
			Main.dust[numxdd].noGravity = true;
			Main.dust[numxdd].fadeIn = 1.2f;
			
			npc.TargetClosest(true);
            if ((Main.player[npc.target].Distance(npc.Center) <= 120f) && (npc.velocity.Y == 0))
            {
                npc.velocity = new Vector2(npc.direction * 6, -3f);
            }
			
			this.Timer--;
			if (this.Timer <= Main.rand.Next(50, 100))
			{
				float Speed = 29f;  //projectile speed
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = npc.damage - 15;  //projectile damage
                int type = mod.ProjectileType("MarbleBossCircle");  //put your projectile
                Main.PlaySound(SoundID.Item8);
				float num = 0.69f;
				
				double num3 = (double)(num / 8f);
				
				for (int i = 0; i < 8; i++)
				{
					double num4 = num3 * (double)(i + i * i) / 2.0 + (double)(48f * (float)i);
					Projectile.NewProjectile(npc.position.X, npc.position.Y, (float)(Math.Sin(num4) * 11.0), (float)(Math.Cos(num4) * 8.0), type, damage, 4, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(npc.position.X, npc.position.Y, (float)(-(float)Math.Sin(num4) * 11.0), (float)(-(float)Math.Cos(num4) * 8.0), type, damage, 4, Main.myPlayer, 0f, 0f);
				}
				
				
				
				this.Timer = Main.rand.Next(400, 500);
			}

			/*npc.ai[1]++;
            if (npc.ai[1] >= 230)  // 230 is projectile fire rate
            {
                float Speed = 31f;  //projectile speed
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = npc.damage;  //projectile damage //Cameron Rungtranont
                int type = mod.ProjectileType("MarbleBossCircle");  //put your projectile
                Main.PlaySound(SoundID.Item8);
				float num = 0.69f;
				
				double num3 = (double)(num / 8f);
				
				for (int i = 0; i < 5; i++)
				{
					double num4 = num3 * (double)(i + i * i) / 2.0 + (double)(38f * (float)i);
					Projectile.NewProjectile(npc.position.X, npc.position.Y, (float)(Math.Sin(num4) * 11.0), (float)(Math.Cos(num4) * 8.0), type, damage, 3, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(npc.position.X, npc.position.Y, (float)(-(float)Math.Sin(num4) * 11.0), (float)(-(float)Math.Cos(num4) * 8.0), type, damage, 3, Main.myPlayer, 0f, 0f);
				}
                npc.ai[1] = 0;
            }*/
			
			if (Main.netMode != 1)
			{
				npc.TargetClosest();
				int num767 = 6000;
				if (Math.Abs(base.npc.Center.X - Main.player[npc.target].Center.X) + Math.Abs(base.npc.Center.Y - Main.player[npc.target].Center.Y) > (float)num767)
				{
					npc.active = false;
					npc.life = 0;
					if (Main.netMode == 2)
					{
						NetMessage.SendData(23, -1, -1, null, npc.whoAmI);
					}
				}
			}
			
			
			if (NPC.AnyNPCs(base.mod.NPCType("DefenseOrb")))
			{
				npc.defense = 26;
				
				float numHeal = expertBoomer ? 120f : 90f;
				this.marbieHeal++;
				if ((float)this.marbieHeal >= numHeal)
				{
					this.marbieHeal = 0;
					if (Main.netMode != 1)
					{
						int numLife = npc.lifeMax / 300;
						if (numLife > npc.lifeMax - npc.life)
						{
							numLife = npc.lifeMax - npc.life;
						}
						if (numLife > 0)
						{
							npc.life += numLife;
							
							npc.HealEffect(numLife, true);
							
							npc.netUpdate = true;
						}
						
						for (int j = 0; j < 12; j++)
						{
							int num3 = Dust.NewDust(new Vector2(base.npc.position.X, base.npc.position.Y), base.npc.width, base.npc.height, 107, 0f, 0f, 100, default(Color), 1.5f);
							Main.dust[num3].noGravity = true;
							Main.dust[num3].velocity *= 5f;
							num3 = Dust.NewDust(new Vector2(base.npc.position.X, base.npc.position.Y), base.npc.width, base.npc.height, 107, 0f, 0f, 100, default(Color), 1f);
							Main.dust[num3].velocity *= 2f;
							num3 = Dust.NewDust(new Vector2(base.npc.position.X, base.npc.position.Y), base.npc.width, base.npc.height, 107, 0f, 0f, 100, default(Color), 1f);
							Main.dust[num3].velocity *= 2f;
							num3 = Dust.NewDust(new Vector2(base.npc.position.X, base.npc.position.Y), base.npc.width, base.npc.height, 107, 0f, 0f, 100, default(Color), 1f);
							Main.dust[num3].velocity *= 2f;
							num3 = Dust.NewDust(new Vector2(base.npc.position.X, base.npc.position.Y), base.npc.width, base.npc.height, 107, 0f, 0f, 100, default(Color), 1f);
							Main.dust[num3].velocity *= 2f;
							num3 = Dust.NewDust(new Vector2(base.npc.position.X, base.npc.position.Y), base.npc.width, base.npc.height, 107, 0f, 0f, 100, default(Color), 1f);
							Main.dust[num3].velocity *= 2f;
						}
					}
				}
			}
			else if (!NPC.AnyNPCs(base.mod.NPCType("DefenseOrb")))
			{
				npc.defense = 20;
			}
			if (NPC.AnyNPCs(base.mod.NPCType("AttackOrb")))
			{
				npc.damage = 38;
			}
			else if (!NPC.AnyNPCs(base.mod.NPCType("DefenseOrb")))
			{
				npc.damage = 32;
			}
			
			
			if (this.bossLife == 0f && base.npc.life > 0)
			{
				this.bossLife = (float)base.npc.lifeMax;
			}
			if (base.npc.life > 0 && Main.netMode != 1)
			{
				int num007 = (int)((double)base.npc.lifeMax * 0.25);
				if ((float)(base.npc.life + num007) < this.bossLife)
				{
					this.bossLife = (float)base.npc.life;
					if ((double)this.bossLife <= (double)((float)base.npc.lifeMax) * 0.75)
					{
						if (!NPC.AnyNPCs(base.mod.NPCType("DefenseOrb")))
						{
							NPC.NewNPC((int)(Main.player[base.npc.target].position.X + 1200f), (int)Main.player[base.npc.target].position.Y + 80, base.mod.NPCType("DefenseOrb"), 0, 0f, 0f, 0f, 0f, 255);
						}
						if (!NPC.AnyNPCs(base.mod.NPCType("AttackOrb")))
						{
							NPC.NewNPC((int)(Main.player[base.npc.target].position.X - 1200f), (int)Main.player[base.npc.target].position.Y - 80, base.mod.NPCType("AttackOrb"), 0, 0f, 0f, 0f, 0f, 255);
						}
					}
				}
			}
			
			
			if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(true);
            }
            npc.netUpdate = true;
			
			if (!player.active || player.dead)
			{
				base.npc.TargetClosest(false);
				player = Main.player[base.npc.target];
				if (!player.active || player.dead)
				{
					base.npc.velocity = new Vector2(0f, 10f);
					if (base.npc.timeLeft > 140)
					{
						base.npc.timeLeft = 140;
					}
					return;
				}
			}
			else if (base.npc.timeLeft < 1400)
			{
				base.npc.timeLeft = 1400;
			}
			
			
			bool flag = false;
			
			if (Main.netMode != 1)
			{
				int num = 8;
				base.npc.localAI[0] += (float)Main.rand.Next(num);
				if (base.npc.localAI[0] >= (float)Main.rand.Next(460, 960))
				{
					base.npc.localAI[0] = 0f;
					Main.PlaySound(3, (int)base.npc.position.X, (int)base.npc.position.Y, 20, 1f, 0f);
					for (int i = 0; i < 6; i++)
					{
						int num2 = Dust.NewDust(new Vector2(base.npc.position.X, base.npc.position.Y), base.npc.width, base.npc.height, mod.DustType("MarbleBossTrailDust"), 0f, 0f, 100, default(Color), 1f);
						Main.dust[num2].velocity *= 3f;
						if (Main.rand.Next(7) == 0)
						{
							Main.dust[num2].scale = 0.5f;

						}
					}
					for (int j = 0; j < 12; j++)
					{
						int num3 = Dust.NewDust(new Vector2(base.npc.position.X, base.npc.position.Y), base.npc.width, base.npc.height, mod.DustType("MarbleBossTrailDust"), 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num3].noGravity = true;
						Main.dust[num3].velocity *= 5f;
						/*num3 = Dust.NewDust(new Vector2(base.npc.position.X, base.npc.position.Y), base.npc.width, base.npc.height, mod.DustType("MarbleBossTrailDust"), 0f, 0f, 100, default(Color), 1f);
						Main.dust[num3].velocity *= 2f;
						num3 = Dust.NewDust(new Vector2(base.npc.position.X, base.npc.position.Y), base.npc.width, base.npc.height, 76, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num3].velocity *= 2f;*/
					}
				}
			}
		
		
			if (base.npc.position.Y > player.position.Y - 210f)
			{
				if (base.npc.velocity.Y > 0f)
				{
					base.npc.velocity.Y = base.npc.velocity.Y * 1.02f;
				}
				base.npc.velocity.Y = base.npc.velocity.Y - 0.14f;
				if (base.npc.velocity.Y > 2f)
				{
					base.npc.velocity.Y = 2f;
				}
			}
			else if (base.npc.position.Y < player.position.Y - 460f)
			{
				if (base.npc.velocity.Y < 0f)
				{
					base.npc.velocity.Y = base.npc.velocity.Y * 1.02f;
				}
				base.npc.velocity.Y = base.npc.velocity.Y + 0.14f;
				if (base.npc.velocity.Y < -3f)
				{
					base.npc.velocity.Y = -3f;
				}
			}
		}
		
		

		// Token: 0x06000393 RID: 915 RVA: 0x0001DEEC File Offset: 0x0001C0EC
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			base.npc.lifeMax = (int)((float)base.npc.lifeMax * bossLifeScale);
			base.npc.damage = (int)((float)base.npc.damage * 1.085f);
		}

		// Token: 0x06000394 RID: 916 RVA: 0x0001DF28 File Offset: 0x0001C128
		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			scale = 1.15f;
			return null;
		}

		// Token: 0x06000395 RID: 917 RVA: 0x0001DF48 File Offset: 0x0001C148
		public override void HitEffect(int hitDirection, double damage)
		{
			if (base.npc.life <= 0)
			{
				for (int i = 0; i < 7; i++)
				{
					int num = Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, mod.DustType("MarbleBossTrailDust"), 0f, 0f, 0, default(Color), 1f);
					Dust dust = Main.dust[num];
					dust.velocity.X = dust.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust.velocity.Y = dust.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust.scale *= 1.45f + (float)Main.rand.Next(-31, 31) * 0.013f;
					
					int numzies = Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, mod.DustType("MarbleBossTrailDust"), 0f, 0f, 0, default(Color), 1f);
					Dust dusties = Main.dust[numzies];
					dusties.velocity.X = dusties.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					dusties.velocity.Y = dusties.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					dusties.scale *= 1.5f + (float)Main.rand.Next(-31, 31) * 0.013f;
				}
				for (int i = 0; i < 7; i++)
				{
					int num = Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, mod.DustType("MarbleBossTrailDust"), 0f, 0f, 0, default(Color), 1f);
					Dust dust = Main.dust[num];
					dust.velocity.X = dust.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust.velocity.Y = dust.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust.scale *= 1.45f + (float)Main.rand.Next(-31, 31) * 0.013f;
					
					int numzies = Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, mod.DustType("MarbleBossTrailDust"), 0f, 0f, 0, default(Color), 1f);
					Dust dusties = Main.dust[numzies];
					dusties.velocity.X = dusties.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					dusties.velocity.Y = dusties.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					dusties.scale *= 1.5f + (float)Main.rand.Next(-31, 31) * 0.013f;
				}
			}
		}
	}
}
