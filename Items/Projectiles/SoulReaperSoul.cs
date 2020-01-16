using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	
	public class SoulReaperSoul : ModProjectile
	{
		
		public override void SetDefaults()
		{
			base.projectile.scale = 1.15f;
			base.projectile.extraUpdates = 0;
			base.projectile.width = 22;
			base.projectile.height = 22;
			base.projectile.aiStyle = 1;
			this.aiType = 14;
			base.projectile.friendly = true;
			base.projectile.penetrate = -1;
			base.projectile.melee = true;
			Main.PlaySound(SoundID.Item15, base.projectile.position);
			base.projectile.hide = false;
			base.projectile.timeLeft = 15;
		}


		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.49f, 0.87f, 1.22f);
			int num21 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("SoulReaperDust"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num21].velocity /= 160f;
			Main.dust[num21].scale = 1f;
			int num22 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("SoulReaperDust"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num22].velocity /= 160f;
			Main.dust[num22].scale = 1.15f;		
		}
		
		

		
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(SoundID.Item8, base.projectile.position);
			for (int i = 0; i < 10; i++)
			{
				Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("SoulReaperDust"), base.projectile.oldVelocity.X * 2.5f, base.projectile.oldVelocity.Y * 2.5f, 0, default(Color), 1f);
			}
			
			Projectile.NewProjectile(base.projectile.Center.X - 6.5f, base.projectile.Center.Y - 6.5f, projectile.velocity.X, projectile.velocity.Y + 6.2f, base.mod.ProjectileType("SoulReaperSoulHome"), base.projectile.damage, base.projectile.knockBack, Main.myPlayer, 0f, 0f);

		}
	}
}
