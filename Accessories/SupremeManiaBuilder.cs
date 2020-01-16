using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Accessories
{
	// Token: 0x02000010 RID: 16
	public class SupremeManiaBuilder : ModItem
	{
		// Token: 0x0600005C RID: 92 RVA: 0x0000489C File Offset: 0x00002A9C
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Supreme Mania Builder");
			base.Tooltip.SetDefault("This relic was once used by the Elders to rebuild the world after [c/D81010:He] destroyed it...\nUnbelivable placement Speed and Range!\nHas the ability to auto paint.");
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000048C0 File Offset: 0x00002AC0
		public override void SetDefaults()
		{
			base.item.width = 12;
			base.item.height = 16;
			base.item.value = Item.buyPrice(0, 5, 90, 0);
			base.item.value = Item.sellPrice(0, 5, 90, 0);
			base.item.rare = 9;
			base.item.accessory = true;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x0000492C File Offset: 0x00002B2C
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(3061, 1);
			modRecipe.AddIngredient(1225, 8);
			modRecipe.AddIngredient(base.mod.ItemType("BuilderMania"), 1);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		// Token: 0x0600005F RID: 95 RVA: 0x0000498D File Offset: 0x00002B8D
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.tileSpeed += 0.85f;
			player.wallSpeed += 1.25f;
			player.blockRange += 5;
			player.autoPaint = true;
		}
	}
}
