using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items
{
	// Token: 0x02000031 RID: 49
	public class FeralShard : ModItem
	{
		// Token: 0x060000C9 RID: 201 RVA: 0x0000655C File Offset: 0x0000475C
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Feral Shard");
			base.Tooltip.SetDefault("The Amalgamated tissue of sentient plants");
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00006580 File Offset: 0x00004780
		public override void SetDefaults()
		{
			base.item.width = 12;
			base.item.height = 12;
			base.item.rare = 7;
			base.item.value = Item.buyPrice(0, 0, 50, 0);
			base.item.value = Item.sellPrice(0, 0, 50, 0);
			base.item.maxStack = 99;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x000065EC File Offset: 0x000047EC
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("FeralShard"), 5);
			modRecipe.AddTile(114);
			modRecipe.SetResult(211, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("FeralShard"), 12);
			modRecipe.AddTile(134);
			modRecipe.SetResult(758, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("FeralShard"), 14);
			modRecipe.AddTile(134);
			modRecipe.SetResult(1255, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("FeralShard"), 10);
			modRecipe.AddTile(134);
			modRecipe.SetResult(788, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("FeralShard"), 11);
			modRecipe.AddTile(134);
			modRecipe.SetResult(1178, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("FeralShard"), 12);
			modRecipe.AddTile(134);
			modRecipe.SetResult(1259, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("FeralShard"), 13);
			modRecipe.AddTile(134);
			modRecipe.SetResult(1155, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("FeralShard"), 15);
			modRecipe.AddTile(134);
			modRecipe.SetResult(3018, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("FeralShard"), 15);
			modRecipe.AddTile(134);
			modRecipe.SetResult(3018, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(2273);
			modRecipe.AddIngredient(3514);
			modRecipe.AddTile(16);
			modRecipe.SetResult(3349);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(2273);
			modRecipe.AddIngredient(3490);
			modRecipe.AddTile(16);
			modRecipe.SetResult(3349);
			modRecipe.AddRecipe();
		}
	}
}
