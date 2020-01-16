using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Armor.Stroid
{
	// Token: 0x02000048 RID: 72
	[AutoloadEquip(EquipType.Legs)]
	public class StroidLeggings : ModItem
	{
		// Token: 0x06000134 RID: 308 RVA: 0x0000848C File Offset: 0x0000668C
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Stroid Greaves");
			base.Tooltip.SetDefault("20% increased Movement speed\n6% increased Minion damage");
		}

		// Token: 0x06000135 RID: 309 RVA: 0x000084B0 File Offset: 0x000066B0
		public override void SetDefaults()
		{
			base.item.width = 18;
			base.item.height = 18;
			base.item.value = Item.buyPrice(0, 5, 40, 0);
			base.item.value = Item.sellPrice(0, 5, 40, 0);
			base.item.rare = 7;
			base.item.defense = 15;
		}

		// Token: 0x06000136 RID: 310 RVA: 0x0000851A File Offset: 0x0000671A
		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.2f;
			player.minionDamage += 0.06f;
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00008540 File Offset: 0x00006740
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("StroidBar"), 14);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
