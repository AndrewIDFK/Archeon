using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Tools
{
	// Token: 0x02000086 RID: 134
	public class ThanitePickaxe : ModItem
	{
		// Token: 0x06000260 RID: 608 RVA: 0x00015FDE File Offset: 0x000141DE
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Thanite Pickaxe");
			base.Tooltip.SetDefault("An extremely fast pickaxe");
		}

		// Token: 0x06000261 RID: 609 RVA: 0x00016000 File Offset: 0x00014200
		public override void SetDefaults()
		{
			base.item.damage = 28;
			base.item.melee = true;
			base.item.width = 34;
			base.item.height = 34;
			base.item.useTime = 3;
			base.item.useAnimation = 13;
			base.item.pick = 210;
			base.item.useStyle = 1;
			base.item.knockBack = 7f;
			base.item.value = Item.buyPrice(0, 4, 50, 0);
			base.item.value = Item.sellPrice(0, 4, 50, 0);
			base.item.rare = 6;
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
			base.item.useTurn = true;
		}

		// Token: 0x06000262 RID: 610 RVA: 0x000160E4 File Offset: 0x000142E4
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("ThaniteBar"), 16);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
