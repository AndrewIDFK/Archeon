using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Armor.Vyssonium
{
	// Token: 0x02000041 RID: 65
	[AutoloadEquip(EquipType.Body)]
	public class VyssoniumChestplate : ModItem
	{
		// Token: 0x06000109 RID: 265 RVA: 0x00007978 File Offset: 0x00005B78
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			base.DisplayName.SetDefault("Vyssonium Breastplate");
			base.Tooltip.SetDefault("6% increased melee speed and 4% melee damage");
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
			player.meleeSpeed += 0.06f;
			player.meleeDamage += 0.04f;
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00007D80 File Offset: 0x00005F80
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("VyssoniumBar"), 18);
			modRecipe.AddIngredient(1329, 10);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
