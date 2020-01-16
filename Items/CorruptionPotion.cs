using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items
{
	// Token: 0x0200002F RID: 47
	public class CorruptionPotion : ModItem
	{
		// Token: 0x060000C1 RID: 193 RVA: 0x00006296 File Offset: 0x00004496
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Corrupted Potion");
			base.Tooltip.SetDefault("Increased Defense by 14 for 2 Minutes!");
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x000062B8 File Offset: 0x000044B8
		public override void SetDefaults()
		{
			base.item.UseSound = SoundID.Item3;
			base.item.useStyle = 2;
			base.item.useTurn = true;
			base.item.useAnimation = 17;
			base.item.useTime = 17;
			base.item.maxStack = 30;
			base.item.consumable = true;
			base.item.width = 20;
			base.item.height = 28;
			base.item.value = Item.buyPrice(0, 0, 60, 0);
			base.item.value = Item.sellPrice(0, 0, 60, 0);
			base.item.rare = 5;
			base.item.buffType = base.mod.BuffType("CorruptionPotionBuff");
			base.item.buffTime = 8000;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000639C File Offset: 0x0000459C
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(2318, 1);
			modRecipe.AddIngredient(292, 1);
			modRecipe.AddIngredient(null, "ShadoniumOre", 2);
			modRecipe.AddTile(13);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
