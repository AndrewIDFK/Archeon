using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Armor.Shadonium
{
	// Token: 0x02000041 RID: 65
	[AutoloadEquip(EquipType.Body)]
	public class ShadoniumChestplate : ModItem
	{
		// Token: 0x06000109 RID: 265 RVA: 0x00007978 File Offset: 0x00005B78
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			base.DisplayName.SetDefault("Shadonium Breastplate");
			base.Tooltip.SetDefault("Reduces damage taken by 6%");
		}

		// Token: 0x0600010A RID: 266 RVA: 0x000079A0 File Offset: 0x00005BA0
		public override void SetDefaults()
		{
			base.item.width = 18;
			base.item.height = 18;
			base.item.value = Item.buyPrice(0, 0, 95, 0);
			base.item.value = Item.sellPrice(0, 0, 95, 0);
			base.item.rare = 5;
			base.item.defense = 9;
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00007A0C File Offset: 0x00005C0C
		public override void UpdateEquip(Player player)
		{
			player.endurance += 0.06f;
			
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00007ABC File Offset: 0x00005CBC
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("ShadoniumBar"), 18);
			modRecipe.AddIngredient(86, 10);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
