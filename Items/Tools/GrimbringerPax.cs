using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Tools
{
	// Token: 0x0200007F RID: 127
	public class GrimbringerPax : ModItem
	{
		// Token: 0x06000244 RID: 580 RVA: 0x00015595 File Offset: 0x00013795
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Grimbringer Pax");
			base.Tooltip.SetDefault("You feel suicidal while holding it");
		}

		// Token: 0x06000245 RID: 581 RVA: 0x000155B8 File Offset: 0x000137B8
		public override void SetDefaults()
		{
			base.item.damage = 24;
			base.item.melee = true;
			base.item.width = 34;
			base.item.height = 34;
			base.item.useTime = 15;
			base.item.useAnimation = 15;
			base.item.pick = 100;
			base.item.axe = 15;
			base.item.useStyle = 1;
			base.item.knockBack = 8f;
			base.item.value = Item.buyPrice(0, 1, 30, 0);
			base.item.value = Item.sellPrice(0, 1, 30, 0);
			base.item.rare = 5;
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
		}

		// Token: 0x06000246 RID: 582 RVA: 0x0001569C File Offset: 0x0001389C
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("VyssoniumBar"), 20);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
