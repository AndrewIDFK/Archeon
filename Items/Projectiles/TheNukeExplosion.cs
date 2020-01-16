using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x0200006F RID: 111
	public class TheNukeExplosion : ModProjectile
	{
		// Token: 0x060001D9 RID: 473 RVA: 0x0001044B File Offset: 0x0000E64B
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("NukeProjectile");
		}

		// Token: 0x060001DA RID: 474 RVA: 0x00010460 File Offset: 0x0000E660
		public override void SetDefaults()
		{
			base.projectile.damage = 9999;
			base.projectile.width = 32;
			base.projectile.height = 32;
			base.projectile.aiStyle = 1;
			base.projectile.friendly = false;
			base.projectile.hostile = true;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft = 240;
			projectile.scale = 1.8f;
		}

		// Token: 0x060001DB RID: 475 RVA: 0x000104D8 File Offset: 0x0000E6D8
		public override void Kill(int timeLeft)
		{
			Vector2 center = base.projectile.Center;
			Main.PlaySound(SoundID.Item14, (int)center.X, (int)center.Y);
			int num = 200;
			projectile.damage = 69420;
			for (int i = -num; i <= num; i++)
			{
				for (int j = -num; j <= num; j++)
				{
					int num2 = (int)((float)i + center.X / 16f);
					int num3 = (int)((float)j + center.Y / 16f);
					if (Math.Sqrt((double)(i * i + j * j)) <= (double)num + 0.5)
					{
						WorldGen.KillTile(num2, num3, false, false, false);
						Dust.NewDust(center, 22, 22, 31, 0f, 0f, 120, default(Color), 1f);
					}
				}
			}
		}
	}
}
