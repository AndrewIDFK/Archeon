using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items
{
	// Token: 0x0200003B RID: 59
	public class ShadoniumOre : ModItem
	{
		// Token: 0x060000F2 RID: 242 RVA: 0x00007286 File Offset: 0x00005486
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Shadonium Ore");
			base.Tooltip.SetDefault("Corruption has fully corrupted it");
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x000072A8 File Offset: 0x000054A8
		public override void SetDefaults()
		{
			base.item.width = 12;
			base.item.height = 12;
			base.item.useTime = 10;
			base.item.useAnimation = 15;
			base.item.rare = 4;
			base.item.useStyle = 1;
			base.item.value = Item.buyPrice(0, 0, 5, 0);
			base.item.value = Item.sellPrice(0, 0, 5, 0);
			base.item.autoReuse = true;
			base.item.consumable = true;
			base.item.createTile = base.mod.TileType("ShadoniumTile");
			base.item.maxStack = 999;
			base.item.UseSound = SoundID.Item1;
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00007380 File Offset: 0x00005580
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("VyssoniumOre"), 1);
			modRecipe.AddTile(77);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
