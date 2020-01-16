using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Bars
{
	// Token: 0x02000019 RID: 25
	public class ThaniteBar : ModItem
	{
		// Token: 0x06000079 RID: 121 RVA: 0x000050FA File Offset: 0x000032FA
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Thanite Bar");
			base.Tooltip.SetDefault("It's having trouble holding its form");
		}

		// Token: 0x0600007A RID: 122 RVA: 0x0000511C File Offset: 0x0000331C
		public override void SetDefaults()
		{
			base.item.width = 24;
			base.item.height = 24;
			base.item.useTime = 15;
			base.item.useAnimation = 15;
			base.item.rare = 3;
			base.item.useStyle = 1;
			base.item.value = Item.buyPrice(0, 0, 45, 0);
			base.item.value = Item.sellPrice(0, 0, 45, 0);
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
			base.item.consumable = true;
			base.item.createTile = base.mod.TileType("ThaniteBarTile");
			base.item.maxStack = 99;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x000051F0 File Offset: 0x000033F0
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(null, "ThaniteOre", 4);
			modRecipe.AddTile(133);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
