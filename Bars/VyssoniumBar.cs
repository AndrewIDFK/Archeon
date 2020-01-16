using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Bars
{
	// Token: 0x0200001B RID: 27
	public class VyssoniumBar : ModItem
	{
		// Token: 0x0600007F RID: 127 RVA: 0x000052AC File Offset: 0x000034AC
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Vyssonium Bar");
			base.Tooltip.SetDefault("Crimson has fully infected it");
		}

		// Token: 0x06000080 RID: 128 RVA: 0x000052D0 File Offset: 0x000034D0
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
			base.item.createTile = base.mod.TileType("VyssoniumBarTile");
			base.item.maxStack = 99;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000053A4 File Offset: 0x000035A4
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(null, "VyssoniumOre", 3);
			modRecipe.AddTile(77);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("ShadoniumBar"), 1);
			modRecipe.AddTile(77);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(836, 1);
			modRecipe.AddTile(114);
			modRecipe.SetResult(61, 1);
			modRecipe.AddRecipe();
		}
	}
}
