using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.VanillaChanges
{
	public class DayBreakBuff : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (item.type == 3543)
			{
				item.damage = 175;
			}
		}
	}
}
