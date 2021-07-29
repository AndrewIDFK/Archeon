using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Projectiles.Melee.DeepSea
{
	public class OceanicGlaiveBeam : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 28;
			projectile.height = 28;
			projectile.aiStyle = 27;
			projectile.friendly = true;
			projectile.penetrate = 2;
			projectile.timeLeft = 240;
			projectile.hide = true;
			projectile.melee = true;
			Main.PlaySound(SoundID.Item15, projectile.position);
		}

		
		public override void AI()
		{
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -projectile.velocity.X / 10, -projectile.velocity.Y / 10, mod.ProjectileType("OceanicGlaiveTrail"), projectile.damage, 0, projectile.owner, 0f, 0f);
			
			Lighting.AddLight(projectile.Center, 0.12f, 0.124f, 0.455f);
			if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 172, projectile.velocity.X * -0.2f, projectile.velocity.Y * -0.2f, 0, Color.Brown, 1f);
			}
			
			projectile.hide = false;
		}
		
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item10, projectile.position);
			float numberProjectiles = 3;	
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 vector = new Vector2(projectile.Center.X, projectile.Center.Y);
				float xStuff = Main.rand.Next(-4, 4);
				Projectile.NewProjectile(vector.X, vector.Y, xStuff, -3.75f, mod.ProjectileType("OceanicGlaiveSpray"), projectile.damage / 2, 2f, Main.myPlayer, 0f, 0f);
			}
		}
	}
	
	public class OceanicGlaiveSpray : ModProjectile
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
			projectile.extraUpdates = 1;
			projectile.width = 14;
			projectile.height = 14;
			projectile.friendly = true;
			projectile.penetrate = 2;
			projectile.melee = true;
			projectile.hide = true;
		}

		public override void AI()
		{
			projectile.scale -= 0.014f;
			if (projectile.scale <= 0f)
			{
				projectile.Kill();
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
			
			if(Main.rand.Next(4) == 0)
			{
				int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, 172, projectile.velocity.X / 2, projectile.velocity.Y / 2, 100, default(Color), 1.4f);
				Main.dust[num].velocity /= 20;
				Main.dust[num].noGravity = true;
				Main.dust[num].color = Color.Aqua;
			}
			if(Main.rand.Next(9) == 0)
			{
				int num168 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 172, 0f, 0f, 100, default(Color), 1.2f);
				Main.dust[num168].noGravity = true;
				Main.dust[num168].velocity /= 30;
				Main.dust[num168].color = Color.Brown;
			}
		}
	}
}
