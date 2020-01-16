using System;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles.Minions
{
	// Token: 0x02000071 RID: 113
	public abstract class Minion : ModProjectile
	{
		// Token: 0x060001E2 RID: 482 RVA: 0x0001081A File Offset: 0x0000EA1A
		public override void AI()
		{
			this.CheckActive();
			this.Behavior();
		}

		// Token: 0x060001E3 RID: 483
		public abstract void CheckActive();

		// Token: 0x060001E4 RID: 484
		public abstract void Behavior();
	}
}
