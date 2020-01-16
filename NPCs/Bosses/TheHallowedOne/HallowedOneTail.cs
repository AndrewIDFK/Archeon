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
	// Token: 0x020000CA RID: 202
	public class HallowedOneTail : ModNPC
	{		
		
		
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("The Hallowed One");
		}

		// Token: 0x060003AF RID: 943 RVA: 0x00020390 File Offset: 0x0001E590
		public override void SetDefaults()
		{
			base.npc.width = 54;
			base.npc.height = 58;
			base.npc.damage = 65;
			base.npc.defense = 48;
			
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

		// Token: 0x060003B0 RID: 944 RVA: 0x00020455 File Offset: 0x0001E655
		public override bool CheckActive()
		{
			return false;
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x00020458 File Offset: 0x0001E658
		public override bool PreAI()
		{
			Lighting.AddLight(base.npc.position, 0f, 0f, 0f);
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
			
			if (base.npc.ai[2] > 0f)
			{
				base.npc.realLife = (int)base.npc.ai[2];
			}
			if (base.npc.target < 0 || base.npc.target == 255 || Main.player[base.npc.target].dead)
			{
				base.npc.TargetClosest(true);
			}
			if (!Main.npc[(int)base.npc.ai[2]].active)
			{
				base.npc.timeLeft = 0;
				base.npc.active = false;
			}
			else
			{
				base.npc.timeLeft = 60000;
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
					base.npc.defense = 82;
				}
				if (ModGlobalNPC.hallowedTwin2 != -1 && Main.npc[ModGlobalNPC.hallowedTwin2].active)
				{
					redFlag = true;
					redNum += 255;
					base.npc.defense = 82;
				}
				base.npc.defense += redNum * 50;
				if (!redFlag)
				{
					base.npc.defense = (Main.expertMode ? 58 : 48);

				}
			}
			
			if (Main.npc[(int)base.npc.ai[1]].alpha < 128)
			{
				if (base.npc.alpha != 0)
				{
					for (int i = 0; i < 2; i++)
					{
						int num = Dust.NewDust(new Vector2(base.npc.position.X, base.npc.position.Y), base.npc.width, base.npc.height, base.mod.DustType("StroidDust2"), 0f, 0f, 100, default(Color), 2f);
						Main.dust[num].noGravity = true;
						Main.dust[num].noLight = true;
					}
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

		// Token: 0x060003B2 RID: 946 RVA: 0x000207D4 File Offset: 0x0001E9D4
		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			Texture2D texture2D = Main.npcTexture[base.npc.type];
			Vector2 origin = new Vector2((float)texture2D.Width * 0.5f, (float)texture2D.Height * 0.5f);
			Main.spriteBatch.Draw(texture2D, base.npc.Center - Main.screenPosition, null, drawColor, base.npc.rotation, origin, base.npc.scale, SpriteEffects.None, 0f);
			return false;
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x0002085C File Offset: 0x0001EA5C
		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			return new bool?(false);
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x00020864 File Offset: 0x0001EA64
		public override void HitEffect(int hitDirection, double damage)
		{
			if (base.npc.life <= 0)
			{
				for (int i = 0; i < 10; i++)
				{
					int num = Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, base.mod.DustType("StroidDust2"), 0f, 0f, 0, default(Color), 1f);
					Dust dust = Main.dust[num];
					dust.velocity.X = dust.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust.velocity.Y = dust.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust.scale *= 1.75f + (float)Main.rand.Next(-31, 31) * 0.01f;
				}
			}
		}
	}
}
