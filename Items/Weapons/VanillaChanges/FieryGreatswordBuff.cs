using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.VanillaChanges
{
	public class FieryGreatswordBuff : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (item.type == 121)
			{
				item.damage = 48;
				item.useTime = 30;
				item.useAnimation = 30;
				item.autoReuse = true;
			}
		}
	}
}
