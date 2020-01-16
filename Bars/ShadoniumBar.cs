using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Bars
{
	// Token: 0x02000015 RID: 21
	public class ShadoniumBar : ModItem
	{
		// Token: 0x0600006D RID: 109 RVA: 0x00004D2D File Offset: 0x00002F2D
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Shadonium Bar");
			base.Tooltip.SetDefault("Corruption has fully corrupted it");
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00004D50 File Offset: 0x00002F50
		public override void SetDefaults()
		{
			base.item.width = 24;
			base.item.height = 24;
			base.item.useTime = 15;
			base.item.useAnimation = 15;
			base.item.rare = 3;
			base.item.useStyle = 1;
			base.item.value = Item.buyPrice(0, 0, 35, 0);
			base.item.value = Item.sellPrice(0, 0, 35, 0);
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
			base.item.consumable = true;
			base.item.createTile = base.mod.TileType("ShadoniumBarTile");
			base.item.maxStack = 99;
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00004E24 File Offset: 0x00003024
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(null, "ShadoniumOre", 3);
			modRecipe.AddTile(77);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("VyssoniumBar"), 1);
			modRecipe.AddTile(77);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(61, 1);
			modRecipe.AddTile(114);
			modRecipe.SetResult(836, 1);
			modRecipe.AddRecipe();
		}
	}
}
