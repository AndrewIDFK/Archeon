using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Projectiles.Melee.DeepSea
{
	public class DSGSpray : ModProjectile
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
			projectile.extraUpdates = 0;
			projectile.width = 14;
			projectile.height = 14;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.melee = true;
			Main.PlaySound(SoundID.Item15, projectile.position);
			projectile.hide = true;
		}

		public override void AI()
		{
			projectile.scale -= 0.016f;
			if (projectile.scale <= 0f)
			{
				projectile.Kill();
			}
			
			projectile.velocity.Y = projectile.velocity.Y + 0.095f;
			int num4;
			for (int num163 = 0; num163 < 1; num163 = num4 + 1)
			{
				for (int num164 = 0; num164 < 2; num164 = num4 + 1)
				{
					float num165 = projectile.velocity.X / 3f * (float)num164;
					float num166 = projectile.velocity.Y / 3f * (float)num164;
					int num167 = 6;
					int num168 = Dust.NewDust(new Vector2(projectile.position.X + (float)num167, projectile.position.Y + (float)num167), projectile.width - num167 * 2, projectile.height - num167 * 2, 172, 0f, 0f, 100, default(Color), 1.2f);
					Main.dust[num168].noGravity = true;
					Main.dust[num168].color = Color.Brown;
					Dust dust3 = Main.dust[num168];
					dust3.velocity *= 0.3f;
					dust3 = Main.dust[num168];
					dust3.velocity += projectile.velocity * 0.5f;
					num4 = num164;
				}
				if (Main.rand.Next(7) == 0)
				{
					int num169 = 6;
					int num170 = Dust.NewDust(new Vector2(projectile.position.X + (float)num169, projectile.position.Y + (float)num169), projectile.width - num169 * 2, projectile.height - num169 * 2, 172, 0f, 0f, 100, default(Color), 0.75f);
					Dust dust3 = Main.dust[num170];
					dust3.velocity *= 0.5f;
					dust3 = Main.dust[num170];
					dust3.velocity += projectile.velocity * 0.5f;
					Main.dust[num170].color = Color.Aqua;
				}
				num4 = num163;
			}
			if (Main.rand.Next(3) == 0)
			{
				int drippingDust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 33, projectile.velocity.X * -0.2f, projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
				Main.dust[drippingDust].scale = 1.1f;
			}
		}
		
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item10, projectile.position);
			for(int i = 0; i < 2; i++)
			{
				int num = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 172, projectile.velocity.X, projectile.velocity.Y, 0, default(Color), 1f);
				Main.dust[num].scale = 1.05f;
				Main.dust[num].noGravity = true;
			}
		}
	}
}
