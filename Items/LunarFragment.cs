using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items
{
	// Token: 0x02000033 RID: 51
	public class LunarFragment : ModItem
	{
		// Token: 0x060000D2 RID: 210 RVA: 0x00006958 File Offset: 0x00004B58
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Lunar Fragment");
			base.Tooltip.SetDefault("Fragments left behind by the Cultists");
			Main.RegisterItemAnimation(base.item.type, new DrawAnimationVertical(5, 10));
			ItemID.Sets.ItemNoGravity[base.item.type] = true;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000069B0 File Offset: 0x00004BB0
		public override void SetDefaults()
		{
			base.item.width = 12;
			base.item.height = 12;
			base.item.rare = 9;
			base.item.value = Item.buyPrice(0, 0, 80, 0);
			base.item.value = Item.sellPrice(0, 0, 80, 0);
			base.item.maxStack = 999;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00006A1E File Offset: 0x00004C1E
		public void AI()
		{
			Lighting.AddLight(base.item.Center, 0.37f, 0.5f, 1.83f);
		}
	}
}
