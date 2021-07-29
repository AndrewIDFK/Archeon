using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Projectiles.Melee
{
	public class DarkSlicerProj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = 3;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = -1;
			projectile.extraUpdates = 1;
		}

		public override void AI()
		{
			Lighting.AddLight(projectile.Center, 0.125f / 2, 0.035f / 2, 0.575f / 2);
			if(Main.rand.Next(2) == 0)
			{
				int num = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 179, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f, 0, default(Color), 1f);
				Main.dust[num].velocity /= 60f;
				Main.dust[num].scale = 0.65f;
				Main.dust[num].noGravity = true;
			}
		}
	}
}
