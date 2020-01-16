using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.NPCs.Bosses.TheHallowedOne
{
	// Token: 0x020000C7 RID: 199
	public class HallowedOneBody : ModNPC
	{
		private int Timer = 895;
		
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("The Hallowed One");
		}

		// Token: 0x06000398 RID: 920 RVA: 0x0001E06C File Offset: 0x0001C26C
		public override void SetDefaults()
		{
			base.npc.width = 54;
			base.npc.height = 58;
			base.npc.damage = 67;
			base.npc.defense = 49;
			base.npc.lifeMax = 90000;
			base.npc.knockBackResist = 0f;
			base.npc.noTileCollide = true;
			base.npc.netAlways = true;
			base.npc.noGravity = true;
			base.npc.dontCountMe = true;
			base.npc.HitSound = SoundID.NPCHit4;
			base.npc.behindTiles = true;
			if (Main.expertMode)
			{
				base.npc.scale = 1.45f;
			}
			else
			{
				base.npc.scale = 1.4f;
			}
			base.npc.aiStyle = 6;
			for (int i = 0; i < base.npc.buffImmune.Length; i++)
			{
				base.npc.buffImmune[i] = true;
			}
			/*base.npc.buffImmune[base.mod.BuffType("FrostElementDebuff")] = false;
			base.npc.buffImmune[base.mod.BuffType("FireElementDebuff")] = false;
			base.npc.buffImmune[base.mod.BuffType("AirElementDebuff")] = false;*/
			base.npc.buffImmune[base.mod.BuffType("EarthElementDebuff")] = false;
			
			base.npc.npcSlots = 5f;
			this.aiType = -1;
			this.animationType = 10;
			base.npc.alpha = 255;
			base.npc.canGhostHeal = false;
		}
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			base.npc.lifeMax = (int)((double)base.npc.lifeMax * 0.55 * (double)bossLifeScale);
			base.npc.damage = (int)((float)base.npc.damage * 1.05f);
		}
		
		// Token: 0x06000399 RID: 921 RVA: 0x0001E131 File Offset: 0x0001C331
		public override bool CheckActive()
		{
			return false;
		}

		// Token: 0x0600039A RID: 922 RVA: 0x0001E134 File Offset: 0x0001C334
		public override bool PreAI()
		{
			Lighting.AddLight(base.npc.position, 0.455f, 0.155f, 0.505f);
			Player player = Main.player[base.npc.target];
			base.npc.dontTakeDamage = (!player.ZoneHoly);
			if (!Main.npc[(int)base.npc.ai[1]].active)
			{
				base.npc.life = 0;
				base.npc.HitEffect(0, 10.0);
				base.npc.active = false;
			}
			if (Main.npc[(int)base.npc.ai[1]].alpha < 128)
			{
				base.npc.alpha -= 42;
				if (base.npc.alpha < 0)
				{
					base.npc.alpha = 0;
				}
			}
			
			
		
			if (!Main.npc[(int)base.npc.ai[1]].active)
			{
				base.npc.life = 0;
				base.npc.HitEffect(0, 10.0);
				base.npc.active = false;
			}
			if (Main.npc[(int)base.npc.ai[1]].alpha < 128)
			{
				base.npc.alpha -= 42;
				if (base.npc.alpha < 0)
				{
					base.npc.alpha = 0;
				}
			}
			
			if (base.npc.ai[3] > 0f)
			{
				base.npc.realLife = (int)base.npc.ai[3];
			}
			if (base.npc.target < 0 || base.npc.target == 255 || Main.player[base.npc.target].dead)
			{
				base.npc.TargetClosest(true);
			}
			if (!Main.npc[(int)base.npc.ai[3]].active)
			{
				base.npc.timeLeft = 0;
				base.npc.active = false;
			}
			else
			{
				base.npc.timeLeft = 60000;
			}
			this.Timer--;
			if (this.Timer <= Main.rand.Next(125, 181))
			{
				if (Main.rand.Next(2) == 1)
				{
					Projectile.NewProjectile(base.npc.position, new Vector2(0f), base.mod.ProjectileType("HallowedOneShotNoMoving"), 29, 11f, 255, 0f, 0f);
				}
				
				if (Main.rand.Next(2) == 0)
				{
					Projectile.NewProjectile(base.npc.position, new Vector2(0f), base.mod.ProjectileType("HallowedOneShotDownNoMove"), 29, 11f, 255, 0f, 0f);
				}
				
				this.Timer = Main.rand.Next(450, 581);
			}
			
			bool flag69 = Main.hardMode;
			bool redFlag = false;
			int redNum = 0;
			if (flag69)
			{
				if (ModGlobalNPC.hallowedTwin1 != -1 && Main.npc[ModGlobalNPC.hallowedTwin1].active)
				{
					redFlag = true;
					redNum += 255;
					base.npc.defense = 92;
					for (int i = 0; i < base.npc.buffImmune.Length; i++)
					{
						base.npc.buffImmune[i] = true;
					}
				}
				if (ModGlobalNPC.hallowedTwin2 != -1 && Main.npc[ModGlobalNPC.hallowedTwin2].active)
				{
					redFlag = true;
					redNum += 255;
					base.npc.defense = 92;
					for (int i = 0; i < base.npc.buffImmune.Length; i++)
					{
						base.npc.buffImmune[i] = true;
					}
				}
				base.npc.defense += redNum * 50;
				if (!redFlag)
				{
					base.npc.defense = (Main.expertMode ? 59 : 49);

				}
			}
			
			if (Main.npc[(int)base.npc.ai[1]].alpha < 128)
			{
				if (base.npc.alpha != 0)
				{
					int num = Dust.NewDust(new Vector2(base.npc.position.X, base.npc.position.Y), base.npc.width, base.npc.height, base.mod.DustType("StroidDust2"), 0f, 0f, 100, default(Color), 2f);
					Main.dust[num].noGravity = true;
					Main.dust[num].noLight = true;
				}
				base.npc.alpha -= 42;
				if (base.npc.alpha < 0)
				{
					base.npc.alpha = 0;
				}
			}
			
			if ((double)base.npc.ai[1] < (double)Main.npc.Length)
			{
				Vector2 vector = new Vector2(base.npc.position.X + (float)base.npc.width * 0.5f, base.npc.position.Y + (float)base.npc.height * 0.5f);
				float num = Main.npc[(int)base.npc.ai[1]].position.X + (float)(Main.npc[(int)base.npc.ai[1]].width / 2) - vector.X;
				float num2 = Main.npc[(int)base.npc.ai[1]].position.Y + (float)(Main.npc[(int)base.npc.ai[1]].height / 2) - vector.Y;
				base.npc.rotation = (float)Math.Atan2((double)num2, (double)num) + 1.57f;
				float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
				float num4 = (num3 - (float)base.npc.width) / num3;
				float num5 = num * num4;
				float num6 = num2 * num4;
				base.npc.velocity = Vector2.Zero;
				base.npc.position.X = base.npc.position.X + num5;
				base.npc.position.Y = base.npc.position.Y + num6;
			}
			return false;
		}
		
		// Token: 0x0600039B RID: 923 RVA: 0x0001E524 File Offset: 0x0001C724
		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			Texture2D texture2D = Main.npcTexture[base.npc.type];
			Vector2 origin = new Vector2((float)texture2D.Width * 0.5f, (float)texture2D.Height * 0.5f);
			Main.spriteBatch.Draw(texture2D, base.npc.Center - Main.screenPosition, null, drawColor, base.npc.rotation, origin, base.npc.scale, SpriteEffects.None, 0f);
			return false;
		}

		// Token: 0x0600039C RID: 924 RVA: 0x0001E5AC File Offset: 0x0001C7AC
		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			return new bool?(false);
		}

		public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn this
            {
				for (int i = 0; i < 10; i++)
                {
                    int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("StroidDust1"));
                    Dust dust = Main.dust[dustIndex];
                    dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                    dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                    dust.scale *= 2.25f + Main.rand.Next(-31, 31) * 0.01f;
                }
				if (Main.rand.Next(2) == 0) //drop chance - This gives a 49% chance as 50-1 = 49
				{
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HallowedOneBodyGore"), 1.2f);   //make sure you put the right folder name where your gores is located and the right name of gores
				}
			}
        }
	}
}
