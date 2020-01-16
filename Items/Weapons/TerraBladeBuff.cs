using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000BC RID: 188
	public class TerraBladeBuff : GlobalItem
	{
		// Token: 0x06000363 RID: 867 RVA: 0x0001C9A8 File Offset: 0x0001ABA8
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
