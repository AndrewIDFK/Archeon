using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items
{
	// Token: 0x02000030 RID: 48
	public class CrimsonPotion : ModItem
	{
		// Token: 0x060000C5 RID: 197 RVA: 0x000063F8 File Offset: 0x000045F8
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Crimson Potion");
			base.Tooltip.SetDefault("20% Damage increase for 2 Minutes");
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000641C File Offset: 0x0000461C
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
			base.item.buffType = base.mod.BuffType("CrimsonPotionBuff");
			base.item.buffTime = 8000;
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00006500 File Offset: 0x00004700
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(2305, 1);
			modRecipe.AddIngredient(2349, 1);
			modRecipe.AddIngredient(null, "VyssoniumOre", 2);
			modRecipe.AddTile(13);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
