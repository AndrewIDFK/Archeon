using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Accessories
{
	// Token: 0x02000009 RID: 9
	public class CorruptNecklace : ModItem
	{
		// Token: 0x06000039 RID: 57 RVA: 0x00003E4C File Offset: 0x0000204C
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Shadow Necklace");
			base.Tooltip.SetDefault("It starts to glow purple when in the corruption.\nIncreased defense and health regeneration while in the Corruption.");
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00003E70 File Offset: 0x00002070
		public override void SetDefaults()
		{
			base.item.width = 12;
			base.item.height = 16;
			base.item.value = Item.buyPrice(0, 1, 75, 0);
			base.item.value = Item.sellPrice(0, 1, 75, 0);
			base.item.rare = 4;
			base.item.accessory = true;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00003EDC File Offset: 0x000020DC
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("ShadoniumBar"), 5);
			modRecipe.AddIngredient(86, 5);
			modRecipe.AddTile(26);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00003F2C File Offset: 0x0000212C
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.ZoneCorrupt)
			{
				player.lifeRegen += 2;
				player.statDefense += 6;
				Lighting.AddLight((int)(player.Center.X / 16f), (int)(player.Center.Y / 16f), 0.71f, 0.13f, 0.85f);
			}
		}
	}
}
