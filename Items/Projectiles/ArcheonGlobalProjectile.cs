using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x020001EF RID: 495
	public class ArcheonGlobalProjectile : GlobalProjectile
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000AFF RID: 2815 RVA: 0x00044EB8 File Offset: 0x000430B8
		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}
		
		public static void DrawCenteredAndAfterimage(Projectile projectile, Color lightColor, int trailingMode, int afterimageCounter)
		{
			Texture2D texture2D = Main.projectileTexture[projectile.type];
			int num = texture2D.Height / Main.projFrames[projectile.type];
			int y = num * projectile.frame;
			Rectangle rectangle = new Rectangle(0, y, texture2D.Width, num);
			SpriteEffects effects = SpriteEffects.None;
			if (projectile.spriteDirection == -1)
			{
				effects = SpriteEffects.FlipHorizontally;
			}
			if (Lighting.NotRetro)
			{
				if (trailingMode != 0)
				{
					if (trailingMode == 1)
					{
						Color color = Lighting.GetColor((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f));
						int num2 = 8;
						for (int i = 1; i < num2; i += afterimageCounter)
						{
							Color color2 = color;
							color2 = projectile.GetAlpha(color2);
							float num3 = (float)(num2 - i);
							color2 *= num3 / ((float)ProjectileID.Sets.TrailCacheLength[projectile.type] * 1.5f);
							Main.spriteBatch.Draw(texture2D, projectile.oldPos[i] + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Rectangle?(rectangle), color2, projectile.rotation, Utils.Size(rectangle) / 2f, projectile.scale, effects, 0f);
						}
					}
				}
				else
				{
					for (int j = 0; j < projectile.oldPos.Length; j++)
					{
						Vector2 position = projectile.oldPos[j] + projectile.Size / 2f - Main.screenPosition + new Vector2(0f, projectile.gfxOffY);
						Color color3 = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - j) / (float)projectile.oldPos.Length);
						Main.spriteBatch.Draw(texture2D, position, new Rectangle?(rectangle), color3, projectile.rotation, Utils.Size(rectangle) / 2f, projectile.scale, effects, 0f);
					}
				}
			}
			Main.spriteBatch.Draw(texture2D, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), projectile.GetAlpha(lightColor), projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), projectile.scale, effects, 0f);
		}
	}
}