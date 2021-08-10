using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Projectiles.Misc
{
	public class BloodiedProj : ModProjectile
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
			projectile.timeLeft = 165;
			projectile.hide = true;
		}

		public override void AI()
		{
			projectile.ai[0] += 1f;
			if (projectile.ai[0] >= 5f)
			{
				projectile.ai[0] = 5f;
				projectile.velocity.Y = projectile.velocity.Y + 0.25f;
			}
			
			for (int i = 0; i < 3; i++)
			{
				float x = projectile.position.X - projectile.velocity.X / 3f * (float)i;
				float y = projectile.position.Y - projectile.velocity.Y / 3f * (float)i;
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
			}
		}
	}
	
	public class BloodiedHealProj : ModProjectile
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
			projectile.timeLeft = 250;
			projectile.hide = true;
		}

		public override void AI()
		{		
			
			float x2 = projectile.position.X - projectile.velocity.X;
			float y2 = projectile.position.Y - projectile.velocity.Y;
			int num164 = Dust.NewDust(new Vector2(x2, y2), 1, 1, 235);	
			Main.dust[num164].position.X = x2;
			Main.dust[num164].position.Y = y2;
			Main.dust[num164].velocity *= 0f;
			Main.dust[num164].scale = 0.95f;
			Main.dust[num164].noGravity = true;
			Main.dust[num164].noLight = true;
			Main.dust[num164].color = Color.Crimson;
			
			projectile.ai[1] += 1f;
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			float num = 85f;
			float scaleFactor = 15f;
			float num2 = 55f;
			int num3 = (int)projectile.ai[0];
			if (num3 >= 0 && Main.player[num3].active && !Main.player[num3].dead)
			{
				if (projectile.Distance(Main.player[num3].Center) > num2)
				{
					Vector2 vector = projectile.DirectionTo(Main.player[num3].Center);
					if (vector.HasNaNs())
					{
						vector = Vector2.UnitY;
					}
					projectile.velocity = (projectile.velocity * (num - 1f) + vector * scaleFactor) / num;
					return;
				}
			}
			Player player = Main.player[projectile.owner];
			if(projectile.Colliding(projectile.Hitbox, player.Hitbox))
			{
				if (projectile.owner == Main.myPlayer)
				{
					int num5 = Main.rand.Next(2, 4); 
					player.HealEffect(num5, false);
					player.statLife += num5;
					if (player.statLife > player.statLifeMax2)
					{
						player.statLife = player.statLifeMax2;
					}
				}
				projectile.Kill();
			}
		}
		
		public override void Kill(int timeLeft) 
		{	
			for (int i = 0; i < 3; i++)
			{
				int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 235, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num].noLight = true;
				Main.dust[num].color = Color.Red;
				Main.dust[num].noGravity = true;
				Main.dust[num].noLight = true;
				Main.dust[num].scale = 0.9f;
			}
		}
	}
}