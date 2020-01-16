using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Armor
{
	// Token: 0x02000045 RID: 69
	[AutoloadEquip(EquipType.Head)]
	public class SquiddyInc : ModItem
	{
		// Token: 0x06000122 RID: 290 RVA: 0x000080BE File Offset: 0x000062BE
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			base.DisplayName.SetDefault("Squiddy Hat");
			base.Tooltip.SetDefault("Made by Squiddy Incorporated.");
		}

		// Token: 0x06000123 RID: 291 RVA: 0x000080E8 File Offset: 0x000062E8
		public override void SetDefaults()
		{
			base.item.width = 18;
			base.item.height = 18;
			base.item.value = Item.buyPrice(0, 1, 0, 0);
			base.item.value = Item.sellPrice(0, 1, 0, 0);
			base.item.rare = 11;
			base.item.vanity = true;
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00008150 File Offset: 0x00006350
		public override bool DrawHead()
		{
			return true;
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00008154 File Offset: 0x00006354
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(23, 30);
			modRecipe.AddIngredient(275, 5);
			modRecipe.AddIngredient(2626, 2);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
