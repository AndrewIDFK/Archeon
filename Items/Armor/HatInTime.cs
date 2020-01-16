using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Armor
{
	// Token: 0x02000040 RID: 64
	[AutoloadEquip(EquipType.Head)]
	public class HatInTime : ModItem
	{
		// Token: 0x06000104 RID: 260 RVA: 0x00007896 File Offset: 0x00005A96
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			base.DisplayName.SetDefault("Hat in Time");
			base.Tooltip.SetDefault("No, it doesn't point you to your objective.");
		}

		// Token: 0x06000105 RID: 261 RVA: 0x000078C0 File Offset: 0x00005AC0
		public override void SetDefaults()
		{
			base.item.width = 18;
			base.item.height = 18;
			base.item.rare = 11;
			base.item.value = Item.buyPrice(0, 1, 0, 0);
			base.item.value = Item.sellPrice(0, 1, 0, 0);
			base.item.vanity = true;
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00007928 File Offset: 0x00005B28
		public override bool DrawHead()
		{
			return true;
		}

		// Token: 0x06000107 RID: 263 RVA: 0x0000792C File Offset: 0x00005B2C
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(15, 1);
			modRecipe.AddIngredient(239, 1);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
