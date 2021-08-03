using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Projectiles.Magic
{
	public class ChronicleOfSindomProj : ModProjectile
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
			projectile.width = 12;
			projectile.height = 12;
			projectile.friendly = true;
			projectile.penetrate = 4;
			projectile.timeLeft = 240;
			projectile.magic = true;
			Main.PlaySound(SoundID.Item15, projectile.position);
			projectile.hide = true;
		}
		
		public static Vector2 helixVector(float radius, float theta)
        {
            return new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta)) * radius; 
        }
		
		private float arcLength = 25; 
        private float arcSize = 30;
		
		bool onceDone = true;
		private float counter = 0; 
        private float spawnDirection = 0;
        private float previousI = 0; 
		private Projectile secondProjectile = null; 
		
		int changeTimer;
		float dustScale1 = 1.25f;
		
		public override void AI()
		{
			if(onceDone) 
			{
				spawnDirection = projectile.velocity.ToRotation();
				if(Main.netMode != 2 && projectile.owner == Main.myPlayer)
				{
					if(projectile.ai[0] == 0)
					{
						projectile.velocity *= 0.95f;
						secondProjectile = Main.projectile[Projectile.NewProjectile(projectile.Center, projectile.velocity, mod.ProjectileType("ChronicleOfSindomProj2"), projectile.damage, projectile.knockBack, projectile.owner, 1, projectile.whoAmI)];
					}
				}
				onceDone = false;
				
			}
			counter += 1 * (float)Math.PI / arcLength;
            float i = arcSize * (float)Math.Sin(counter) * (projectile.ai[0] == 0 ? 1 : -1); 
            Vector2 helixVelocity = helixVector(i - previousI, spawnDirection + (float)Math.PI / 2);
            projectile.Center += helixVelocity;
            previousI = i; 
            projectile.rotation = (projectile.velocity + helixVelocity).ToRotation() + (float)Math.PI / 2;
			
			changeTimer++;
			if(changeTimer == 20)
			{
				for (int dicks = 0; dicks < 10; dicks++)
				{
					int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num].velocity *= 1.75f;
					Main.dust[num].noGravity = true;
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num].scale = 0.75f;
						Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
					}
				}
			}
			if(changeTimer < 20)
			{
				for (int num163 = 0; num163 < 15; num163++)
				{
					float x2 = projectile.Center.X - projectile.velocity.X / 10f * (float)num163;
					float y2 = projectile.Center.Y - projectile.velocity.Y / 10f * (float)num163;
					int num164 = Dust.NewDust(new Vector2(x2, y2), 1, 1, 159);	
					Main.dust[num164].position.X = x2;
					Main.dust[num164].position.Y = y2;
					Main.dust[num164].velocity *= 0f;
					Main.dust[num164].noGravity = true;
					Main.dust[num164].noLight = true;
				}
			}
			else
			{
				for (int num163 = 0; num163 < 10; num163++)
				{
					float x2 = projectile.Center.X - projectile.velocity.X / 10f * (float)num163;
					float y2 = projectile.Center.Y - projectile.velocity.Y / 10f * (float)num163;
					int num164 = Dust.NewDust(new Vector2(x2, y2), 1, 1, 6);	
					Main.dust[num164].position.X = x2;
					Main.dust[num164].position.Y = y2;
					Main.dust[num164].velocity *= 0f;
					Main.dust[num164].noGravity = true;
					Main.dust[num164].noLight = true;
					Main.dust[num164].scale = dustScale1;
				}
			}
			
			if(changeTimer == 25 || changeTimer == 50)
			{
				projectile.width += 2;
				projectile.height += 2;
				dustScale1 += 0.2f;
				projectile.damage += projectile.damage / 10;
				for (int j = 0; j < 8; j++)
				{
					int num2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num2].noGravity = true;
					Main.dust[num2].velocity *= 3.75f;
				}
				
				for (int eef = 0; eef < 4; eef++)
				{
					float stuff = Main.rand.Next(-7, 7);
					float stuff2 = Main.rand.Next(-7, 7);
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, stuff, stuff2, mod.ProjectileType("ChronicleOfSindomShard1"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
				}
				changeTimer = 26;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if(changeTimer >= 20)
			{
				target.AddBuff(24, 220, false);
			}
		}
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item10, projectile.position);
			if(changeTimer < 20)
			{
				for(int i = 0; i < 8; i++)
				{
					int num = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 269, projectile.velocity.X, projectile.velocity.Y, 0, default(Color), 1f);
					Main.dust[num].velocity /= 15f;
					Main.dust[num].scale = 1.05f;
					Main.dust[num].noGravity = true;
				}
			}
			else
			{
				for(int i = 0; i < 8; i++)
				{
					int num = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.velocity.X, projectile.velocity.Y, 0, default(Color), 1f);
					Main.dust[num].velocity /= 5f;
					Main.dust[num].scale = 1.15f;
					Main.dust[num].noGravity = true;
				}
			}
		}
	}
	
	public class ChronicleOfSindomProj2 : ModProjectile
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
			projectile.width = 12;
			projectile.height = 12;
			projectile.friendly = true;
			projectile.penetrate = 4;
			projectile.timeLeft = 240;
			projectile.magic = true;
			Main.PlaySound(SoundID.Item15, projectile.position);
			projectile.hide = true;
		}
		
		public static Vector2 helixVector(float radius, float theta)
        {
            return new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta)) * radius; 
        }
		
		
		private float arcLength = 25; 
        private float arcSize = 30;
		
		bool onceDone = true;
		private float counter = 0; 
        private float spawnDirection = 0;
        private float previousI = 0; 
		
		int changeTimer;
		float dustScale1 = 1.2f;
		
		public override void AI()
		{
			if(onceDone) 
			{
				spawnDirection = projectile.velocity.ToRotation();
				if(Main.netMode != 2 && projectile.owner == Main.myPlayer)
				{
					if(projectile.ai[0] == 0)
					{
						projectile.velocity *= 0.95f;
					}
				}
				onceDone = false;
				
			}
			counter += 1 * (float)Math.PI / arcLength;
            float i = arcSize * (float)Math.Sin(counter) * (projectile.ai[0] == 0 ? 1 : -1); 
            Vector2 helixVelocity = helixVector(i - previousI, spawnDirection + (float)Math.PI / 2);
            projectile.Center += helixVelocity;
            previousI = i; 
            projectile.rotation = (projectile.velocity + helixVelocity).ToRotation() + (float)Math.PI / 2;
			
			changeTimer++;
			if(changeTimer == 20)
			{
				for (int dicks = 0; dicks < 10; dicks++)
				{
					int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 92, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num].velocity *= 1.75f;
					Main.dust[num].noGravity = true;
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num].scale = 0.75f;
						Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
					}
				}
			}
			if(changeTimer < 20)
			{
				for (int num163 = 0; num163 < 15; num163++)
				{
					float x2 = projectile.Center.X - projectile.velocity.X / 10f * (float)num163;
					float y2 = projectile.Center.Y - projectile.velocity.Y / 10f * (float)num163;
					int num164 = Dust.NewDust(new Vector2(x2, y2), 1, 1, 159);	
					Main.dust[num164].position.X = x2;
					Main.dust[num164].position.Y = y2;
					Main.dust[num164].velocity *= 0f;
					Main.dust[num164].noGravity = true;
					Main.dust[num164].noLight = true;
				}
			}
			else
			{
				for (int num163 = 0; num163 < 10; num163++)
				{
					float x2 = projectile.Center.X - projectile.velocity.X / 10f * (float)num163;
					float y2 = projectile.Center.Y - projectile.velocity.Y / 10f * (float)num163;
					int num164 = Dust.NewDust(new Vector2(x2, y2), 1, 1, 92);	
					Main.dust[num164].position.X = x2;
					Main.dust[num164].position.Y = y2;
					Main.dust[num164].velocity *= 0f;
					Main.dust[num164].noGravity = true;
					Main.dust[num164].noLight = true;
					Main.dust[num164].scale = dustScale1;
				}
			}
			
			if(changeTimer == 25 || changeTimer == 50)
			{
				projectile.width += 2;
				projectile.height += 2;
				dustScale1 += 0.15f;
				projectile.damage += projectile.damage / 10;
				for (int j = 0; j < 8; j++)
				{
					int num2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 92, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num2].noGravity = true;
					Main.dust[num2].velocity *= 3f;
				}
				
				for (int eef = 0; eef < 4; eef++)
				{
					float stuff = Main.rand.Next(-7, 7);
					float stuff2 = Main.rand.Next(-7, 7);
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, stuff, stuff2, mod.ProjectileType("ChronicleOfSindomShard2"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
				}
				changeTimer = 26;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if(changeTimer >= 20)
			{
				target.AddBuff(44, 220, false);
			}
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item10, projectile.position);
			if(changeTimer < 20)
			{
				for(int i = 0; i < 8; i++)
				{
					int num = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 269, projectile.velocity.X, projectile.velocity.Y, 0, default(Color), 1f);
					Main.dust[num].velocity /= 15f;
					Main.dust[num].scale = 1.05f;
					Main.dust[num].noGravity = true;
				}
			}
			else
			{
				for(int i = 0; i < 8; i++)
				{
					int num = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 92, projectile.velocity.X, projectile.velocity.Y, 0, default(Color), 1f);
					Main.dust[num].velocity /= 15f;
					Main.dust[num].scale = 1.05f;
					Main.dust[num].noGravity = true;
				}
			}
		}
	}
	
	public class ChronicleOfSindomShard1 : ModProjectile
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
			projectile.timeLeft = 45;
		}

		public override void AI()
		{
			if(Main.rand.Next(2) == 0)
			{
				int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X / 2, projectile.velocity.Y / 2, 100, default(Color), 1.4f);
				Main.dust[num].noGravity = true;
				Main.dust[num].velocity /= 3;
				Main.dust[num].scale = 1.1f;
			}
			
			if(Main.rand.Next(3) == 0)
			{
				int num168 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1.2f);
				Main.dust[num168].noGravity = true;
				Main.dust[num168].velocity /= 1.5f;
				Main.dust[num168].scale = 1.1f;
			}
		}
		
		public override void Kill(int timeLeft)
		{
			for(int i = 0; i < 3; i++)
			{
				int num = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.velocity.X, projectile.velocity.Y, 0, default(Color), 1f);
				Main.dust[num].velocity /= 15f;
				Main.dust[num].noGravity = true;
			}
		}
	}
	
	public class ChronicleOfSindomShard2 : ModProjectile
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
			projectile.timeLeft = 45;
		}

		public override void AI()
		{
			if(Main.rand.Next(2) == 0)
			{
				int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, 92, projectile.velocity.X / 2, projectile.velocity.Y / 2, 100, default(Color), 1.4f);
				Main.dust[num].noGravity = true;
				Main.dust[num].velocity /= 3;
			}
			
			if(Main.rand.Next(3) == 0)
			{
				int num168 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 92, 0f, 0f, 100, default(Color), 1.2f);
				Main.dust[num168].noGravity = true;
				Main.dust[num168].velocity /= 1.5f;
			}
		}
		
		public override void Kill(int timeLeft)
		{
			for(int i = 0; i < 3; i++)
			{
				int num = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 92, projectile.velocity.X, projectile.velocity.Y, 0, default(Color), 1f);
				Main.dust[num].velocity /= 15f;
				Main.dust[num].noGravity = true;
			}
		}
	}
}
