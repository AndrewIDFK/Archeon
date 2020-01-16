using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Accessories
{
	// Token: 0x02000007 RID: 7
	public class ArcherGloves : ModItem
	{
		// Token: 0x06000030 RID: 48 RVA: 0x00003B37 File Offset: 0x00001D37
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Archer Gloves");
			base.Tooltip.SetDefault("Used by the Cultists to overtake the Dungeon\n25% increased ranged damage\n20% increased bow Speed\nGreatly increases arrow velocity");
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00003B5C File Offset: 0x00001D5C
		public override void SetDefaults()
		{
			base.item.width = 12;
			base.item.height = 16;
			base.item.value = Item.buyPrice(0, 7, 35, 0);
			base.item.value = Item.sellPrice(0, 7, 35, 0);
			base.item.rare = 9;
			base.item.accessory = true;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00003BC6 File Offset: 0x00001DC6
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.magicQuiver = true;
			player.archery = true;
			player.rangedDamage += 0.25f;
		}
	}
}
