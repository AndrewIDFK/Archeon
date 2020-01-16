using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace Archeon.Items.Projectiles.Minions
{
	// Token: 0x02000075 RID: 117
	public class PhantasmDragonTail : PhantasmDragonMinionAI
	{
		// Token: 0x06000200 RID: 512 RVA: 0x00012512 File Offset: 0x00010712
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Phantasm Dragon Tail");
		}

		// Token: 0x06000201 RID: 513 RVA: 0x00012524 File Offset: 0x00010724
		public override void CheckActive()
		{
			Player player = Main.player[base.projectile.owner];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.dead)
			{
				modPlayer.PhantasmDragonMinion = false;
			}
			if (modPlayer.PhantasmDragonMinion)
			{
				base.projectile.timeLeft = 2;
			}
		}

		// Token: 0x06000202 RID: 514 RVA: 0x00012574 File Offset: 0x00010774
		public override void SetDefaults()
		{
			base.projectile.width = 28;
			base.projectile.height = 110;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft *= 5;
			base.projectile.minion = true;
			base.projectile.friendly = true;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.alpha = 255;
			base.projectile.netImportant = true;
			base.projectile.hide = true;
		}

		// Token: 0x06000203 RID: 515 RVA: 0x00012612 File Offset: 0x00010812
		public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverWiresUI)
		{
			drawCacheProjsBehindProjectiles.Add(index);
		}

		// Token: 0x06000204 RID: 516 RVA: 0x0001261C File Offset: 0x0001081C
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.projectileTexture[base.projectile.type];
			int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
			int y = num * base.projectile.frame;
			Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.projectile.GetAlpha(Color.White), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, (base.projectile.spriteDirection == 1) ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
			return false;
		}

		// Token: 0x06000205 RID: 517 RVA: 0x00012718 File Offset: 0x00010918
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
				modPlayer.PhantasmDragonMinion = false;
			}
			if (modPlayer.PhantasmDragonMinion)
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
				if (Main.projectile[byUUID].type != base.mod.ProjectileType("PhantasmDragonHead"))
				{
					Main.projectile[byUUID].localAI[1] = (float)base.projectile.whoAmI;
				}
				if (base.projectile.owner == player.whoAmI && Main.projectile[byUUID].type == base.mod.ProjectileType("PhantasmDragonHead"))
				{
					Main.projectile[byUUID].Kill();
					base.projectile.Kill();
					return;
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
					int num5 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, base.mod.DustType("PhantasmDragonDust"), 0f, 0f, 100, default(Color), 2f);
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

		// Token: 0x06000206 RID: 518 RVA: 0x00012B25 File Offset: 0x00010D25
		public override bool MinionContactDamage()
		{
			return true;
		}
	}
}
