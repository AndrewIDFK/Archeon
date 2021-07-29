using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Projectiles.Magic
{
	public class FlamebranchProj : ModProjectile
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
			projectile.timeLeft = 320;
			projectile.magic = true;
			projectile.tileCollide = false;
			Main.PlaySound(SoundID.Item15, projectile.position);
			projectile.hide = true;
		}
		int spazTimer;
		public override void AI()
		{
			Lighting.AddLight(projectile.Center, 0.515f * 2, 0.488f * 2, 0.184f * 2);
			for(int i = 0; i < 2; i++)
			{
				int num = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.velocity.X * -0.2f, projectile.velocity.Y * -0.2f, 0, Color.Yellow, 1f);
				Main.dust[num].velocity /= 2f;
				Main.dust[num].noGravity = true;
				Main.dust[num].scale = 1.1f;
				if(Main.dust[num].scale <= 0.925f)
				{
					Main.dust[num].scale = 0;
				}
				else Main.dust[num].scale -= 0.0525f;
			}
	
			spazTimer++;
			if(spazTimer == 40)
			{
				float rand = Main.rand.Next(-1, 1);
				projectile.velocity.X *= rand / 2;
				projectile.velocity.Y *= rand / 2;
				projectile.width += 1;
				projectile.width += 1;
				spazTimer = 0;
			}
			else
			{
				projectile.velocity *= 0.955f;
				projectile.scale *= 1.005f;
			}
			if(projectile.scale >= 1.95f)
			{
				projectile.Kill();
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(24, 340, false);
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item10, projectile.position);
			for(int i = 0; i < 8; i++)
			{
				int num = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.velocity.X, projectile.velocity.Y, 0, default(Color), 1f);
				Main.dust[num].velocity /= 2f;
				Main.dust[num].scale = 1.05f;
			}
		}
	}
}
