using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Projectiles.Ranged.Arrows
{
	public class VyssoniumArrowProj : ModProjectile
	{

		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 14;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.ranged = true;
			projectile.penetrate = 1;
			projectile.aiStyle = 1;
		}

		public override void AI()
		{
			if(Main.rand.Next(4) == 0)
			{ 
				int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, 114, projectile.velocity.X / 2, projectile.velocity.Y / 2, 100, default(Color), 1.4f);
				Main.dust[num].noGravity = true;
				Main.dust[num].velocity /= 2;
				Main.dust[num].color = Color.Crimson;
			}
		
			if(Main.rand.Next(5) == 0)
			{
				int num168 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 90, 0f, 0f, 100, default(Color), 1.2f);
				Main.dust[num168].noGravity = true;
				Main.dust[num168].velocity /= 1.5f;
				Main.dust[num168].color = Color.Red;
			}
			
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + MathHelper.ToRadians(270f);
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			target.AddBuff(mod.BuffType("VyssoniumDebuff"), 220, false);
		}

		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item10, projectile.position);
			for(int i = 0; i < 6; i++)
			{
				int num = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 114, projectile.velocity.X, projectile.velocity.Y, 0, default(Color), 1f);
				Main.dust[num].scale = 1.1f;
			}
		}
	}
}
