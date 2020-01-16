using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Bars
{
	// Token: 0x02000013 RID: 19
	public class RockSteeleBar : ModItem
	{
		// Token: 0x06000067 RID: 103 RVA: 0x00004B81 File Offset: 0x00002D81
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("RockSteele Bar");
			base.Tooltip.SetDefault("The Bar is overwhelmingly heavy");
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00004BA4 File Offset: 0x00002DA4
		public override void SetDefaults()
		{
			base.item.width = 24;
			base.item.height = 24;
			base.item.useTime = 20;
			base.item.useAnimation = 20;
			base.item.rare = 3;
			base.item.useStyle = 1;
			base.item.value = Item.buyPrice(0, 0, 40, 0);
			base.item.value = Item.sellPrice(0, 0, 40, 0);
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
			base.item.consumable = true;
			base.item.createTile = base.mod.TileType("RockSteeleBarTile");
			base.item.maxStack = 44;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00004C78 File Offset: 0x00002E78
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(null, "RockSteeleOre", 4);
			modRecipe.AddTile(133);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
