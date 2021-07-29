using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Archeon.Projectiles.Magic
{
	public class BloodyPlashProj : ModProjectile
	{
		public override string Texture
		{
			get
			{
				return "Archeon/Projectiles/BlankProj";
			}
		}
		
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 220;
			projectile.magic = true;
			projectile.tileCollide = true;
			Main.PlaySound(SoundID.Item15, projectile.position);
		}
			
		public override void AI()
		{
			Lighting.AddLight(projectile.Center, 0.230f, 0.094f, 0.073f);
				
			int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, 114, projectile.velocity.X / 2, projectile.velocity.Y / 2, 100, default(Color), 1.4f);
			Main.dust[num].noGravity = true;
			Main.dust[num].velocity /= 2;
			Main.dust[num].color = Color.Crimson;
			
			if(Main.rand.Next(1) == 0)
			{
				int num168 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 90, 0f, 0f, 100, default(Color), 1.2f);
				Main.dust[num168].noGravity = true;
				Main.dust[num168].velocity /= 1.5f;
				Main.dust[num168].color = Color.Red;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			int projNr = Main.rand.Next(3, 4);
			for (int i = 0; i < projNr; i++)
			{
				Vector2 vector = new Vector2(projectile.Center.X, projectile.Center.Y);
				float Stuff = Main.rand.Next(-3, 3);
				Projectile.NewProjectile(vector.X, vector.Y, projectile.velocity.X * 1.05f, (projectile.velocity.Y + Stuff) * 1.05f, mod.ProjectileType("BloodyPlashSplitProj"), projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
			}
			projectile.Kill();
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item74, projectile.position);
			for (int i = 0; i < 12; i++)
			{
				int num2 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 114, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f, 0, Color.LightPink, 1f);
				Main.dust[num2].noGravity = true;
			}
		}
	}
	
	public class BloodyPlashSplitProj : ModProjectile
	{
		public override string Texture
		{
			get
			{
				return "Archeon/Projectiles/BlankProj";
			}
		}
		
		public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 8;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.magic = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.timeLeft = 160;
		}
		bool homing = false;
		int timer;
		int oldDamage;
		bool getOldDamage = true;
		public override void AI()
		{
			timer++;
			Player player = Main.player[projectile.owner];
			
			if(getOldDamage == true)
			{
				oldDamage = projectile.damage;
				getOldDamage = false;
			}
			
			if(homing == true)
			{
				projectile.damage = oldDamage;
				float num2 = (float)Math.Sqrt((double)(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y));
				float num3 = projectile.localAI[0];
				if (num3 == 0f)
				{
					projectile.localAI[0] = num2;
					num3 = num2;
				}
				float num4 = projectile.position.X;
				float num5 = projectile.position.Y;
				float num6 = 400f;
				bool flag = false;
				int num7 = 0;
				if (projectile.ai[1] == 0f)
				{
					for (int i = 0; i < 200; i++)
					{
						if (Main.npc[i].CanBeChasedBy(this, false) && (projectile.ai[1] == 0f || projectile.ai[1] == (float)(i + 1)))
						{
							float num8 = Main.npc[i].position.X + (float)(Main.npc[i].width / 2);
							float num9 = Main.npc[i].position.Y + (float)(Main.npc[i].height / 2);
							float num10 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num8) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num9);
							if (num10 < num6 && Collision.CanHit(new Vector2(projectile.position.X + (float)(projectile.width / 2), projectile.position.Y + (float)(projectile.height / 2)), 1, 1, Main.npc[i].position, Main.npc[i].width, Main.npc[i].height))
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
						projectile.ai[1] = (float)(num7 + 1);
					}
					flag = false;
				}
				if (projectile.ai[1] > 0f)
				{
					int num11 = (int)(projectile.ai[1] - 1f);
					if (Main.npc[num11].active && Main.npc[num11].CanBeChasedBy(this, true) && !Main.npc[num11].dontTakeDamage)
					{
						float num12 = Main.npc[num11].position.X + (float)(Main.npc[num11].width / 2);
						float num13 = Main.npc[num11].position.Y + (float)(Main.npc[num11].height / 2);
						if (Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num12) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num13) < 1000f)
						{
							flag = true;
							num4 = Main.npc[num11].position.X + (float)(Main.npc[num11].width / 2);
							num5 = Main.npc[num11].position.Y + (float)(Main.npc[num11].height / 2);
						}
					}
					else
					{
						projectile.ai[1] = 0f;
					}
				}
				if (!projectile.friendly)
				{
					flag = false;
				}
				if (flag)
				{
					float num14 = num3;
					Vector2 vector = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
					float num15 = num4 - vector.X;
					float num16 = num5 - vector.Y;
					float num17 = (float)Math.Sqrt((double)(num15 * num15 + num16 * num16));
					num17 = num14 / num17;
					num15 *= num17;
					num16 *= num17;
					int num18 = 8;
					projectile.velocity.X = (projectile.velocity.X * (float)(num18 - 1) + num15) / (float)num18;
					projectile.velocity.Y = (projectile.velocity.Y * (float)(num18 - 1) + num16) / (float)num18;
				}
			}
			else
			{
				projectile.damage = 0;
				if(timer == 10)
				{
					homing = true;
				}
			}
		
			for (int num163 = 0; num163 < 10; num163++)
			{
				float x2 = projectile.position.X - projectile.velocity.X / 10f * (float)num163;
				float y2 = projectile.position.Y - projectile.velocity.Y / 10f * (float)num163;
				int num164 = Dust.NewDust(new Vector2(x2, y2), 1, 1, 90);	
				Main.dust[num164].position.X = x2;
				Main.dust[num164].position.Y = y2;
				Main.dust[num164].velocity *= 0f;
				Main.dust[num164].noGravity = true;
				Main.dust[num164].color = Color.Red;
				Main.dust[num164].scale = 0.97f;
			}
		}
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item10, projectile.position);
			for (int i = 0; i < 8; i++)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 90, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f, 0, default(Color), 1f);
			}
		}
	}
}
