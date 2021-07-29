using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.VanillaChanges
{
	public class BloodButchererBuff : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (item.type == 795)
			{
				item.damage = 32;
				item.useTime = 22;
				item.useAnimation = 22;
				item.autoReuse = true;
			}
		}
	}
}
