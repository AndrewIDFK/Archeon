using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Projectiles.Magic
{
	public class ClusterMassProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 4;
		}
		
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 100;
			projectile.magic = true;
			projectile.tileCollide = true;
			Main.PlaySound(SoundID.Item15, projectile.position);
		}
	
		public override void AI()
		{
			Lighting.AddLight(projectile.Center, 0.184f, 0.06f, 0.044f);
			
			projectile.velocity *= 0.985f;
			projectile.scale *= 1.002f;
			if(Main.rand.Next(4) == 0)
			{ 
				int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, 114, projectile.velocity.X / 2, projectile.velocity.Y / 2, 100, default(Color), 1.4f);
				Main.dust[num].noGravity = true;
				Main.dust[num].velocity /= 2;
				Main.dust[num].color = Color.Crimson;
			}
		
			if(Main.rand.Next(7) == 0)
			{
				int num168 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 90, 0f, 0f, 100, default(Color), 1.2f);
				Main.dust[num168].noGravity = true;
				Main.dust[num168].velocity /= 1.5f;
				Main.dust[num168].color = Color.Red;
			}
		}
		
		public override bool PreDraw(SpriteBatch sb, Color lightColor)
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 25)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
				if (projectile.frame > 3)
				{
					projectile.frame = 0;
				}
			}
			return true;
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item74, projectile.position);
			double num3 = (double)(0.69f / 6f);
			for (int i = 0; i < 11; i++)
			{
				Vector2 vector = new Vector2(projectile.Center.X, projectile.Center.Y);
				double num4 = num3 * (double)(i + i * i) / 2.0 + (double)(28f * (float)i);
				Projectile.NewProjectile(vector.X, vector.Y, (float)(-(float)Math.Sin(num4) * 8.0), (float)(-(float)Math.Cos(num4) * 6.0), mod.ProjectileType("ClusterMassSplitProj"), projectile.damage / 2, projectile.knockBack, projectile.owner, 0f, 0f);
			}
		}
	}
	
	public class ClusterMassSplitProj : ModProjectile
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
			projectile.penetrate = 1;
			projectile.minion = true;
			projectile.ignoreWater = true;
			projectile.timeLeft = 140;
		}

		public override void AI()
		{
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
			
			if(Main.rand.Next(2) == 0)
			{
				int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, 125, projectile.velocity.X / 2, projectile.velocity.Y / 2, 100, default(Color), 1.4f);
				Main.dust[num].noGravity = true;
				Main.dust[num].velocity /= 3;
				Main.dust[num].color = Color.Crimson;
			}
			
			if(Main.rand.Next(3) == 0)
			{
				int num168 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 90, 0f, 0f, 100, default(Color), 1.2f);
				Main.dust[num168].noGravity = true;
				Main.dust[num168].velocity /= 1.5f;
				Main.dust[num168].color = Color.Red;
			}
		}
		
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
		}
	}
}
