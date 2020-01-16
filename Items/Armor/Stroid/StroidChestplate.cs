using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Armor.Stroid
{
	[AutoloadEquip(EquipType.Body)]
	public class StroidChestplate : ModItem
	{
		// Token: 0x06000127 RID: 295 RVA: 0x000081AD File Offset: 0x000063AD
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			base.DisplayName.SetDefault("Stroid Chestplate");
			base.Tooltip.SetDefault("8% increased Minion damage\n35 extra Health Points\nAdds an Extra Minion Slot");
		}

		// Token: 0x06000128 RID: 296 RVA: 0x000081D8 File Offset: 0x000063D8
		public override void SetDefaults()
		{
			base.item.width = 18;
			base.item.height = 18;
			base.item.value = Item.buyPrice(0, 5, 80, 0);
			base.item.value = Item.sellPrice(0, 5, 80, 0);
			base.item.rare = 7;
			base.item.defense = 22;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00008242 File Offset: 0x00006442
		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.08f;
			player.statLifeMax2 += 35;
			player.maxMinions++;
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00008274 File Offset: 0x00006474
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("StroidBar"), 20);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
