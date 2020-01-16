using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items
{
	// Token: 0x02000038 RID: 56
	public class Tantrum : ModItem
	{
		// Token: 0x060000E5 RID: 229 RVA: 0x00006E86 File Offset: 0x00005086
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Tantrum");
			base.Tooltip.SetDefault("Bro, why are you throwing a Tantrum? \nIncreases Speed and Strength but poisons you.");
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00006EA8 File Offset: 0x000050A8
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
			base.item.value = Item.buyPrice(0, 1, 75, 0);
			base.item.value = Item.sellPrice(0, 1, 75, 0);
			base.item.rare = 7;
			base.item.buffType = base.mod.BuffType("TANTRUMBUFF");
			base.item.buffTime = 10000;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00006F8C File Offset: 0x0000518C
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(126, 1);
			modRecipe.AddIngredient(base.mod.ItemType("FeralShard"), 1);
			modRecipe.AddIngredient(1339, 3);
			modRecipe.AddTile(13);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
