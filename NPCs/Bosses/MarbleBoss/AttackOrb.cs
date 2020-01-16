using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.NPCs.Bosses.MarbleBoss
{
    public class AttackOrb : ModNPC
    {
		public static int marbleBoss = -1;
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Attack Orb");
		}
		
        public override void SetDefaults()
        {
			base.npc.aiStyle = 14;
			this.aiType = 152;
			base.npc.damage = 32;
			base.npc.width = 36;
			base.npc.height = 36;
			base.npc.defense = 20;
			base.npc.lifeMax = 850;
			base.npc.knockBackResist = 0.24f;
			base.npc.value = (float)Item.buyPrice(0, 0, 10, 30);
			base.npc.HitSound = SoundID.NPCHit24;
			base.npc.DeathSound = SoundID.NPCDeath5;
			npc.lavaImmune = true; 
			base.npc.buffImmune[24] = true;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.scale = 1.1f;
			base.npc.npcSlots = 0.5f;
			base.npc.netAlways = true;
			for (int i = 0; i < base.npc.buffImmune.Length; i++)
			{
				base.npc.buffImmune[i] = true;
			}
        }
		
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			base.npc.lifeMax = (int)((float)base.npc.lifeMax * 0.52f * bossLifeScale);
			base.npc.damage = (int)((float)base.npc.damage * 1.12f);
		}
		
		public override void AI()
		{
			
			Lighting.AddLight((int)((base.npc.position.X + (float)(base.npc.width / 2)) / 16f), (int)((base.npc.position.Y + (float)(base.npc.height / 2)) / 16f), 1.24f, 1.17f, 0.04f);
			Player player = Main.player[base.npc.target];
			bool flag2 = Main.expertMode;
			//base.npc.dontTakeDamage = (!player.ZoneHoly);
			
			
			int numxd = Dust.NewDust(base.npc.position + base.npc.velocity, base.npc.width, base.npc.height, mod.DustType("AttackOrbDust"), base.npc.velocity.X * 2f, base.npc.velocity.Y * 2f, 100, default(Color), 1.4f);
			Main.dust[numxd].velocity /= 50f;
			Main.dust[numxd].scale = 1.2f;
			Main.dust[numxd].noGravity = true;
			Main.dust[numxd].fadeIn = 1.2f;
			
			base.npc.ai[1] += 0f;
			if (base.npc.life <= 90000)
			{
				base.npc.ai[2] += 1f;
			}
			if (base.npc.ai[2] >= 19f)
			{
				NPC npc = base.npc;
				npc.velocity.X = npc.velocity.X;
				NPC npc2 = base.npc;
				npc2.velocity.Y = npc2.velocity.Y;
				Vector2 vector = new Vector2(base.npc.position.X + (float)base.npc.width * 0.5f, base.npc.position.Y + (float)base.npc.height * 0.5f);
				float num = (float)Math.Atan2((double)(vector.Y - (Main.player[base.npc.target].position.Y + (float)Main.player[base.npc.target].height * 0.5f)), (double)(vector.X - (Main.player[base.npc.target].position.X + (float)Main.player[base.npc.target].width * 0.5f)));
				base.npc.velocity.X = (float)(Math.Cos((double)num) * 8.0) * -1f;
				base.npc.velocity.Y = (float)(Math.Sin((double)num) * 8.0) * -1f;
				base.npc.ai[0] %= 6.88318548f;
				new Vector2((float)Math.Cos((double)base.npc.ai[0]), (float)Math.Sin((double)base.npc.ai[0]));
				Main.PlaySound(2, (int)base.npc.position.X, (int)base.npc.position.Y, 20, 1f, 0f);
				base.npc.ai[2] = -310f;
				new Rectangle((int)base.npc.position.X, (int)(base.npc.position.Y + (float)((base.npc.height - base.npc.width) / 2)), base.npc.width, base.npc.width);
				int num2 = 30;
				for (int i = 1; i <= num2; i++)
				{
					int num3 = Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, base.mod.DustType("AttackOrbDust"), 0f, 0f, 0, default(Color), 1f);
					Main.dust[num3].noGravity = false;
				}
			}
			
			if(Main.expertMode)
			{
				if (npc.ai[1] >= 135)
				{
					Vector2 vector = new Vector2(base.npc.position.X + (float)base.npc.width * 0.5f, base.npc.position.Y + (float)base.npc.height * 0.5f);
					
					int num6 = 1;
					float num7 = player.position.X + (float)(player.width / 2) + (float)(num6 * 180) - vector.X;
					float num8 = player.position.Y + (float)(player.height / 2) - vector.Y;
					float num9 = (float)Math.Sqrt((double)(num7 * num7 + num8 * num8));		
					float num10 = 8f;
					int num11 = 25;
					int type = base.mod.ProjectileType("AttackOrbOuch");
					vector = new Vector2(base.npc.position.X + (float)base.npc.width * 0.5f, base.npc.position.Y + (float)base.npc.height * 0.5f);
					num7 = player.position.X + (float)(player.width / 2) - vector.X;
					num8 = player.position.Y + (float)(player.height / 2) - vector.Y;
					num9 = (float)Math.Sqrt((double)(num7 * num7 + num8 * num8));
					num9 = num10 / num9;
					num7 *= num9;
					num8 *= num9;
					num8 += (float)Main.rand.Next(-40, 41) * 0.01f;
					num7 += (float)Main.rand.Next(-40, 41) * 0.01f;
					num8 += base.npc.velocity.Y * 0.6f;
					num7 += base.npc.velocity.X * 0.6f;
					vector.X -= num7 * 1f;
					vector.Y -= num8 * 1f;
					Projectile.NewProjectile(vector.X - 3, vector.Y - 3, num7 - 2, num8 - 2, type, num11, 0f, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(vector.X + 2, vector.Y + 2, num7 + 3, num8 + 3, type, num11, 0f, Main.myPlayer, 0f, 0f);
					npc.ai[1] = 0;
				}
			}
			else
			{
				if (npc.ai[1] >= 160)
				{
					Vector2 vector = new Vector2(base.npc.position.X + (float)base.npc.width * 0.5f, base.npc.position.Y + (float)base.npc.height * 0.5f);
					
					int num6 = 1;
					float num7 = player.position.X + (float)(player.width / 2) + (float)(num6 * 180) - vector.X;
					float num8 = player.position.Y + (float)(player.height / 2) - vector.Y;
					float num9 = (float)Math.Sqrt((double)(num7 * num7 + num8 * num8));		
					float num10 = 9f;
					int num11 = 35;
					int type = base.mod.ProjectileType("AttackOrbOuch");
					vector = new Vector2(base.npc.position.X + (float)base.npc.width * 0.5f, base.npc.position.Y + (float)base.npc.height * 0.5f);
					num7 = player.position.X + (float)(player.width / 2) - vector.X;
					num8 = player.position.Y + (float)(player.height / 2) - vector.Y;
					num9 = (float)Math.Sqrt((double)(num7 * num7 + num8 * num8));
					num9 = num10 / num9;
					num7 *= num9;
					num8 *= num9;
					num8 += (float)Main.rand.Next(-40, 41) * 0.01f;
					num7 += (float)Main.rand.Next(-40, 41) * 0.01f;
					num8 += base.npc.velocity.Y * 0.6f;
					num7 += base.npc.velocity.X * 0.6f;
					vector.X -= num7 * 1f;
					vector.Y -= num8 * 1f;
					Projectile.NewProjectile(vector.X, vector.Y, num7, num8, type, num11, 0f, Main.myPlayer, 0f, 0f);
					npc.ai[1] = 0;
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
				int num = 6;
				base.npc.localAI[0] += (float)Main.rand.Next(num);
				if (base.npc.localAI[0] >= (float)Main.rand.Next(460, 960))
				{
					base.npc.localAI[0] = 0f;
					Main.PlaySound(3, (int)base.npc.position.X, (int)base.npc.position.Y, 20, 1f, 0f);
					for (int i = 0; i < 2; i++)
					{
						int num2 = Dust.NewDust(new Vector2(base.npc.position.X, base.npc.position.Y), base.npc.width, base.npc.height, mod.DustType("AttackOrbDust"), 0f, 0f, 100, default(Color), 1f);
						Main.dust[num2].velocity *= 1.2f;
						if (Main.rand.Next(7) == 0)
						{
							Main.dust[num2].scale = 0.3f;

						}
					}
				}
			}
		
			if (base.npc.position.Y > player.position.Y - 120f)
			{
				if (base.npc.velocity.Y > 0f)
				{
					base.npc.velocity.Y = base.npc.velocity.Y * 0.98f;
				}
				base.npc.velocity.Y = base.npc.velocity.Y - 0.1f;
				if (base.npc.velocity.Y > 2f)
				{
					base.npc.velocity.Y = 2f;
				}
			}
			else if (base.npc.position.Y < player.position.Y - 380f)
			{
				if (base.npc.velocity.Y < 0f)
				{
					base.npc.velocity.Y = base.npc.velocity.Y * 0.98f;
				}
				base.npc.velocity.Y = base.npc.velocity.Y + 0.1f;
				if (base.npc.velocity.Y < -2f)
				{
					base.npc.velocity.Y = -2f;
				}
			}
			if (base.npc.position.X + (float)(base.npc.width / 2) > player.position.X + (float)(player.width / 2) + 40f)
			{
				if (base.npc.velocity.X > 0f)
				{
					base.npc.velocity.X = base.npc.velocity.X * 0.44f;
				}
				base.npc.velocity.X = base.npc.velocity.X - 0.1f;
				if (base.npc.velocity.X > 2f)
				{
					base.npc.velocity.X = 2f;
				}
			}
			if (base.npc.position.X + (float)(base.npc.width / 2) < player.position.X + (float)(player.width / 2) - 40f)
			{
				if (base.npc.velocity.X < 0f)
				{
					base.npc.velocity.X = base.npc.velocity.X * 0.43f;
				}
				base.npc.velocity.X = base.npc.velocity.X + 0.1f;
				if (base.npc.velocity.X < -2f)
				{
					base.npc.velocity.X = -2f;
				}
			}
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (base.npc.life <= 0)
			{
				for (int i = 0; i < 12; i++)
				{
					int num = Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, mod.DustType("AttackOrbDust"), 0f, 0f, 0, default(Color), 1f);
					Dust dust = Main.dust[num];
					dust.velocity.X = dust.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust.velocity.Y = dust.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust.scale *= 1.4f + (float)Main.rand.Next(-31, 31) * 0.012f;
				}
				for (int i = 0; i < 11; i++)
				{
					int num = Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, mod.DustType("AttackOrbDust"), 0f, 0f, 0, default(Color), 1f);
					Dust dust = Main.dust[num];
					dust.velocity.X = dust.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust.velocity.Y = dust.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust.scale *= 1.35f + (float)Main.rand.Next(-31, 31) * 0.014f;
				}
				for (int i = 0; i < 12; i++)
				{
					int num = Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, mod.DustType("AttackOrbDust"), 0f, 0f, 0, default(Color), 1f);
					Dust dust = Main.dust[num];
					dust.velocity.X = dust.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust.velocity.Y = dust.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust.scale *= 1.4f + (float)Main.rand.Next(-31, 31) * 0.012f;
				}
				for (int i = 0; i < 11; i++)
				{
					int num = Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, mod.DustType("AttackOrbDust"), 0f, 0f, 0, default(Color), 1f);
					Dust dust = Main.dust[num];
					dust.velocity.X = dust.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust.velocity.Y = dust.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust.scale *= 1.35f + (float)Main.rand.Next(-31, 31) * 0.014f;
				}
			}
		}	
    }
}