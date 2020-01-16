using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items
{
	// Token: 0x0200003A RID: 58
	public class RockSteeleOre : ModItem
	{
		// Token: 0x060000EF RID: 239 RVA: 0x00007183 File Offset: 0x00005383
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("RockSteele Ore");
			base.Tooltip.SetDefault("Much heavier than it looks");
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x000071A8 File Offset: 0x000053A8
		public override void SetDefaults()
		{
			base.item.width = 12;
			base.item.height = 12;
			base.item.useTime = 10;
			base.item.useAnimation = 15;
			base.item.rare = 5;
			base.item.useStyle = 1;
			base.item.value = Item.buyPrice(0, 0, 15, 0);
			base.item.value = Item.sellPrice(0, 0, 15, 0);
			base.item.autoReuse = true;
			base.item.consumable = true;
			base.item.createTile = base.mod.TileType("RockSteeleTile");
			base.item.maxStack = 444;
			base.item.UseSound = SoundID.Item1;
		}
	}
}
