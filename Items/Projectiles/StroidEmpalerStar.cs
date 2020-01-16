using System;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x02000069 RID: 105
	public class StroidEmpalerStar : ModProjectile
	{
		// Token: 0x060001C7 RID: 455 RVA: 0x0000FB60 File Offset: 0x0000DD60
		public override void SetDefaults()
		{
			base.projectile.CloneDefaults(9);
			this.aiType = 9;
			base.projectile.scale = 1.4f;
		}
	}
}
