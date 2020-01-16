using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x0200006A RID: 106
	public class StroidWarHatchetShot : ModProjectile
	{
		// Token: 0x060001C9 RID: 457 RVA: 0x0000FB90 File Offset: 0x0000DD90
		public override void SetDefaults()
		{
			base.projectile.width = 32;
			base.projectile.height = 32;
			base.projectile.CloneDefaults(182);
			this.aiType = 182;
			base.projectile.friendly = true;
			base.projectile.ranged = true;
			base.projectile.magic = false;
			base.projectile.penetrate = -1;
			base.projectile.extraUpdates = 1;
		}

		// Token: 0x060001CA RID: 458 RVA: 0x0000FC10 File Offset: 0x0000DE10
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.26f, 0.284f, 0.455f);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("StroidDust1"), base.projectile.velocity.X * -0.5f, base.projectile.velocity.Y * -0.5f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 160f;
			Main.dust[num].scale = 1.12f;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 14, 1f, 0f);
			base.projectile.position.X = base.projectile.position.X + (float)(base.projectile.width / 2);
			base.projectile.position.Y = base.projectile.position.Y + (float)(base.projectile.height / 2);
			base.projectile.width = 34;
			base.projectile.height = 34;
			base.projectile.position.X = base.projectile.position.X - (float)(base.projectile.width / 2);
			base.projectile.position.Y = base.projectile.position.Y - (float)(base.projectile.height / 2);
			for (int i = 0; i < 35; i++)
			{
				int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, base.mod.DustType("StroidDust1"), 0f, 0f, 100, default(Color), 1f);
				Main.dust[num].velocity *= 3f;
				if (Main.rand.Next(2) == 0)
				{
					Main.dust[num].scale = 0.5f;
					Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(6) * 0.1f;
				}
			}
			for (int j = 0; j < 42; j++)
			{
				int num2 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, base.mod.DustType("StroidDust1"), 0f, 0f, 100, default(Color), 2f);
				Main.dust[num2].noGravity = true;
				Main.dust[num2].velocity *= 5f;
				num2 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, base.mod.DustType("StroidDeathDust"), 0f, 0f, 100, default(Color), 1f);
				Main.dust[num2].velocity *= 2f;
			}
			
			base.projectile.Damage();
		}
	
		
		
	}
}
