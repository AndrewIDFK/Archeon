using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Projectiles.Melee
{
	public class BloodthirstProj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.timeLeft = 120;
			projectile.penetrate = 2;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.aiStyle = 1;
			aiType = 48;
			projectile.melee = true;
		}

		public override void AI()
		{	
			if(Main.rand.Next(8) == 0)
			{ 
				int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, 125, projectile.velocity.X / 2, projectile.velocity.Y / 2, 100, default(Color), 1.4f);
				Main.dust[num].noGravity = true;
				Main.dust[num].velocity /= 2;
				Main.dust[num].color = Color.Crimson;
			}
		
			if(Main.rand.Next(12) == 0)
			{
				int num168 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 114, 0f, 0f, 100, default(Color), 1.2f);
				Main.dust[num168].noGravity = true;
				Main.dust[num168].velocity /= 1.5f;
				Main.dust[num168].color = Color.Red;
			}
			
			float num2 = (float)Math.Sqrt((double)(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y));
			float num3 = projectile.localAI[0];
			if (num3 == 0f)
			{
				projectile.localAI[0] = num2;
				num3 = num2;
			}
			float num4 = projectile.position.X;
			float num5 = projectile.position.Y;
			float num6 = 145f;
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
					}
				}
				else
				{
					projectile.ai[1] = 0f;
				}
			}
			if (flag)
			{
				projectile.Kill();
			}
		}
		
		public override void Kill(int timeLeft) 
		{	
			for (int i = 0; i < 3; i++)
			{
				int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 125, projectile.velocity.X / 5, projectile.velocity.Y / 5, 100, default(Color), 1f);
				Main.dust[num].noLight = true;
				Main.dust[num].color = Color.Crimson;
				Main.dust[num].noGravity = true;
				Main.dust[num].scale = 0.9f;
				if(Main.rand.Next(6) == 0)
				{
					num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 114, 0f, 0f, 100, default(Color), 1f);
					Main.dust[num].color = Color.Crimson;
				}
			}
			
			for (int i = 0; i < 3; i++)
			{
				Vector2 value = Utils.RotatedByRandom(projectile.velocity, (double)MathHelper.ToRadians(18.5f));
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, value.X, value.Y, mod.ProjectileType("BloodthirstBloodProj"), projectile.damage, projectile.knockBack / 2, projectile.owner, 0f, 0f);
			}
		}
	}
	
	public class BloodthirstBloodProj : ModProjectile
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
			projectile.timeLeft = 140;
			projectile.melee = true;
			projectile.hide = true;
		}

		public override void AI()
		{
			projectile.ai[0] += 1f;
			if (projectile.ai[0] >= 6f)
			{
				projectile.ai[0] = 6f;
				projectile.velocity.Y = projectile.velocity.Y + 0.2f;
			}
			
			for (int i = 0; i < 5; i++)
			{
				float x = projectile.position.X - projectile.velocity.X / 5f * (float)i;
				float y = projectile.position.Y - projectile.velocity.Y / 5f * (float)i;
				int num = Dust.NewDust(new Vector2(x, y), 1, 1, 125);	
				Main.dust[num].position.X = x;
				Main.dust[num].position.Y = y;
				Main.dust[num].velocity *= 0.05f;
				Main.dust[num].noGravity = true;
				Main.dust[num].color = Color.Red;
				Main.dust[num].scale = 0.95f;
			}
		}
		
		public override void Kill(int timeLeft) 
		{	
			for (int i = 0; i < 3; i++)
			{
				int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 125, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num].noLight = true;
				Main.dust[num].color = Color.Red;
				Main.dust[num].noGravity = true;
				Main.dust[num].scale = 0.9f;
				if(Main.rand.Next(6) == 0)
				{
					Main.dust[num].velocity *= 1.3f;
				}
			}
		}
	}
}