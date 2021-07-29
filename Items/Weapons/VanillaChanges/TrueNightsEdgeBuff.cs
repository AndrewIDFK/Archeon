using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.VanillaChanges
{
	public class TrueNightsEdgeBuff : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (item.type == 675)
			{
				item.damage = 90;
				item.useTime = 23;
				item.useAnimation = 23;
				item.autoReuse = true;
			}
		}
	}
}
