using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Tools
{
	// Token: 0x02000080 RID: 128
	public class OrdealPax : ModItem
	{
		// Token: 0x06000248 RID: 584 RVA: 0x000156EB File Offset: 0x000138EB
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Ordeal Pax");
			base.Tooltip.SetDefault("You feel miserable while holding it");
		}

		// Token: 0x06000249 RID: 585 RVA: 0x00015710 File Offset: 0x00013910
		public override void SetDefaults()
		{
			base.item.damage = 16;
			base.item.melee = true;
			base.item.width = 34;
			base.item.height = 34;
			base.item.useTime = 14;
			base.item.useAnimation = 14;
			base.item.pick = 100;
			base.item.axe = 15;
			base.item.useStyle = 1;
			base.item.knockBack = 7f;
			base.item.value = Item.buyPrice(0, 1, 30, 0);
			base.item.value = Item.sellPrice(0, 1, 30, 0);
			base.item.rare = 5;
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
		}

		// Token: 0x0600024A RID: 586 RVA: 0x000157F4 File Offset: 0x000139F4
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("ShadoniumBar"), 20);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
