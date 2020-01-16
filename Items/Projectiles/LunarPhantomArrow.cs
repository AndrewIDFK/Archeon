using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x0200005A RID: 90
	public class LunarPhantomArrow : ModProjectile
	{
		// Token: 0x0600018A RID: 394 RVA: 0x0000BEC4 File Offset: 0x0000A0C4
		public override void SetDefaults()
		{
			base.projectile.width = 8;
			base.projectile.height = 8;
			base.projectile.friendly = true;
			base.projectile.hostile = false;
			base.projectile.tileCollide = true;
			base.projectile.ignoreWater = true;
			base.projectile.ranged = true;
			base.projectile.penetrate = 3;
			base.projectile.aiStyle = 1;
			base.projectile.scale = 1.4f;
		}

		// Token: 0x0600018B RID: 395 RVA: 0x0000BF50 File Offset: 0x0000A150
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.3f, 0.505f, 0.61f);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("LunarDust"), base.projectile.velocity.X * -0.5f, base.projectile.velocity.Y * -0.5f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 80f;
			Main.dust[num].scale = 0.8f;
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + MathHelper.ToRadians(270f);
			for (int i = 0; i < 200; i++)
			{
				NPC npc = Main.npc[i];
				float num2 = npc.position.X + (float)npc.width * 0.5f - base.projectile.Center.X;
				float num3 = npc.position.Y - base.projectile.Center.Y;
				float num4 = (float)Math.Sqrt((double)(num2 * num2 + num3 * num3));
				if (num4 < 375f && !npc.friendly && npc.active && base.projectile.ai[0] > 6f)
				{
					num4 = 3f / num4;
					num2 *= num4 * 5f;
					num3 *= num4 * 5f;
					int num5 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, num2 * 2f, num3 * 2f, base.mod.ProjectileType("LunarPhantomArrowHoming"), base.projectile.damage, base.projectile.knockBack, Main.myPlayer, 0f, 0f);
					Main.projectile[num5].timeLeft = 150;
					Main.projectile[num5].netUpdate = true;
					base.projectile.netUpdate = true;
					Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 12, 1f, 0f);
					base.projectile.ai[0] = -50f;
				}
			}
			base.projectile.ai[0] += 1f;
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0000C240 File Offset: 0x0000A440
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(SoundID.Item10, base.projectile.position);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("LunarDust"), base.projectile.velocity.X * -30.2f, base.projectile.velocity.Y * -14.7f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 80f;
			Main.dust[num].scale = 1.1f;
			int num2 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("LunarDust"), base.projectile.velocity.X * -10.4f, base.projectile.velocity.Y * 2.9f, 0, default(Color), 1f);
			Main.dust[num2].velocity /= 80f;
			Main.dust[num2].scale = 1.1f;
			int num3 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("LunarDust"), base.projectile.velocity.X * 30.9f, base.projectile.velocity.Y * -21.9f, 0, default(Color), 1f);
			Main.dust[num3].velocity /= 80f;
			Main.dust[num3].scale = 1.1f;
			int num4 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("LunarDust"), base.projectile.velocity.X * -22.4f, base.projectile.velocity.Y * 11.6f, 0, default(Color), 1f);
			Main.dust[num4].velocity /= 80f;
			Main.dust[num4].scale = 1.1f;
			int num5 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("LunarDust"), base.projectile.velocity.X * -20.2f, base.projectile.velocity.Y * -10.7f, 0, default(Color), 1f);
			Main.dust[num5].velocity /= 80f;
			Main.dust[num5].scale = 1.1f;
		}
	}
}
