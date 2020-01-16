using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	public class EnchanterKnivesShot : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Enchanter's Throwing Knife");
		}

		public override void SetDefaults()
		{
			base.projectile.width = 20;
			base.projectile.height = 20;
			base.projectile.aiStyle = 2;
			base.projectile.friendly = true;
			base.projectile.hostile = false;
			base.projectile.ranged = true;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 49;
			base.projectile.light = 0.75f;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = true;
			base.projectile.extraUpdates = 0;
			this.aiType = 304;
		}

		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.3f, 0.505f, 0.61f);
			base.projectile.ai[0] += 1f;
			if (base.projectile.ai[0] > 60f)
			{
				base.projectile.alpha += 35;
				if (base.projectile.alpha > 255)
				{
					base.projectile.alpha = 255;
					return;
				}
			}
			else
			{
				base.projectile.alpha -= 31;
				if (base.projectile.alpha < 100)
				{
					base.projectile.alpha = 100;
				}
			}
		}

		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(SoundID.Item10, base.projectile.position);
		}
	}
}
