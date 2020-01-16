using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000C1 RID: 193
	public class TridentBuff : GlobalItem
	{
		// Token: 0x0600037D RID: 893 RVA: 0x0001D2B2 File Offset: 0x0001B4B2
		public override void SetDefaults(Item item)
		{
			if (item.type == 277)
			{
				item.damage = 22;
				item.useTime = 26;
				item.useAnimation = 26;
				item.autoReuse = true;
			}
		}
	}
}
