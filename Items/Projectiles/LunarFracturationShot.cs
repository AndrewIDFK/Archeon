using System;
using Archeon.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x02000057 RID: 87
	public class LunarFracturationShot : ModProjectile
	{
		// Token: 0x0600017A RID: 378 RVA: 0x0000B8E9 File Offset: 0x00009AE9
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Lunar Fracturation Beam");
		}

		// Token: 0x0600017B RID: 379 RVA: 0x0000B8FB File Offset: 0x00009AFB
		public override void SetDefaults()
		{
			this.aiType = 660;
			base.projectile.CloneDefaults(660);
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0000B918 File Offset: 0x00009B18
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.3f, 0.485f, 0.61f);
		}

		// Token: 0x0600017D RID: 381 RVA: 0x0000B93C File Offset: 0x00009B3C
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 vector = new Vector2((float)Main.projectileTexture[base.projectile.type].Width * 0.5f, (float)base.projectile.height * 0.5f);
			for (int i = 0; i < base.projectile.oldPos.Length; i++)
			{
				Vector2 position = base.projectile.oldPos[i] - Main.screenPosition + vector + new Vector2(0f, base.projectile.gfxOffY);
				Color color = base.projectile.GetAlpha(lightColor) * ((float)(base.projectile.oldPos.Length - i) / (float)base.projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[base.projectile.type], position, null, color, base.projectile.rotation, vector, base.projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}

		// Token: 0x0600017E RID: 382 RVA: 0x0000BA50 File Offset: 0x00009C50
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(0, (int)base.projectile.position.X, (int)base.projectile.position.Y, 1, 1f, 0f);
			for (int i = 0; i < 5; i++)
			{
				Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, DustType<LunarDust>(), 0f, 0f, 0, default(Color), 1f);
			}
		}
	}
}
