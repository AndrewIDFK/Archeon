using System;
using Archeon.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x0200006B RID: 107
	public class SuperPoweredArrowShot : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Thanite Arrow");
		}
		
		public override void SetDefaults()
		{
			base.projectile.width = 8;
			base.projectile.height = 16;
			base.projectile.friendly = true;
			base.projectile.hostile = false;
			base.projectile.tileCollide = true;
			base.projectile.ignoreWater = true;
			base.projectile.ranged = true;
			base.projectile.penetrate = 1;
			base.projectile.aiStyle = 1;
			projectile.scale = 1.15f;
			base.projectile.extraUpdates = 1;
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0000FD80 File Offset: 0x0000DF80
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 1.13f, 0.3f, 1.94f);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 179, base.projectile.velocity.X * -0.5f, base.projectile.velocity.Y * -0.5f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 20f;
			Main.dust[num].scale = 1.05f;
			Main.dust[num].noGravity = true;
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + MathHelper.ToRadians(270f);
		}
	
		
		

		// Token: 0x060001CF RID: 463 RVA: 0x0000FEA4 File Offset: 0x0000E0A4
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(SoundID.Item10, base.projectile.position);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 179, base.projectile.velocity.X * -30.2f, base.projectile.velocity.Y * -14.7f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 80f;
			Main.dust[num].scale = 1.1f;
			int num2 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 179, base.projectile.velocity.X * -10.4f, base.projectile.velocity.Y * 2.9f, 0, default(Color), 1f);
			Main.dust[num2].velocity /= 80f;
			Main.dust[num2].scale = 1.1f;
			int num3 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 179, base.projectile.velocity.X * 30.9f, base.projectile.velocity.Y * -21.9f, 0, default(Color), 1f);
			Main.dust[num3].velocity /= 80f;
			Main.dust[num3].scale = 1.1f;
			int num4 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 179, base.projectile.velocity.X * -22.4f, base.projectile.velocity.Y * 11.6f, 0, default(Color), 1f);
			Main.dust[num4].velocity /= 80f;
			Main.dust[num4].scale = 1.1f;
			int num5 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 179, base.projectile.velocity.X * -20.2f, base.projectile.velocity.Y * -10.7f, 0, default(Color), 1f);
			Main.dust[num5].velocity /= 80f;
			Main.dust[num5].scale = 1.1f;
			
			Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, base.mod.ProjectileType("ThaniteExplosion"), base.projectile.damage, base.projectile.knockBack, Main.myPlayer, 0f, 0f);	
		}
	}
}
