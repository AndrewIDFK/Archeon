using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Bars
{
	// Token: 0x02000017 RID: 23
	public class StroidBar : ModItem
	{
		// Token: 0x06000073 RID: 115 RVA: 0x00004F41 File Offset: 0x00003141
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Stroid Bar");
			base.Tooltip.SetDefault("Forged from the stars");
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00004F64 File Offset: 0x00003164
		public override void SetDefaults()
		{
			base.item.width = 24;
			base.item.height = 24;
			base.item.useTime = 15;
			base.item.useAnimation = 15;
			base.item.rare = 7;
			base.item.useStyle = 1;
			base.item.value = Item.buyPrice(0, 2, 60, 0);
			base.item.value = Item.sellPrice(0, 2, 60, 0);
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
			base.item.consumable = true;
			base.item.createTile = base.mod.TileType("StroidBarTile");
			base.item.maxStack = 99;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00005038 File Offset: 0x00003238
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(null, "StroidOre", 5);
			modRecipe.AddTile(133);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
