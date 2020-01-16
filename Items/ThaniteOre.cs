using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items
{
	// Token: 0x0200003D RID: 61
	public class ThaniteOre : ModItem
	{
		// Token: 0x060000F9 RID: 249 RVA: 0x000074CE File Offset: 0x000056CE
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Thanite Ore");
			base.Tooltip.SetDefault("You hear voices talking gibberish.");
		}

		// Token: 0x060000FA RID: 250 RVA: 0x000074F0 File Offset: 0x000056F0
		public override void SetDefaults()
		{
			base.item.width = 12;
			base.item.height = 12;
			base.item.useTime = 10;
			base.item.useAnimation = 15;
			base.item.rare = 5;
			base.item.useStyle = 1;
			base.item.value = Item.buyPrice(0, 0, 20, 0);
			base.item.value = Item.sellPrice(0, 0, 20, 0);
			base.item.autoReuse = true;
			base.item.consumable = true;
			base.item.createTile = base.mod.TileType("ThaniteTile");
			base.item.maxStack = 999;
			base.item.UseSound = SoundID.Item1;
		}
	}
}
