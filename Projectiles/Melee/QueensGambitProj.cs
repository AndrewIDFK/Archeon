using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Projectiles.Melee
{
	public class QueensGambitProj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.timeLeft = 660;
			projectile.penetrate = 1;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.aiStyle = 1;
			aiType = 48;
			projectile.melee = true;
		}

		public override void AI()
		{	
			if(Main.rand.Next(4) == 0)
			{
				int bee = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 150, 0f, 0f, 100, default(Color), 1f);
				Main.dust[bee].noGravity = true;
			}
		}
		
		public override void Kill(int timeLeft) 
		{	
			Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
			for (int i = 0; i < 5; i++)
			{
				int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 150, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num].noLight = true;
			}
			
			float rad = Main.rand.Next(50, 90);
			double num3 = (double)(0.69f / 6f);
			for (int i = 0; i < 3; i++)
			{
				Vector2 vector = new Vector2(projectile.Center.X, projectile.Center.Y);
				double num4 = num3 * (double)(i + i * i) / 2.0 + (double)(rad * (float)i);
				Projectile.NewProjectile(vector.X, vector.Y, (float)(-(float)Math.Sin(num4) * 1.2f), (float)(-(float)Math.Cos(num4) * 1.2f), ProjectileID.Bee, Main.player[projectile.owner].beeDamage(projectile.damage / 2), 0, projectile.owner, 0f, 0f);
			}
		}
	}
}