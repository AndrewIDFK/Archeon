using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Accessories
{
	// Token: 0x02000044 RID: 68
	[AutoloadEquip(EquipType.Wings)]
	public class RockSteeleWings : ModItem
	{
		// Token: 0x0600011B RID: 283 RVA: 0x00007F9A File Offset: 0x0000619A
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("RockSteele Wings");
			base.Tooltip.SetDefault("Fly forward with exceptional speed!");
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00007FBC File Offset: 0x000061BC
		public override void SetDefaults()
		{
			base.item.width = 22;
			base.item.height = 20;
			base.item.value = Item.buyPrice(0, 2, 80, 0);
			base.item.value = Item.sellPrice(0, 2, 80, 0);
			base.item.rare = 6;
			base.item.accessory = true;
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00008025 File Offset: 0x00006225
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 75;
		}

		// Token: 0x0600011E RID: 286 RVA: 0x0000802F File Offset: 0x0000622F
		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.45f;
			ascentWhenRising = 0.7f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 2.5f;
			constantAscend = 0.105f;
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00008057 File Offset: 0x00006257
		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 9.1f;
			acceleration *= 1.33f;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x0000806C File Offset: 0x0000626C
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("RockSteeleBar"), 16);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
