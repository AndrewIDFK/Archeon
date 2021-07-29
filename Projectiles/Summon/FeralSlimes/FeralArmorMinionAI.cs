using System;

namespace Archeon.Projectiles.Summon.FeralSlimes
{
	public abstract class FeralArmorMinionAI : Minion
	{
		public virtual void CreateDust()
		{
		}

		public virtual void SelectFrame()
		{
		}

		public override void Behavior()
		{
		}

		public override bool MinionContactDamage()
		{
			return true;
		}

		public void TileCollideStyle(ref bool fallThrough)
		{
			fallThrough = true;
		}

		protected float idleAccel = 0.065f;

		protected float spacingMult = 1.1f;

		protected float viewDist = 450f;

		protected float chaseDist = 200f;

		protected float chaseAccel = 7.5f;

		protected float inertia = 39f;
	}
}
