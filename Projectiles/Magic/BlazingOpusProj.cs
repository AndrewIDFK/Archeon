using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Projectiles.Magic
{
	public class BlazingOpusProj : ModProjectile
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
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 27;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.magic = true;
			Main.PlaySound(SoundID.Item15, projectile.position);
			projectile.hide = true;
		}

		public override void AI()
		{
			if(Main.rand.Next(2) == 1)
			{
				int num = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.velocity.X * -0.2f, projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
				Main.dust[num].velocity /= 5f;
				Main.dust[num].noGravity = true;
				Main.dust[num].scale = 1.35f;
				if(Main.dust[num].scale <= 1.1f)
				{
					Main.dust[num].scale = 0;
				}
				else Main.dust[num].scale -= 0.1f;
			}
			if(Main.rand.Next(1) == 0)
			{
				int num = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.velocity.X * -0.325f, projectile.velocity.Y * -0.325f, 0, default(Color), 1f);
				Main.dust[num].noGravity = true;
				Main.dust[num].scale = 1.5f;
				if(Main.dust[num].scale <= 1.1f)
				{
					Main.dust[num].scale = 0;
				}
				else Main.dust[num].scale -= 0.09f;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(24, 220, false);
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item10, projectile.position);
			for(int i = 0; i < 8; i++)
			{
				int num = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 269, projectile.velocity.X, projectile.velocity.Y, 0, default(Color), 1f);
				Main.dust[num].velocity /= 2f;
				Main.dust[num].scale = 1.05f;
			}
		}
	}
}
