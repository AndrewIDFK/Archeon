using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.VanillaChanges
{
	public class TrueExcaliburBuff : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (item.type == 674)
			{
				item.damage = 72;
				item.useTime = 15;
				item.useAnimation = 15;
				item.autoReuse = true;
			}
		}
	}
}
