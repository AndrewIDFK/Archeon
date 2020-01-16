using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Bars
{
	// Token: 0x02000011 RID: 17
	public class PlasmiteBar : ModItem
	{
		// Token: 0x06000061 RID: 97 RVA: 0x000049D0 File Offset: 0x00002BD0
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Plasmite Bar");
			base.Tooltip.SetDefault("Pure heat in solid form\nThis bar and items made wioth this bar are not available for now, we are working on re-making Plasmite stuff entirely");
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000049F4 File Offset: 0x00002BF4
		public override void SetDefaults()
		{
			base.item.width = 24;
			base.item.height = 24;
			base.item.useTime = 15;
			base.item.useAnimation = 15;
			base.item.rare = 7;
			base.item.useStyle = 1;
			base.item.value = Item.buyPrice(0, 1, 45, 0);
			base.item.value = Item.sellPrice(0, 2, 45, 0);
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
			base.item.consumable = true;
			base.item.createTile = base.mod.TileType("PlasmiteBarTile");
			base.item.maxStack = 99;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00004AC8 File Offset: 0x00002CC8
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(null, "PlasmiteOre", 5);
			modRecipe.AddTile(133);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
