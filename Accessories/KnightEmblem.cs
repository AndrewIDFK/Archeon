using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Accessories
{
	// Token: 0x0200000D RID: 13
	public class KnightEmblem : ModItem
	{
		// Token: 0x0600004D RID: 77 RVA: 0x0000442F File Offset: 0x0000262F
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Knight Emblem");
			base.Tooltip.SetDefault("Harness the Royal Power!");
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00004454 File Offset: 0x00002654
		public override void SetDefaults()
		{
			base.item.width = 12;
			base.item.height = 16;
			base.item.value = Item.buyPrice(0, 10, 50, 0);
			base.item.value = Item.sellPrice(0, 10, 50, 0);
			base.item.rare = 8;
			base.item.accessory = true;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000044C0 File Offset: 0x000026C0
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(1612, 1);
			modRecipe.AddIngredient(1322, 1);
			modRecipe.AddIngredient(490, 1);
			modRecipe.AddIngredient(548, 15);
			modRecipe.AddIngredient(1225, 5);
			modRecipe.AddIngredient(536, 1);
			modRecipe.AddTile(114);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00004538 File Offset: 0x00002738
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.magmaStone = true;
			player.kbGlove = true;
			player.meleeDamage += 0.2f;
			player.meleeSpeed += 0.15f;
			player.buffImmune[33] = true;
			player.buffImmune[36] = true;
			player.buffImmune[30] = true;
			player.buffImmune[20] = true;
			player.buffImmune[32] = true;
			player.buffImmune[31] = true;
			player.buffImmune[35] = true;
			player.buffImmune[23] = true;
			player.buffImmune[22] = true;
		}
	}
}
