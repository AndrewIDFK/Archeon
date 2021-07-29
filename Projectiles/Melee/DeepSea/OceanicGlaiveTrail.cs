using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Projectiles.Melee.DeepSea
{
	public class OceanicGlaiveTrail : ModProjectile
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
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.ignoreWater = true;
			projectile.timeLeft = 30;
		}

		public override void AI()
		{
			if(Main.rand.Next(2) == 0)
			{
				int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, 172, projectile.velocity.X / 2, projectile.velocity.Y / 2, 100, default(Color), 1.4f);
				Main.dust[num].scale = 1f;
				Main.dust[num].velocity /= 20;
				Main.dust[num].noGravity = true;
				Main.dust[num].color = Color.Aqua;
			}
			if(Main.rand.Next(15) == 0)
			{
				int num168 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 172, 0f, 0f, 100, default(Color), 1.2f);
				Main.dust[num168].noGravity = true;
				Main.dust[num168].velocity /= 30;
				Main.dust[num168].color = Color.Brown;
			}
		}
	}
}
