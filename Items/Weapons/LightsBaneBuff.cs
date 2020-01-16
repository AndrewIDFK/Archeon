using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x0200009E RID: 158
	public class LightsBaneBuff : GlobalItem
	{
		// Token: 0x060002CE RID: 718 RVA: 0x00018715 File Offset: 0x00016915
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
