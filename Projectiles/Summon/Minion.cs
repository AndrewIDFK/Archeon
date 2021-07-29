using System;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Projectiles.Summon
{
	public abstract class Minion : ModProjectile
	{
		public override void AI()
		{
			Behavior();
		}

		public abstract void Behavior();
	}
}
