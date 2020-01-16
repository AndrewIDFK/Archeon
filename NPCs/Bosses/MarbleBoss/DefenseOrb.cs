using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.NPCs.Bosses.MarbleBoss
{
    public class DefenseOrb : ModNPC
    {
		private int marbieHeal;
		
		
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Defense Orb");
		}
		
        public override void SetDefaults()
        {
			base.npc.aiStyle = 14;
			this.aiType = 152;
			base.npc.damage = 22;
			base.npc.width = 36;
			base.npc.height = 36;
			base.npc.defense = 30;
			base.npc.lifeMax = 950;
			base.npc.knockBackResist = 0.21f;
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
			base.npc.lifeMax = (int)((float)base.npc.lifeMax * 0.62f * bossLifeScale);
			base.npc.damage = (int)((float)base.npc.damage * 1.02f);
		}
		
		public override void AI()
		{
			
			Lighting.AddLight((int)((base.npc.position.X + (float)(base.npc.width / 2)) / 16f), (int)((base.npc.position.Y + (float)(base.npc.height / 2)) / 16f), 0.11f, 0.36f, 0.96f);
			Player player = Main.player[base.npc.target];
			bool flag2 = Main.expertMode;
			//base.npc.dontTakeDamage = (!player.ZoneHoly);
	
			bool expertBoomer = Main.expertMode || !Main.expertMode;
			int numxd = Dust.NewDust(base.npc.position + base.npc.velocity, base.npc.width, base.npc.height, mod.DustType("DefenseOrbDust"), base.npc.velocity.X * 2f, base.npc.velocity.Y * 2f, 100, default(Color), 1.4f);
			Main.dust[numxd].velocity /= 50f;
			Main.dust[numxd].scale = 1.2f;
			Main.dust[numxd].noGravity = true;
			Main.dust[numxd].fadeIn = 1.2f;
			
			
			
			
			
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
						int num2 = Dust.NewDust(new Vector2(base.npc.position.X, base.npc.position.Y), base.npc.width, base.npc.height, mod.DustType("DefenseOrbDust"), 0f, 0f, 100, default(Color), 1f);
						Main.dust[num2].velocity *= 1.2f;
						if (Main.rand.Next(7) == 0)
						{
							Main.dust[num2].scale = 0.3f;

						}
					}
					
					
				}
			}
			
			
			
			/*this.Timer--;
			if (this.Timer <= Main.rand.Next(50, 100))
			{
				if (Main.rand.Next(2) == 1)
				{
					Projectile.NewProjectile(base.npc.position, new Vector2(8f), base.mod.ProjectileType("DefenseOrbHealingUp"), 1, 0f, 255, 0f, 0f);
				}
				
				
				
				this.Timer = Main.rand.Next(300, 500);
			}*/
			
			/*if (npc.ai[1] >= 150)
			{
				Vector2 vector = new Vector2(base.npc.position.X + (float)base.npc.width + 10f, base.npc.position.Y + (float)base.npc.height + 10f);
				
				int numberProjectiles = 6;
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.ToRadians(100f * i));

					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI, i);
				}
				int num6 = 1;
				float num7 = player.position.X + (float)(player.width / 2) + (float)(num6 * 180) - vector.X;
				float num8 = player.position.Y + (float)(player.height / 2) - vector.Y;
				float num9 = (float)Math.Sqrt((double)(num7 * num7 + num8 * num8));		
				float num10 = 8f;
				int num11 = 1;
				int type = base.mod.ProjectileType("DefenseOrbHealingUp2");
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
			}*/
			
			
		
			if (base.npc.position.Y > player.position.Y - 210f)
			{
				if (base.npc.velocity.Y > 0f)
				{
					base.npc.velocity.Y = base.npc.velocity.Y * 0.94f;
				}
				base.npc.velocity.Y = base.npc.velocity.Y - 0.1f;
				if (base.npc.velocity.Y > 2f)
				{
					base.npc.velocity.Y = 2f;
				}
			}
			else if (base.npc.position.Y < player.position.Y - 510f)
			{
				if (base.npc.velocity.Y < 0f)
				{
					base.npc.velocity.Y = base.npc.velocity.Y * 0.94f;
				}
				base.npc.velocity.Y = base.npc.velocity.Y + 0.1f;
				if (base.npc.velocity.Y < -2f)
				{
					base.npc.velocity.Y = -2f;
				}
			}
			if (base.npc.position.X + (float)(base.npc.width / 2) > player.position.X + (float)(player.width / 2) + 125f)
			{
				if (base.npc.velocity.X > 0f)
				{
					base.npc.velocity.X = base.npc.velocity.X * 0.28f;
				}
				base.npc.velocity.X = base.npc.velocity.X - 0.1f;
				if (base.npc.velocity.X > 2f)
				{
					base.npc.velocity.X = 2f;
				}
			}
			if (base.npc.position.X + (float)(base.npc.width / 2) < player.position.X + (float)(player.width / 2) - 125f)
			{
				if (base.npc.velocity.X < 0f)
				{
					base.npc.velocity.X = base.npc.velocity.X * 0.28f;
				}
				base.npc.velocity.X = base.npc.velocity.X + 0.1f;
				if (base.npc.velocity.X < -2f)
				{
					base.npc.velocity.X = -2f;
				}
			}
			if (base.npc.ai[3] == 0f && base.npc.life > 0)
			{
				base.npc.ai[3] = (float)base.npc.lifeMax;
			}
			
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (base.npc.life <= 0)
			{
				for (int i = 0; i < 12; i++)
				{
					int num = Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, mod.DustType("DefenseOrbDust"), 0f, 0f, 0, default(Color), 1f);
					Dust dust = Main.dust[num];
					dust.velocity.X = dust.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust.velocity.Y = dust.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust.scale *= 1.3f + (float)Main.rand.Next(-31, 31) * 0.014f;
				}
				for (int i = 0; i < 11; i++)
				{
					int num = Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, mod.DustType("DefenseOrbDust"), 0f, 0f, 0, default(Color), 1f);
					Dust dust = Main.dust[num];
					dust.velocity.X = dust.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust.velocity.Y = dust.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust.scale *= 1.3f + (float)Main.rand.Next(-31, 31) * 0.014f;
				}
				for (int i = 0; i < 12; i++)
				{
					int num = Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, mod.DustType("DefenseOrbDust"), 0f, 0f, 0, default(Color), 1f);
					Dust dust = Main.dust[num];
					dust.velocity.X = dust.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust.velocity.Y = dust.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust.scale *= 1.3f + (float)Main.rand.Next(-31, 31) * 0.014f;
				}
				for (int i = 0; i < 11; i++)
				{
					int num = Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, mod.DustType("DefenseOrbDust"), 0f, 0f, 0, default(Color), 1f);
					Dust dust = Main.dust[num];
					dust.velocity.X = dust.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust.velocity.Y = dust.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust.scale *= 1.3f + (float)Main.rand.Next(-31, 31) * 0.014f;
				}
			}
		}
    }
}