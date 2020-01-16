using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace Archeon.Items.Projectiles.Minions
{
	// Token: 0x0200007A RID: 122
	public class StroidWormerBody : StroidWormerAI
	{
		// Token: 0x06000224 RID: 548 RVA: 0x00013DE9 File Offset: 0x00011FE9
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Stroid Eel Body 1");
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00013DFC File Offset: 0x00011FFC
		public override void CheckActive()
		{
			Player player = Main.player[base.projectile.owner];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.dead)
			{
				modPlayer.StroidWormer = false;
			}
			if (modPlayer.StroidWormer)
			{
				base.projectile.timeLeft = 2;
			}
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00013E4C File Offset: 0x0001204C
		public override void SetDefaults()
		{
			base.projectile.width = 22;
			base.projectile.height = 40;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft *= 5;
			base.projectile.minion = true;
			base.projectile.friendly = true;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.alpha = 255;
			base.projectile.netImportant = true;
			base.projectile.minionSlots = 0.25f;
			base.projectile.hide = true;
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00013EFA File Offset: 0x000120FA
		public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverWiresUI)
		{
			drawCacheProjsBehindProjectiles.Add(index);
		}

		// Token: 0x06000228 RID: 552 RVA: 0x00013F04 File Offset: 0x00012104
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.projectileTexture[base.projectile.type];
			int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
			int y = num * base.projectile.frame;
			Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.projectile.GetAlpha(Color.White), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, (base.projectile.spriteDirection == 1) ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
			return false;
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00014000 File Offset: 0x00012200
		public override void AI()
		{
			Player player = Main.player[base.projectile.owner];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if ((int)Main.time % 120 == 0)
			{
				base.projectile.netUpdate = true;
			}
			if (!player.active)
			{
				base.projectile.active = false;
				return;
			}
			if (player.dead)
			{
				modPlayer.StroidWormer = false;
			}
			if (modPlayer.StroidWormer)
			{
				base.projectile.timeLeft = 2;
			}
			int num = 30;
			bool flag = false;
			Vector2 value = Vector2.Zero;
			Vector2 zero = Vector2.Zero;
			float num2 = 0f;
			float scaleFactor = 0f;
			float num3 = 1f;
			if (base.projectile.ai[1] == 1f)
			{
				base.projectile.ai[1] = 0f;
				base.projectile.netUpdate = true;
			}
			int byUUID = Projectile.GetByUUID(base.projectile.owner, (int)base.projectile.ai[0]);
			if (byUUID >= 0 && Main.projectile[byUUID].active)
			{
				flag = true;
				value = Main.projectile[byUUID].Center;
				Vector2 velocity = Main.projectile[byUUID].velocity;
				num2 = Main.projectile[byUUID].rotation;
				float num4 = MathHelper.Clamp(Main.projectile[byUUID].scale, 0f, 50f);
				num3 = num4;
				scaleFactor = 16f;
				int alpha = Main.projectile[byUUID].alpha;
				Main.projectile[byUUID].localAI[0] = base.projectile.localAI[0] + 1f;
				if (Main.projectile[byUUID].type != base.mod.ProjectileType("StroidWormerHead"))
				{
					Main.projectile[byUUID].localAI[1] = (float)base.projectile.whoAmI;
				}
			}
			if (!flag)
			{
				return;
			}
			if (base.projectile.alpha > 0)
			{
				for (int i = 0; i < 2; i++)
				{
					int num5 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, base.mod.DustType("StroidWormDeathDust"), 0f, 0f, 70, default(Color), 2f);
					Main.dust[num5].noGravity = true;
					Main.dust[num5].noLight = true;
				}
			}
			base.projectile.alpha -= 42;
			if (base.projectile.alpha < 0)
			{
				base.projectile.alpha = 0;
			}
			base.projectile.velocity = Vector2.Zero;
			Vector2 vector = value - base.projectile.Center;
			if (num2 != base.projectile.rotation)
			{
				float num6 = MathHelper.WrapAngle(num2 - base.projectile.rotation);
				vector = Utils.RotatedBy(vector, (double)(num6 * 0.1f), default(Vector2));
			}
			base.projectile.rotation = Utils.ToRotation(vector) + 1.57079637f;
			base.projectile.position = base.projectile.Center;
			base.projectile.scale = num3;
			base.projectile.width = (base.projectile.height = (int)((float)num * base.projectile.scale));
			base.projectile.Center = base.projectile.position;
			if (vector != Vector2.Zero)
			{
				base.projectile.Center = value - Vector2.Normalize(vector) * scaleFactor * num3;
			}
			base.projectile.spriteDirection = ((vector.X > 0f) ? 1 : -1);
		}

		// Token: 0x0600022A RID: 554 RVA: 0x000143C4 File Offset: 0x000125C4
		public override void Kill(int timeLeft)
		{
			Player player = Main.player[base.projectile.owner];
			if (player.slotsMinions + base.projectile.minionSlots > (float)player.maxMinions && base.projectile.owner == Main.myPlayer)
			{
				int byUUID = Projectile.GetByUUID(base.projectile.owner, base.projectile.ai[0]);
				if (byUUID != -1)
				{
					Projectile projectile = Main.projectile[byUUID];
					if (projectile.type != base.mod.ProjectileType("StroidWormerHead"))
					{
						projectile.localAI[1] = base.projectile.localAI[1];
					}
					projectile = Main.projectile[(int)base.projectile.localAI[1]];
					projectile.ai[0] = base.projectile.ai[0];
					projectile.ai[1] = 1f;
					projectile.netUpdate = true;
				}
			}
		}

		// Token: 0x0600022B RID: 555 RVA: 0x000144AB File Offset: 0x000126AB
		public override bool MinionContactDamage()
		{
			return true;
		}
	}
}
