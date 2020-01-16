using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Armor.RockSteele
{
	// Token: 0x02000043 RID: 67
	[AutoloadEquip(EquipType.Legs)]
	public class RockSteeleLeggings : ModItem
	{
		// Token: 0x06000116 RID: 278 RVA: 0x00007E05 File Offset: 0x00006005
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("RockSteele Greaves");
			base.Tooltip.SetDefault("You can feel your legs becoming one with RockSteele\n25% increased movement speed\n4% increased damage\n3% increased critical hit chance");
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00007E28 File Offset: 0x00006028
		public override void SetDefaults()
		{
			base.item.width = 18;
			base.item.height = 18;
			base.item.value = Item.buyPrice(0, 2, 40, 0);
			base.item.value = Item.sellPrice(0, 2, 40, 0);
			base.item.rare = 6;
			base.item.defense = 13;
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00007E94 File Offset: 0x00006094
		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.25f;
			player.meleeDamage += 0.04f;
			player.thrownDamage += 0.04f;
			player.rangedDamage += 0.04f;
			player.magicDamage += 0.04f;
			player.minionDamage += 0.04f;
			player.meleeCrit += 3;
			player.rangedCrit += 3;
			player.thrownCrit += 3;
			player.magicCrit += 3;
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00007F48 File Offset: 0x00006148
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
