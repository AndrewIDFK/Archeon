using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.VanillaChanges
{
	public class FetidBaghnakhsBuff : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (item.type == 3013)
			{
				item.damage = 77;
				item.useTime = 5;
				item.useAnimation = 5;
				item.autoReuse = true;
			}
		}
	}
}
