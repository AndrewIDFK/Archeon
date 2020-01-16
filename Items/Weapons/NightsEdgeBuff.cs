using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000A4 RID: 164
	public class NightsEdgeBuff : GlobalItem
	{
		// Token: 0x060002E7 RID: 743 RVA: 0x00019008 File Offset: 0x00017208
		public override void SetDefaults(Item item)
		{
			if (item.type == 273)
			{
				item.damage = 76;
				item.useTime = 24;
				item.useAnimation = 24;
				item.autoReuse = true;
			}
		}
	}
}
