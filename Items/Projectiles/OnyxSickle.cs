using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace Archeon.Items.Projectiles
{
	// Token: 0x0200005C RID: 92
	public class OnyxSickle : ModProjectile
	{
		// Token: 0x06000192 RID: 402 RVA: 0x0000D044 File Offset: 0x0000B244
		public override void SetDefaults()
		{
			base.projectile.extraUpdates = 0;
			base.projectile.width = 18;
			base.projectile.height = 18;
			base.projectile.aiStyle = 18;
			base.projectile.friendly = true;
			base.projectile.penetrate = 4;
			base.projectile.melee = true;
			base.projectile.soundDelay = 3;
			
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[base.projectile.owner] = 2;
		}
		
		// Token: 0x06000193 RID: 403 RVA: 0x0000D0CC File Offset: 0x0000B2CC
		public override void AI()
		{
			//Main.PlaySound(SoundID.Item25, base.projectile.position);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 21, base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.3f, 0, default(Color), 1f);
			Main.dust[num].scale = 0.25f;
		}

		// Token: 0x06000194 RID: 404 RVA: 0x0000D160 File Offset: 0x0000B360
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(SoundID.Item10, base.projectile.position);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 21, base.projectile.velocity.X * 3.9f, base.projectile.velocity.Y * 5.9f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 80f;
			Main.dust[num].scale = 1.1f;
			int num2 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 21, base.projectile.velocity.X * -5.4f, base.projectile.velocity.Y * -5.6f, 0, default(Color), 1f);
			Main.dust[num2].velocity /= 80f;
			Main.dust[num2].scale = 1.1f;
			int num3 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 21, base.projectile.velocity.X * -6.2f, base.projectile.velocity.Y * -7.7f, 0, default(Color), 1f);
			Main.dust[num3].velocity /= 80f;
			Main.dust[num3].scale = 1.1f;
			int num4 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 21, base.projectile.velocity.X * -10.4f, base.projectile.velocity.Y * 4.9f, 0, default(Color), 1f);
			Main.dust[num4].velocity /= 80f;
			Main.dust[num4].scale = 1.1f;
			int num5 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 21, base.projectile.velocity.X * 7.9f, base.projectile.velocity.Y * -3.9f, 0, default(Color), 1f);
			Main.dust[num5].velocity /= 80f;
			Main.dust[num5].scale = 1.1f;
			int num6 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 21, base.projectile.velocity.X * 3.9f, base.projectile.velocity.Y * 5.9f, 0, default(Color), 1f);
			Main.dust[num6].velocity /= 80f;
			Main.dust[num6].scale = 1.1f;
			int num7 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 21, base.projectile.velocity.X * -5.4f, base.projectile.velocity.Y * -5.6f, 0, default(Color), 1f);
			Main.dust[num7].velocity /= 80f;
			Main.dust[num7].scale = 1.1f;
			int num8 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 21, base.projectile.velocity.X * -6.2f, base.projectile.velocity.Y * -7.7f, 0, default(Color), 1f);
			Main.dust[num8].velocity /= 80f;
			Main.dust[num8].scale = 1.1f;
			int num9 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 21, base.projectile.velocity.X * -10.4f, base.projectile.velocity.Y * 4.9f, 0, default(Color), 1f);
			Main.dust[num9].velocity /= 80f;
			Main.dust[num9].scale = 1.1f;
			int num10 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 21, base.projectile.velocity.X * 7.9f, base.projectile.velocity.Y * -3.9f, 0, default(Color), 1f);
			Main.dust[num10].velocity /= 80f;
			Main.dust[num10].scale = 1.1f;
			int num11 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 21, base.projectile.velocity.X * 3.9f, base.projectile.velocity.Y * 5.9f, 0, default(Color), 1f);
			Main.dust[num11].velocity /= 80f;
			Main.dust[num11].scale = 1.1f;
			int num12 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 21, base.projectile.velocity.X * -5.4f, base.projectile.velocity.Y * -5.6f, 0, default(Color), 1f);
			Main.dust[num12].velocity /= 80f;
			Main.dust[num12].scale = 1.1f;
			int num13 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 21, base.projectile.velocity.X * -6.2f, base.projectile.velocity.Y * -7.7f, 0, default(Color), 1f);
			Main.dust[num13].velocity /= 80f;
			Main.dust[num13].scale = 1.1f;
			int num14 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 21, base.projectile.velocity.X * -10.4f, base.projectile.velocity.Y * 4.9f, 0, default(Color), 1f);
			Main.dust[num14].velocity /= 80f;
			Main.dust[num14].scale = 1.1f;
			int num15 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 21, base.projectile.velocity.X * 7.9f, base.projectile.velocity.Y * -3.9f, 0, default(Color), 1f);
			Main.dust[num15].velocity /= 80f;
			Main.dust[num15].scale = 1.1f;
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			ArcheonGlobalProjectile.DrawCenteredAndAfterimage(base.projectile, lightColor, ProjectileID.Sets.TrailingMode[base.projectile.type], 1);
			return false;
		}
	}
}
