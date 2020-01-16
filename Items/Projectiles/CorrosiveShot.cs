using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x02000053 RID: 83
	public class CorrosiveShot : ModProjectile
	{
		// Token: 0x0600016A RID: 362 RVA: 0x0000A580 File Offset: 0x00008780
		public override void SetDefaults()
		{
			base.projectile.width = 4;
			base.projectile.height = 4;
			base.projectile.aiStyle = 1;
			base.projectile.friendly = true;
			base.projectile.hostile = false;
			base.projectile.ranged = true;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 720;
			base.projectile.alpha = 140;
			base.projectile.light = 0.65f;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = true;
			base.projectile.extraUpdates = 1;
			this.aiType = 14;
			projectile.scale = 1.2f;
			projectile.hide = true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(base.mod.BuffType("CorrosionDebuff"), 140, false);
		}

		// Token: 0x0600016B RID: 363 RVA: 0x0000A618 File Offset: 0x00008818
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.13f, 0.97f, 0.24f);
			
			for (int num163 = 0; num163 < 10; num163++)
			{
				float x2 = base.projectile.position.X - base.projectile.velocity.X / 10f * (float)num163;
				float y2 = base.projectile.position.Y - base.projectile.velocity.Y / 10f * (float)num163;
				int num164 = Dust.NewDust(new Vector2(x2, y2), 1, 1, mod.DustType("CorrosiveDust"));	
				Main.dust[num164].position.X = x2;
				Main.dust[num164].position.Y = y2;
				Main.dust[num164].velocity *= 0f;
				Main.dust[num164].noGravity = true;
			}
			
			/*int num2 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("CorrosiveDust"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num2].velocity /= 100f;
			Main.dust[num2].scale = 0.6f;*/
		}

		// Token: 0x0600016C RID: 364 RVA: 0x0000A854 File Offset: 0x00008A54
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(SoundID.Item10, base.projectile.position);
			for (int i = 0; i < 10; i++)
			{
				Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("CorrosiveDust"), base.projectile.oldVelocity.X * 0.5f, base.projectile.oldVelocity.Y * 0.5f, 0, default(Color), 1f);
			}
		}
		
	}
}
