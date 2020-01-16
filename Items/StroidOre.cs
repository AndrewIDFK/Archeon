using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items
{
	// Token: 0x0200003C RID: 60
	public class StroidOre : ModItem
	{
		// Token: 0x060000F6 RID: 246 RVA: 0x000073CE File Offset: 0x000055CE
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Stroid Ore");
			base.Tooltip.SetDefault("Superb material from outer space");
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x000073F0 File Offset: 0x000055F0
		public override void SetDefaults()
		{
			base.item.width = 12;
			base.item.height = 12;
			base.item.useTime = 10;
			base.item.useAnimation = 15;
			base.item.rare = 6;
			base.item.useStyle = 1;
			base.item.value = Item.buyPrice(0, 0, 30, 0);
			base.item.value = Item.sellPrice(0, 0, 30, 0);
			base.item.autoReuse = true;
			base.item.consumable = true;
			base.item.createTile = base.mod.TileType("StroidTile");
			base.item.maxStack = 999;
			base.item.UseSound = SoundID.Item1;
		}
	}
}
