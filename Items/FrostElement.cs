using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items
{
	// Token: 0x02000031 RID: 49
	public class FrostElement : ModItem
	{
		// Token: 0x060000C9 RID: 201 RVA: 0x0000655C File Offset: 0x0000475C
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Frost Shard");
			base.Tooltip.SetDefault("A Shard fuzed into Freezing Beings after [c/D81010:He] was imprisoned");
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00006580 File Offset: 0x00004780
		public override void SetDefaults()
		{
			base.item.width = 12;
			base.item.height = 12;
			base.item.rare = 7;
			base.item.value = Item.buyPrice(0, 0, 42, 0);
			base.item.value = Item.sellPrice(0, 0, 42, 0);
			base.item.maxStack = 99;
		}
	}
}
