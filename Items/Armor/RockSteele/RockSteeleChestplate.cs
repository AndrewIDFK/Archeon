using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Armor.RockSteele
{
	// Token: 0x02000041 RID: 65
	[AutoloadEquip(EquipType.Body)]
	public class RockSteeleChestplate : ModItem
	{
		// Token: 0x06000109 RID: 265 RVA: 0x00007978 File Offset: 0x00005B78
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			base.DisplayName.SetDefault("RockSteele Chestplate");
			base.Tooltip.SetDefault("You feel Powerful\n5% increased damage\n4% increased critical hit chance\n25 extra Health Points");
		}

		// Token: 0x0600010A RID: 266 RVA: 0x000079A0 File Offset: 0x00005BA0
		public override void SetDefaults()
		{
			base.item.width = 18;
			base.item.height = 18;
			base.item.value = Item.buyPrice(0, 2, 80, 0);
			base.item.value = Item.sellPrice(0, 2, 80, 0);
			base.item.rare = 6;
			base.item.defense = 18;
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00007A0C File Offset: 0x00005C0C
		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.05f;
			player.thrownDamage += 0.05f;
			player.rangedDamage += 0.05f;
			player.magicDamage += 0.05f;
			player.minionDamage += 0.05f;
			player.meleeCrit += 4;
			player.rangedCrit += 4;
			player.thrownCrit += 4;
			player.magicCrit += 4;
			player.statLifeMax2 += 25;
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00007ABC File Offset: 0x00005CBC
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("RockSteeleBar"), 20);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
