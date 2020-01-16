using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x0200008B RID: 139
	public class BloodButchererBuff : GlobalItem
	{
		// Token: 0x06000274 RID: 628 RVA: 0x00016627 File Offset: 0x00014827
		public override void SetDefaults(Item item)
		{
			if (item.type == 795)
			{
				item.damage = 32;
				item.useTime = 22;
				item.useAnimation = 22;
				item.autoReuse = true;
			}
		}
	}
}
