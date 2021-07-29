using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Projectiles.Magic
{
	public class BlackLightProj : ModProjectile
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
			projectile.width = 34;
			projectile.height = 34;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 320;
			projectile.magic = true;
			projectile.tileCollide = false;
			Main.PlaySound(SoundID.Item15, projectile.position);
			projectile.hide = true;
		}

		public override void AI()
		{
			Lighting.AddLight(projectile.Center, 0.3f, 0f, 0.52f);
			Player player = Main.player[projectile.owner];
			Vector2 circularMotion = new Vector2(projectile.width, projectile.height) * projectile.scale * 0.969f;
			circularMotion /= 1.7f;
			Vector2 circMot2 = circularMotion;
			circMot2 /= 1.8f;
			Vector2 realCircularMotion = Vector2.UnitY.RotatedByRandom(3.2831854820251465) * circularMotion;
			Vector2 rCircMot2 = Vector2.UnitY.RotatedByRandom(3.2831854820251465) * circMot2;
			for (int i = 0; i < 3; i++) 
			{
				int numDust = Dust.NewDust(projectile.Center, 0, 0, 109);
				Main.dust[numDust].position = realCircularMotion + projectile.Center;
				Main.dust[numDust].scale *= 1.15f;
				Main.dust[numDust].noGravity = true;
			}
			for (int i = 0; i < 3; i++) 
			{
				int numDust = Dust.NewDust(projectile.Center, 0, 0, 186);
				Main.dust[numDust].position = rCircMot2 + projectile.Center;
				Main.dust[numDust].scale *= 1.1f;
				Main.dust[numDust].color = Color.Purple;
				Main.dust[numDust].noGravity = true;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 3;
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item10, projectile.position);
			for(int i = 0; i < 8; i++)
			{
				int num = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 109, projectile.velocity.X, projectile.velocity.Y, 0, default(Color), 1f);
				Main.dust[num].velocity /= 15f;
				Main.dust[num].scale = 1.1f;
			}
		}
	}
}
