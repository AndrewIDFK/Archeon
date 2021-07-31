using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Projectiles.Magic
{
	public class CursedBookProj : ModProjectile
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
			projectile.width = 14;
			projectile.height = 14;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.extraUpdates = 1;
			projectile.timeLeft = 115;
			projectile.hide = true;
		}
		
		public static Vector2 helixVector(float radius, float theta) // Hard to explain. We make a Vector2 called helixVector, which we use to calculate helixVelocity in the correct way.
        {
            return new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta)) * radius; // Vector2(Cos(theta), Sin(theta) * radius) only Sin(theta) is multiplied by radius here.
        }
		
		private float arcLength = 50; 
        private float arcSize = 10;
		
		bool onceDone = true;
		private float counter = 0; 
        private float spawnDirection = 0;
        private float previousI = 0; 
		public override void AI()
		{
			if(onceDone) 
			{
				if(Main.netMode != 2 && projectile.owner == Main.myPlayer)
				{
					if(projectile.ai[0] == 0)
					{
						projectile.velocity *= 0.95f;
					}
				}
				if(Main.rand.Next(1) == 0)
				{
					spawnDirection = -projectile.velocity.ToRotation();
					arcLength = -50;
					arcSize = -10;
				}
				else spawnDirection = projectile.velocity.ToRotation();
				
				onceDone = false;
			}
		
			counter += 5 * (float)Math.PI / arcLength;
            float i = arcSize * (float)Math.Sin(counter) * (projectile.ai[0] == 0 ? 1 : -1); 
            Vector2 helixVelocity = helixVector(i - previousI, spawnDirection + (float)Math.PI / 3);
            projectile.Center += helixVelocity;
            previousI = i; 
            projectile.rotation = (projectile.velocity + helixVelocity).ToRotation() + (float)Math.PI / 3;
			
			projectile.localAI[0] += 1f;
			if (projectile.localAI[0] > 3f)
			{
				for (int af = 0; af < 2; af++)
				{
					Vector2 vector = projectile.position;
					vector -= projectile.velocity * ((float)i * 0.25f);
					projectile.alpha = 255;
					int num = Dust.NewDust(vector, 1, 1, 75, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num].noGravity = true;
					Main.dust[num].position = vector;
					Main.dust[num].scale = 1.1f;
					Main.dust[num].velocity *= 0.4f;
				}
				return;
			}
		}
	}
}
