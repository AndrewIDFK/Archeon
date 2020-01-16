using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Accessories
{
	// Token: 0x0200000C RID: 12
	public class GoldRushAmulet : ModItem
	{
		// Token: 0x06000048 RID: 72 RVA: 0x0000426B File Offset: 0x0000246B
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Gold Rush Amulet");
			base.Tooltip.SetDefault("Increases pick speed by 30%");
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00004290 File Offset: 0x00002490
		public override void SetDefaults()
		{
			base.item.width = 12;
			base.item.height = 16;
			base.item.value = Item.buyPrice(0, 1, 40, 0);
			base.item.value = Item.sellPrice(0, 1, 40, 0);
			base.item.rare = 5;
			base.item.accessory = true;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000042FC File Offset: 0x000024FC
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(19, 25);
			modRecipe.AddIngredient(3491, 1);
			modRecipe.AddIngredient(85, 5);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(706, 25);
			modRecipe.AddIngredient(3491, 1);
			modRecipe.AddIngredient(85, 5);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(19, 25);
			modRecipe.AddIngredient(3515, 1);
			modRecipe.AddIngredient(85, 5);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(706, 25);
			modRecipe.AddIngredient(3515, 1);
			modRecipe.AddIngredient(85, 5);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00004413 File Offset: 0x00002613
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.pickSpeed -= 0.3f;
		}
	}
}
