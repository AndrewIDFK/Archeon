using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000C3 RID: 195
	public class TrueNightsEdgeBuff : GlobalItem
	{
		// Token: 0x06000381 RID: 897 RVA: 0x0001D31E File Offset: 0x0001B51E
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
