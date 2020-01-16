using System;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x02000065 RID: 101
	public class StarfuryStar : ModProjectile
	{
		// Token: 0x060001B7 RID: 439 RVA: 0x0000F40E File Offset: 0x0000D60E
		public override void SetDefaults()
		{
			base.projectile.CloneDefaults(9);
			this.aiType = 9;
		}
	}
}
