using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Projectiles.Magic
{
	public class SindomsCodexProj : ModProjectile
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
			Main.PlaySound(SoundID.Item15, projectile.position);
			projectile.hide = true;
		}
		
		public static Vector2 helixVector(float radius, float theta) // Hard to explain. We make a Vector2 called helixVector, which we use to calculate helixVelocity in the correct way.
        {
            return new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta)) * radius; // Vector2(Cos(theta), Sin(theta) * radius) only Sin(theta) is multiplied by radius here.
        }
		
		private float arcLength = 30; 
        private float arcSize = 15;
		
		bool onceDone = true;
		private float counter = 0; 
        private float spawnDirection = 0;
        private float previousI = 0; 
       // private Projectile secondProjectile = null; 
		
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
						//secondProjectile = Main.projectile[Projectile.NewProjectile(projectile.Center, projectile.velocity, projectile.type, projectile.damage, projectile.knockBack, projectile.owner, 1, projectile.whoAmI)]; // Here we spawn an identical projectile to this one called secondProjectile.
					}
					/*else
					{						
						secondProjectile = Main.projectile[(int)projectile.ai[1]];  
					}*/
				}
				onceDone = false;
				
			}
			counter += 2 * (float)Math.PI / arcLength;
            float i = arcSize * (float)Math.Sin(counter) * (projectile.ai[0] == 0 ? 1 : -1); 
            Vector2 helixVelocity = helixVector(i - previousI, spawnDirection + (float)Math.PI / 2);
            projectile.Center += helixVelocity;
            previousI = i; 
            projectile.rotation = (projectile.velocity + helixVelocity).ToRotation() + (float)Math.PI / 2;
			
			for (int num163 = 0; num163 < 10; num163++)
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

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item10, projectile.position);
			for(int i = 0; i < 8; i++)
			{
				int num = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 159, projectile.velocity.X, projectile.velocity.Y, 0, default(Color), 1f);
				Main.dust[num].velocity /= 2.5f;
				Main.dust[num].scale = 1.05f;
				Main.dust[num].noLight = true;
			}
		}
	}
}
