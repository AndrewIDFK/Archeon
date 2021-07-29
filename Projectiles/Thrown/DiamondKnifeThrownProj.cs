using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Archeon.Projectiles.Thrown
{
	public class DiamondKnifeThrownProj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.timeLeft = 400;
			projectile.penetrate = 3;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.aiStyle = 1;
			aiType = 48;
			projectile.thrown = true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.defense = target.defense / 20;
		}
		
		public override void AI()
		{
			int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 63, 0f, 0f, 100, default(Color), 1f);
			Main.dust[dust].noLight = true;
		}

		public override void Kill(int timeLeft) 
		{	
			Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
			for (int i = 0; i < 6; i++)
			{
				int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 63, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num].noLight = true;
				if (Main.rand.Next(2) == 0)
				{
					Main.dust[num].scale = 0.5f;
					Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(6) * 0.1f;
				}
			}
		}
	}
}