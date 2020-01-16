using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items
{
	// Token: 0x02000036 RID: 54
	public class NaturePotion : ModItem
	{
		// Token: 0x060000DE RID: 222 RVA: 0x00006C29 File Offset: 0x00004E29
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Nature Potion");
			base.Tooltip.SetDefault("Grants Dryad Blessing for 5 minutes");
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00006C4C File Offset: 0x00004E4C
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
			base.item.value = Item.buyPrice(0, 0, 45, 0);
			base.item.value = Item.sellPrice(0, 0, 45, 0);
			base.item.rare = 5;
			base.item.buffType = base.mod.BuffType("DryadBlessingBuff");
			base.item.buffTime = 18000;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00006D30 File Offset: 0x00004F30
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(66, 15);
			modRecipe.AddIngredient(313, 5);
			modRecipe.AddIngredient(126, 1);
			modRecipe.AddTile(13);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
