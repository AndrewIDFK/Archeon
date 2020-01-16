using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace Archeon.Items.Projectiles
{
	// Token: 0x0200006E RID: 110
	public class ThaniteExplosion : ModProjectile
	{
		// Token: 0x060001D7 RID: 471 RVA: 0x00010414 File Offset: 0x0000E614
		public override void SetDefaults()
		{
			base.projectile.scale = 1.4f;
			base.projectile.extraUpdates = 0;
			base.projectile.width = 18;
			base.projectile.height = 18;
			base.projectile.aiStyle = 27;
			Main.projFrames[base.projectile.type] = 5;
			base.projectile.hide = true;
			base.projectile.timeLeft = 1;
			base.projectile.melee = true;
			base.projectile.friendly = true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[base.projectile.owner] = 1;
			
		}
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 14, 1f, 0f);
			base.projectile.position.X = base.projectile.position.X + (float)(base.projectile.width / 2);
			base.projectile.position.Y = base.projectile.position.Y + (float)(base.projectile.height / 2);
			base.projectile.width = 42;
			base.projectile.height = 42;
			base.projectile.position.X = base.projectile.position.X - (float)(base.projectile.width / 2);
			base.projectile.position.Y = base.projectile.position.Y - (float)(base.projectile.height / 2);
			for (int i = 0; i < 25; i++)
			{
				int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 179, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num].velocity *= 3f;
				if (Main.rand.Next(2) == 0)
				{
					Main.dust[num].scale = 0.43f;
					Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(6) * 0.1f;
				}
			}
			for (int j = 0; j < 22; j++)
			{
				int num2 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 179, 0f, 0f, 100, default(Color), 2f);
				Main.dust[num2].noGravity = true;
				Main.dust[num2].velocity *= 5f;
				num2 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 179, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num2].velocity *= 2f;
			}
			
			base.projectile.Damage();
		}
	}
}
