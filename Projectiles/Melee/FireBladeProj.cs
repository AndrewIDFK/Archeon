using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Projectiles.Melee
{
	public class FireBladeProj : ModProjectile
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
			projectile.scale = 0.95f;
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 27;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.melee = true;
			Main.PlaySound(SoundID.Item15, projectile.position);
			projectile.hide = true;
		}

		public override void AI()
		{
			Lighting.AddLight(projectile.Center, 0.565f, 0.1f, 0.12f);
			for(int i = 0; i < 3; i++)
			{
				int num = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.velocity.X * -0.2f, projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
				Main.dust[num].velocity /= 20f;
				Main.dust[num].noGravity = true;
				Main.dust[num].scale = 1.1f;
				if(Main.dust[num].scale <= 0.9f)
				{
					Main.dust[num].scale = 0;
				}
				else Main.dust[num].scale -= 0.05f;
			}

		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item10, projectile.position);
			for(int i = 0; i < 6; i++)
			{
				int num = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 269, projectile.velocity.X, projectile.velocity.Y, 0, default(Color), 1f);
				Main.dust[num].velocity /= 10f;
				Main.dust[num].scale = 1.05f;
			}
		}
	}
}
