using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x020003C4 RID: 964
	public class PlasmiteYoYoPlasma : ModProjectile
	{
		// Token: 0x0600155E RID: 5470 RVA: 0x000839D6 File Offset: 0x00081BD6
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Plasma Yo-Yo");
		}

		// Token: 0x0600155F RID: 5471 RVA: 0x00117728 File Offset: 0x00115928
		public override void SetDefaults()
		{
			base.projectile.width = 20;
			base.projectile.height = 20;
			base.projectile.aiStyle = 1;
			this.aiType = 14;
			base.projectile.friendly = true;
			base.projectile.melee = true;
			base.projectile.ignoreWater = true;
			base.projectile.penetrate = 1;
			base.projectile.alpha = 255;
			base.projectile.timeLeft = 69;
			
		}

		// Token: 0x06001560 RID: 5472 RVA: 0x001177C0 File Offset: 0x001159C0
		public override void AI()
		{
			
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.5f / 220f, (float)(240 - base.projectile.alpha) * 0.05f / 200f, (float)(240 - base.projectile.alpha) * 0.05f / 210f);
			Projectile projectile = base.projectile;
			projectile.velocity.X = projectile.velocity.X * 1.08f;
			Projectile projectile2 = base.projectile;
			projectile2.velocity.Y = projectile2.velocity.Y * 1.08f;
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + 1.55f;
			Projectile projectile3 = base.projectile;
			projectile3.velocity.Y = projectile3.velocity.Y + base.projectile.ai[0];
			if (Main.rand.Next(3) == 1)
			{
				Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("PlasmaDust1"), base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 0, default(Color), 1f);
			}
		}

		// Token: 0x06001561 RID: 5473 RVA: 0x00117948 File Offset: 0x00115B48
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.projectileTexture[base.projectile.type];
			spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition, null, base.projectile.GetAlpha(lightColor), base.projectile.rotation, texture2D.Size() / 2f, base.projectile.scale, SpriteEffects.None, 0f);
			return false;
		}

		// Token: 0x06001562 RID: 5474 RVA: 0x001179C8 File Offset: 0x00115BC8
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 10; i++)
			{
				Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("PlasmaDust1"), base.projectile.oldVelocity.X * 0.5f, base.projectile.oldVelocity.Y * 0.5f, 0, default(Color), 1f);
			}
		}

		// Token: 0x06001563 RID: 5475 RVA: 0x00117A58 File Offset: 0x00115C58
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(base.mod.BuffType("CosmicalPoisoning"), 120, false);
		}
	}
}
