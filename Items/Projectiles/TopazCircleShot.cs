using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x02000053 RID: 83
	public class TopazCircleShot : ModProjectile
	{
		// Token: 0x0600016A RID: 362 RVA: 0x0000A580 File Offset: 0x00008780
		public override void SetDefaults()
		{
			base.projectile.scale = 1f;
			base.projectile.extraUpdates = 0;
			base.projectile.width = 14;
			base.projectile.height = 14;
			//base.projectile.aiStyle = 27;
			base.projectile.friendly = true;
			base.projectile.penetrate = -1;
			base.projectile.tileCollide = false;
			base.projectile.magic = true;
			Main.PlaySound(SoundID.Item15, base.projectile.position);
			base.projectile.hide = false;
			//projectile.timeLeft = 100;
		}

		// Token: 0x0600016B RID: 363 RVA: 0x0000A618 File Offset: 0x00008818
		public override void AI()
			{
				Player player = Main.player[projectile.owner];

				double distance = 90;
				double degree = (double)projectile.ai[1] + (120 * projectile.ai[0]);
				double radius = degree * (Math.PI / 180);
				
				projectile.position.X = player.Center.X - (int)(Math.Cos(radius) * distance) - projectile.width / 2;
				projectile.position.Y = player.Center.Y - (int)(Math.Sin(radius) * distance) - projectile.height / 2;
				projectile.ai[1] += 4f;

				int numxd = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 64, base.projectile.velocity.X * 2f, base.projectile.velocity.Y * 2f, 100, default(Color), 1.4f);
				Main.dust[numxd].velocity /= 60f;
				Main.dust[numxd].scale = 1.2f;
				Main.dust[numxd].noGravity = true;
				
				Lighting.AddLight(projectile.position, 0.85f, 0.15f, 0.15f);
				
				bool flag = base.projectile.type == base.mod.ProjectileType("TopazCircleShot");
				MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
				if (modPlayer.TopazCircleS)
				{
					base.projectile.active = true;
					return;
				}
				
				if (flag)
				{
					if (player.dead)
					{
						modPlayer.TCS = false;
					}
					if (modPlayer.TCS)
					{
						base.projectile.timeLeft = 2;
					}
				}
			}

		// Token: 0x0600016C RID: 364 RVA: 0x0000A854 File Offset: 0x00008A54
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(SoundID.Item10, base.projectile.position);
		}
	}
}
