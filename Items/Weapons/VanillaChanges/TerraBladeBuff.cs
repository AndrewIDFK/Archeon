using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.VanillaChanges
{
	public class TerraBladeBuff : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (item.type == 757)
			{
				item.damage = 100;
				item.useTime = 15;
				item.useAnimation = 15;
				item.autoReuse = true;
				item.crit = 5;
			}
		}
	}
}
