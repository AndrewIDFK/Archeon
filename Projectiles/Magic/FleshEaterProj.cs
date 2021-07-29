using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Projectiles.Magic
{
	public class FleshEaterProj : ModProjectile
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
			projectile.width = 28;
			projectile.height = 28;
			projectile.friendly = true;
			projectile.penetrate = 6;
			projectile.timeLeft = 340;
			projectile.magic = true;
			projectile.tileCollide = true;
			Main.PlaySound(SoundID.Item15, projectile.position);
		}
		
		int chanceNumber1 = 2;
		int chanceNumber2 = 4;
		int multipleNumber = 1;
		bool lastPenetration = false;
		bool bool1 = true;
		bool bool2 = true;
		bool bool3 = true;
		bool bool4 = true;
		bool bool5 = true;
		public override void AI()
		{
			Lighting.AddLight(projectile.Center, 0.139f, 0.059f, 0.153f);
			
			if(projectile.penetrate == 5 && bool1)
			{
				chanceNumber1 = 2;
				chanceNumber2 = 3;
				projectile.width = 30;
				projectile.height = 30;
				projectile.damage += projectile.damage / 10;
				projectile.velocity *= 1.05f;
				bool1 = false;
			}
			if(projectile.penetrate == 4 && bool2)
			{
				chanceNumber1 = 2;
				chanceNumber2 = 2;
				projectile.width = 34;
				projectile.height = 34;
				projectile.scale = 1.05f;
				projectile.damage += projectile.damage / 9;
				projectile.velocity *= 1.05f;
				bool2 = false;
			}
			if(projectile.penetrate == 3 && bool3)
			{
				chanceNumber1 = 1;
				chanceNumber2 = 2;
				multipleNumber = 2;
				projectile.width = 38;
				projectile.height = 38;
				projectile.scale = 1.1f;
				projectile.damage += projectile.damage / 8;
				projectile.velocity *= 1.05f;
				bool3 = false;
			}
			if(projectile.penetrate == 2 && bool4)
			{
				chanceNumber1 = 1;
				chanceNumber2 = 1;
				projectile.width = 44;
				projectile.height = 44;
				projectile.scale = 1.25f;
				projectile.damage += projectile.damage / 7;
				projectile.velocity *= 1.05f;
				bool4 = false;
			}
			if(projectile.penetrate == 1 && bool5)
			{
				chanceNumber1 = 0;
				chanceNumber2 = 0;
				multipleNumber = 3;
				projectile.width = 50;
				projectile.height = 50;
				projectile.scale = 1.5f;
				lastPenetration = true;
				projectile.damage += projectile.damage / 5;
				projectile.velocity *= 1.05f;
				bool5 = false;
			}
			if(Main.rand.Next(chanceNumber1) == 0)
			{ 
				for(int i = 0; i < multipleNumber; i++)
				{
					int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, 179, projectile.velocity.X / 2, projectile.velocity.Y / 2, 100, default(Color), 1.4f);
					Main.dust[num].noGravity = true;
					Main.dust[num].velocity /= 2;
					Main.dust[num].scale = 0.95f;
					Main.dust[num].color = Color.Indigo;
				}
			}
		
			if(Main.rand.Next(chanceNumber2) == 0)
			{
				for(int i = 0; i < multipleNumber; i++)
				{
					int num168 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 112, 0f, 0f, 100, default(Color), 1.2f);
					Main.dust[num168].noGravity = true;
					Main.dust[num168].velocity /= 1.5f;
					Main.dust[num168].color = Color.Purple;
				}
				
				int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, 157, projectile.velocity.X / 2, projectile.velocity.Y / 2, 100, default(Color), 1.4f);
				Main.dust[num].noGravity = true;
				Main.dust[num].color = Color.Black;
			}
		
		}

		public override void Kill(int timeLeft)
		{
			if(lastPenetration)
			{
				Main.PlaySound(SoundID.Item74, projectile.position); 
				for(int i = 0; i < 9; i++)
				{
					int num = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 179, projectile.velocity.X, projectile.velocity.Y, 0, default(Color), 1f);
					Main.dust[num].velocity /= 2;
					Main.dust[num].scale = 1.15f;
				}
				for(int i = 0; i < 3; i++)
				{
					int num = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 157, projectile.velocity.X, projectile.velocity.Y, 0, default(Color), 1f);
					Main.dust[num].velocity /= 2;
					Main.dust[num].scale = 1.15f;
				}

				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14, 1f, 0f);
				projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
				projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
				projectile.width = 64;
				projectile.height = 64;
				projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
				projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
				for (int i = 0; i < 8; i++)
				{
					int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 179, 0f, 0f, 100, default(Color), 1f);
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num].scale = 0.5f;
						Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(6) * 0.1f;
					}
				}
				projectile.damage += projectile.damage / 5;
				projectile.Damage();
			}
			else
			{
				Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
				for(int i = 0; i < 4; i++)
				{
					int num = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 179, projectile.velocity.X, projectile.velocity.Y, 0, default(Color), 1f);
					Main.dust[num].velocity /= 4;
					Main.dust[num].scale = 1;
				}	
			}
		}
	}
}
