using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x02000088 RID: 136
	public class BladeofGrassBuff : GlobalItem
	{
		// Token: 0x06000268 RID: 616 RVA: 0x0001631D File Offset: 0x0001451D
		public override void SetDefaults(Item item)
		{
			if (item.type == 190)
			{
				item.damage = 36;
				item.useTime = 26;
				item.useAnimation = 26;
				item.autoReuse = true;
			}
		}
	}
}
