using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x020004ED RID: 1261
	public class PlasmaRazorBladeShot : ModProjectile
	{
		// Token: 0x06001C1D RID: 7197 RVA: 0x0016DFD8 File Offset: 0x0016C1D8
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Plasma Torrent");
			Main.projFrames[base.projectile.type] = 3;
			ProjectileID.Sets.TrailCacheLength[base.projectile.type] = 10;
			ProjectileID.Sets.TrailingMode[base.projectile.type] = 0;
		}

		// Token: 0x06001C1E RID: 7198 RVA: 0x0016E02C File Offset: 0x0016C22C
		public override void SetDefaults()
		{
			base.projectile.width = 60;
			base.projectile.height = 60;
			base.projectile.alpha = 255;
			base.projectile.friendly = true;
			base.projectile.aiStyle = 71;
			base.projectile.magic = true;
			base.projectile.penetrate = 35;
			base.projectile.timeLeft = 440;
			base.projectile.tileCollide = true;
			base.projectile.extraUpdates = 2;
			base.projectile.ignoreWater = true;
			this.aiType = 409;
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			base.projectile.penetrate--;
			if (base.projectile.penetrate <= 0)
			{
				base.projectile.Kill();
			}
			else
			{
				if (base.projectile.velocity.X != oldVelocity.X)
				{
					base.projectile.velocity.X = -oldVelocity.X;
				}
				if (base.projectile.velocity.Y != oldVelocity.Y)
				{
					base.projectile.velocity.Y = -oldVelocity.Y;
				}
				Main.PlaySound(SoundID.Item10, base.projectile.position);
			}
			return false;
		}
		
		public override void AI()
		{		
			Lighting.AddLight(base.projectile.Center, 1.12f, 0.25f, 0.946f);
			
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 249, base.projectile.velocity.X * 2f, base.projectile.velocity.Y * 2f, 100, default(Color), 1.4f);
			Main.dust[num].velocity /= 60f;
			Main.dust[num].scale = 1.3f;
			Main.dust[num].noGravity = true;
			
			int num2 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 249, base.projectile.velocity.X * 2f, base.projectile.velocity.Y * 2f, 100, default(Color), 1.4f);
			Main.dust[num2].velocity /= 60f;
			Main.dust[num2].scale = 1.3f;
			Main.dust[num2].noGravity = true;
			
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + 1.1f;
			base.projectile.localAI[0] += 1f;
			
			
		}
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 10, 1f, 0f);
			for (int i = 0; i < 5; i++)
			{
				int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 249, 0f, 0f, 0, default(Color), 1f);
				Main.dust[num].velocity *= 0f;
				Main.dust[num].noGravity = true;
			}
		}

		// Token: 0x06001C20 RID: 7200 RVA: 0x0016E1A0 File Offset: 0x0016C3A0
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(224, 52, 175, 0));
		}

		// Token: 0x06001C21 RID: 7201 RVA: 0x00093A53 File Offset: 0x00091C53
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[base.projectile.owner] = 2;
		
		}	
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			ArcheonGlobalProjectile.DrawCenteredAndAfterimage(base.projectile, lightColor, ProjectileID.Sets.TrailingMode[base.projectile.type], 1);
			return false;
		}
	}
}
