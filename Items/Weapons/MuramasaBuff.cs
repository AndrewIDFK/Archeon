using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000A3 RID: 163
	public class MuramasaBuff : GlobalItem
	{
		// Token: 0x060002E5 RID: 741 RVA: 0x00018FCA File Offset: 0x000171CA
		public override void SetDefaults(Item item)
		{
			if (item.type == 155)
			{
				item.damage = 24;
				item.useTime = 17;
				item.useAnimation = 17;
				item.autoReuse = true;
				item.crit = 14;
			}
		}
	}
}
