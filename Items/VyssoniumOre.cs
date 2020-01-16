using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items
{
	// Token: 0x0200003F RID: 63
	public class VyssoniumOre : ModItem
	{
		// Token: 0x06000100 RID: 256 RVA: 0x0000774C File Offset: 0x0000594C
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Vyssonium Ore");
			base.Tooltip.SetDefault("Crimson has fully infected it");
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00007770 File Offset: 0x00005970
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
			base.item.createTile = base.mod.TileType("VyssoniumTile");
			base.item.maxStack = 999;
			base.item.UseSound = SoundID.Item1;
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00007848 File Offset: 0x00005A48
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("ShadoniumOre"), 1);
			modRecipe.AddTile(77);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
