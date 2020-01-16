using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items
{
	// Token: 0x02000037 RID: 55
	public class PlasmiteOre : ModItem
	{
		// Token: 0x060000E2 RID: 226 RVA: 0x00006D86 File Offset: 0x00004F86
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Plasmite Ore");
			base.Tooltip.SetDefault("The heat is melting your insides");
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00006DA8 File Offset: 0x00004FA8
		public override void SetDefaults()
		{
			base.item.width = 12;
			base.item.height = 12;
			base.item.useTime = 10;
			base.item.useAnimation = 15;
			base.item.rare = 8;
			base.item.useStyle = 1;
			base.item.value = Item.buyPrice(0, 0, 40, 0);
			base.item.value = Item.sellPrice(0, 0, 40, 0);
			base.item.autoReuse = true;
			base.item.consumable = true;
			base.item.createTile = base.mod.TileType("PlasmiteTile");
			base.item.maxStack = 999;
			base.item.UseSound = SoundID.Item1;
		}
	}
}
