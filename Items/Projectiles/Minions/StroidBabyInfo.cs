using System;

namespace Archeon.Items.Projectiles.Minions
{
	// Token: 0x02000076 RID: 118
	public abstract class StroidBabyInfo : Minion
	{
		// Token: 0x06000208 RID: 520 RVA: 0x00012B30 File Offset: 0x00010D30
		public virtual void CreateDust()
		{
		}

		// Token: 0x06000209 RID: 521 RVA: 0x00012B32 File Offset: 0x00010D32
		public virtual void SelectFrame()
		{
		}

		// Token: 0x0600020A RID: 522 RVA: 0x00012B34 File Offset: 0x00010D34
		public override void Behavior()
		{
		}

		// Token: 0x0600020B RID: 523 RVA: 0x00012B36 File Offset: 0x00010D36
		public override bool MinionContactDamage()
		{
			return true;
		}

		// Token: 0x0600020C RID: 524 RVA: 0x00012B39 File Offset: 0x00010D39
		public void TileCollideStyle(ref bool fallThrough)
		{
			fallThrough = true;
		}

		// Token: 0x0400002C RID: 44
		protected float idleAccel = 0.05f;

		// Token: 0x0400002D RID: 45
		protected float spacingMult = 1f;

		// Token: 0x0400002E RID: 46
		protected float viewDist = 300f;

		// Token: 0x0400002F RID: 47
		protected float chaseDist = 200f;

		// Token: 0x04000030 RID: 48
		protected float chaseAccel = 6f;

		// Token: 0x04000031 RID: 49
		protected float inertia = 40f;

		// Token: 0x04000032 RID: 50
		protected float shootCool = 50f;

		// Token: 0x04000033 RID: 51
		protected float shootSpeed;

		// Token: 0x04000034 RID: 52
		protected int shoot;
	}
}
