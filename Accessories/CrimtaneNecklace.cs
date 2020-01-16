using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Accessories
{
	// Token: 0x0200000A RID: 10
	public class CrimtaneNecklace : ModItem
	{
		// Token: 0x0600003E RID: 62 RVA: 0x00003F9D File Offset: 0x0000219D
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Crimtane Necklace");
			base.Tooltip.SetDefault("It starts to glow red when in the crimson.\nIncreased damage and melee speed while in the Crimson.");
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00003FC0 File Offset: 0x000021C0
		public override void SetDefaults()
		{
			base.item.width = 12;
			base.item.height = 16;
			base.item.value = Item.buyPrice(0, 1, 75, 0);
			base.item.value = Item.sellPrice(0, 1, 75, 0);
			base.item.rare = 4;
			base.item.accessory = true;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x0000402C File Offset: 0x0000222C
		public override void AddRecipes()		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("VyssoniumBar"), 5);
			modRecipe.AddIngredient(1329, 5);
			modRecipe.AddTile(26);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00004080 File Offset: 0x00002280
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.ZoneCrimson)
			{
				player.meleeDamage += 0.15f;
				player.meleeSpeed += 0.2f;
				Lighting.AddLight((int)(player.Center.X / 16f), (int)(player.Center.Y / 16f), 0.54f, 0.02f, 0.07f);
			}
		}
	}
}
