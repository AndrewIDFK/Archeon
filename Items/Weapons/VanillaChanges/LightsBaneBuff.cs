using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.VanillaChanges
{
	public class LightsBaneBuff : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (item.type == 46)
			{
				item.damage = 24;
				item.useTime = 17;
				item.useAnimation = 17;
				item.autoReuse = true;
			}
		}
	}
}
