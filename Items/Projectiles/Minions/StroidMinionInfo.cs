using System;

namespace Archeon.Items.Projectiles.Minions
{
	// Token: 0x02000077 RID: 119
	public abstract class StroidMinionInfo : Minion
	{
		// Token: 0x0600020E RID: 526 RVA: 0x00012BA0 File Offset: 0x00010DA0
		public virtual void CreateDust()
		{
		}

		// Token: 0x0600020F RID: 527 RVA: 0x00012BA2 File Offset: 0x00010DA2
		public virtual void SelectFrame()
		{
		}

		// Token: 0x06000210 RID: 528 RVA: 0x00012BA4 File Offset: 0x00010DA4
		public override void Behavior()
		{
		}

		// Token: 0x06000211 RID: 529 RVA: 0x00012BA6 File Offset: 0x00010DA6
		public override bool MinionContactDamage()
		{
			return true;
		}

		// Token: 0x06000212 RID: 530 RVA: 0x00012BA9 File Offset: 0x00010DA9
		public void TileCollideStyle(ref bool fallThrough)
		{
			fallThrough = true;
		}

		// Token: 0x04000035 RID: 53
		protected float idleAccel = 0.05f;

		// Token: 0x04000036 RID: 54
		protected float spacingMult = 1f;

		// Token: 0x04000037 RID: 55
		protected float viewDist = 300f;

		// Token: 0x04000038 RID: 56
		protected float chaseDist = 200f;

		// Token: 0x04000039 RID: 57
		protected float chaseAccel = 6f;

		// Token: 0x0400003A RID: 58
		protected float inertia = 40f;

		// Token: 0x0400003B RID: 59
		protected float shootCool = 50f;

		// Token: 0x0400003C RID: 60
		protected float shootSpeed;

		// Token: 0x0400003D RID: 61
		protected int shoot;
	}
}
