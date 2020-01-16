using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Tools
{
	// Token: 0x02000084 RID: 132
	public class ThaniteAxe : ModItem
	{
		// Token: 0x06000258 RID: 600 RVA: 0x00015CC8 File Offset: 0x00013EC8
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Thanite Axe");
			base.Tooltip.SetDefault("This is incredibly fast!");
		}

		// Token: 0x06000259 RID: 601 RVA: 0x00015CEC File Offset: 0x00013EEC
		public override void SetDefaults()
		{
			base.item.damage = 32;
			base.item.melee = true;
			base.item.width = 38;
			base.item.height = 38;
			base.item.useTime = 10;
			base.item.useAnimation = 12;
			base.item.axe = 31;
			base.item.useStyle = 1;
			base.item.knockBack = 9f;
			base.item.value = Item.buyPrice(0, 4, 50, 0);
			base.item.value = Item.sellPrice(0, 4, 50, 0);
			base.item.rare = 6;
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
			base.item.useTurn = true;
		}

		// Token: 0x0600025A RID: 602 RVA: 0x00015DD0 File Offset: 0x00013FD0
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("ThaniteBar"), 13);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
