using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Tools
{
	// Token: 0x02000081 RID: 129
	public class RockSteeleAxe : ModItem
	{
		// Token: 0x0600024C RID: 588 RVA: 0x00015843 File Offset: 0x00013A43
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("RockSteele Axe");
			base.Tooltip.SetDefault("Able to chop down the thickest of trees!");
		}

		// Token: 0x0600024D RID: 589 RVA: 0x00015868 File Offset: 0x00013A68
		public override void SetDefaults()
		{
			base.item.damage = 32;
			base.item.melee = true;
			base.item.width = 38;
			base.item.height = 38;
			base.item.useTime = 15;
			base.item.useAnimation = 18;
			base.item.axe = 26;
			base.item.useStyle = 1;
			base.item.knockBack = 8f;
			base.item.value = Item.buyPrice(0, 1, 0, 0);
			base.item.value = Item.sellPrice(0, 1, 0, 0);
			base.item.rare = 5;
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
			base.item.useTurn = true;
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0001594C File Offset: 0x00013B4C
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
