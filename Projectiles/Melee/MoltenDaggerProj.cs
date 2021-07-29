using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Projectiles.Melee
{
	public class MoltenDaggerProj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.timeLeft = 440;
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
				int fire = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1f);
				Main.dust[fire].noGravity = true;
				Main.dust[fire].noGravity = true;
			}
		}
		
		public override void Kill(int timeLeft) 
		{	
			Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
			for (int i = 0; i < 5; i++)
			{
				int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num].noLight = true;
				Main.dust[num].noGravity = true;
			}
			
			float rad = Main.rand.Next(80, 120);
			double num3 = (double)(0.69f / 6f);
			for (int i = 0; i < 7; i++)
			{
				Vector2 vector = new Vector2(projectile.Center.X, projectile.Center.Y);
				double num4 = num3 * (double)(i + i * i) / 2.0 + (double)(rad * (float)i);
				Projectile.NewProjectile(vector.X, vector.Y, (float)(-(float)Math.Sin(num4) * 3.8f), (float)(-(float)Math.Cos(num4) * 3.2f), mod.ProjectileType("MoltenDaggerGroundProj"), projectile.damage / 2, 0, projectile.owner, 0f, 0f);
			}
		}
	}
	
	public class MoltenDaggerGroundProj : ModProjectile
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
			projectile.height = 8;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 200;
			projectile.melee = true;
			projectile.hide = true;
		}
		
		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			fallThrough = false;
			return true;
		}

		public override void AI()
		{
			if (projectile.wet || projectile.lavaWet)
			{
				projectile.velocity.Y = 0f;
			}	
			projectile.ai[0] += 1f;
			if (projectile.ai[0] >= 9f)
			{
				projectile.ai[0] = 9f;
				projectile.velocity.Y = projectile.velocity.Y + 0.2f;
			}
			if (projectile.velocity.Y > 10f)
			{
				projectile.velocity.Y = 10f;
			}
			projectile.velocity.X = projectile.velocity.X * 0.95f;
			
			if(Main.rand.Next(1) == 0)
			{
				int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X / 2, projectile.velocity.Y / 2, 100, default(Color), 1.4f);
				Main.dust[num].velocity /= 20;
				Main.dust[num].noGravity = true;
			}
			if(Main.rand.Next(3) == 0)
			{
				int num168 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1.2f);
				Main.dust[num168].noGravity = true;
				Main.dust[num168].velocity /= 30;
				Main.dust[num168].color = Color.Yellow;
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (projectile.penetrate == 0)
			{
				projectile.Kill();
			}
			return false;
		}
	}
}