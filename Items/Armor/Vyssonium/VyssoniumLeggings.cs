using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Armor.Vyssonium
{
	// Token: 0x02000043 RID: 67
	[AutoloadEquip(EquipType.Legs)]
	public class VyssoniumLeggings : ModItem
	{
		// Token: 0x06000116 RID: 278 RVA: 0x00007E05 File Offset: 0x00006005
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Vyssonium Greaves");
			base.Tooltip.SetDefault("10% increased movement speed and 4% increased melee speed");
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00007E28 File Offset: 0x00006028
		public override void SetDefaults()
		{
			base.item.width = 18;
			base.item.height = 18;
			base.item.value = Item.buyPrice(0, 0, 70, 0);
			base.item.value = Item.sellPrice(0, 0, 70, 0);
			base.item.rare = 5;
			base.item.defense = 7;
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00007E94 File Offset: 0x00006094
		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.1f;
			player.meleeSpeed += 0.04f;
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00007D80 File Offset: 0x00005F80
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("VyssoniumBar"), 14);
			modRecipe.AddIngredient(1329, 6);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
