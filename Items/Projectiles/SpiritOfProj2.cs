using System;
using Archeon.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Archeon.Items.Projectiles
{
	// Token: 0x02000054 RID: 84
	public class SpiritOfProj2  : ModProjectile
	{
		// Token: 0x0600016E RID: 366 RVA: 0x0000AEBC File Offset: 0x000090BC
		public override void SetDefaults()
		{
			base.projectile.scale = 1.15f;
			base.projectile.extraUpdates = 0;
			base.projectile.width = 16;
			base.projectile.height = 16;
			base.projectile.aiStyle = 1;
			this.aiType = 14;
			base.projectile.friendly = true;
			base.projectile.penetrate = 1;
			base.projectile.melee = true;
			Main.PlaySound(SoundID.Item15, base.projectile.position);
			//base.projectile.hide = true;
		}

		// Token: 0x0600016F RID: 367 RVA: 0x0000AF54 File Offset: 0x00009154
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.15f, 0.12f, 0.35f);
			int num21 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("SpoopDust1"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num21].velocity /= 160f;
			Main.dust[num21].scale = 0.95f;
			Main.dust[num21].noGravity = true;
			int num22 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("SpoopDust1"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num22].velocity /= 160f;
			Main.dust[num22].scale = 1.15f;
			Main.dust[num22].noGravity = true;


			float num2 = base.projectile.Center.X;
			float num3 = base.projectile.Center.Y;
			float num4 = 275f;
			bool flag = false;
			for (int j = 0; j < 135; j++)
			{
				if (Main.npc[j].CanBeChasedBy(base.projectile, false) && Collision.CanHit(base.projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
				{
					float num5 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
					float num6 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
					float num7 = Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num5) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num6);
					if (num7 < num4)
					{
						num4 = num7;
						num2 = num5;
						num3 = num6;
						flag = true;
					}
				}
			}
			if (flag)
			{
				float num8 = 32f;
				Vector2 vector = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
				float num9 = num2 - vector.X;
				float num10 = num3 - vector.Y;
				float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
				num11 = num8 / num11;
				num9 *= num11;
				num10 *= num11;
				base.projectile.velocity.X = (base.projectile.velocity.X * 20f + num9) / 21f;
				base.projectile.velocity.Y = (base.projectile.velocity.Y * 20f + num10) / 21f;
			}
		}



		// Token: 0x06000170 RID: 368 RVA: 0x0000B190 File Offset: 0x00009390
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(SoundID.Item10, base.projectile.position);
			for (int i = 0; i < 5; i++)
            {
                Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, base.mod.DustType("SpoopDust1"), 0f, 0f, 0, default(Color), 1f);
            }
			Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, base.mod.ProjectileType("SpiritExplosion"), base.projectile.damage - 6, base.projectile.knockBack, Main.myPlayer, 0f, 0f);
		}
	}
}