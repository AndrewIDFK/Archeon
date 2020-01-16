using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Accessories
{
	// Token: 0x0200000F RID: 15
	public class SuperiorGauntlet : ModItem
	{
		// Token: 0x06000057 RID: 87 RVA: 0x0000474F File Offset: 0x0000294F
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Superior Gauntlet");
			base.Tooltip.SetDefault("You become enraged!\n6% increased melee critical hit chance.\n9% increased melee damage.\n10% increased melee speed.\nIncreases maximum health by 10.\nEnemies are more likely to target you.");
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00004774 File Offset: 0x00002974
		public override void SetDefaults()
		{
			base.item.width = 12;
			base.item.height = 16;
			base.item.value = Item.buyPrice(0, 6, 0, 0);
			base.item.value = Item.sellPrice(0, 6, 0, 0);
			base.item.rare = 8;
			base.item.accessory = true;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000047DC File Offset: 0x000029DC
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("ThaniteBar"), 15);
			modRecipe.AddIngredient(1343, 1);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00004834 File Offset: 0x00002A34
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.aggro += 300;
			player.meleeCrit += 6;
			player.meleeDamage += 0.09f;
			player.meleeSpeed += 0.1f;
			player.statLifeMax2 += 10;
		}
	}
}
