using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000C2 RID: 194
	public class TrueExcaliburBuff : GlobalItem
	{
		// Token: 0x0600037F RID: 895 RVA: 0x0001D2E8 File Offset: 0x0001B4E8
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
