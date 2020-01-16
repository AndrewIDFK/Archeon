using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x02000095 RID: 149
	public class FieryGreatswordBuff : GlobalItem
	{
		// Token: 0x060002A3 RID: 675 RVA: 0x000179AF File Offset: 0x00015BAF
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
