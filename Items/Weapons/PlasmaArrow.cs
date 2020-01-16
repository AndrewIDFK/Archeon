using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000AB RID: 171
	public class PlasmaArrow : ModItem
	{
		// Token: 0x0600030B RID: 779 RVA: 0x00019F41 File Offset: 0x00018141
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Plasma Arrow");
			base.Tooltip.SetDefault("Arrows made out of pure energy");
		}

		// Token: 0x0600030C RID: 780 RVA: 0x00019F64 File Offset: 0x00018164
		public override void SetDefaults()
		{
			base.item.damage = 20;
			base.item.ranged = true;
			base.item.width = 8;
			base.item.height = 8;
			base.item.maxStack = 2000;
			base.item.consumable = true;
			base.item.knockBack = 1.6f;
			base.item.value = Item.buyPrice(0, 0, 25, 0);
			base.item.value = Item.sellPrice(0, 0, 25, 0);
			base.item.rare = 6;
			base.item.shoot = base.mod.ProjectileType("PlasmaArrowShot");
			base.item.shootSpeed = 3.5f;
			base.item.ammo = 40;
		}

		// Token: 0x0600030D RID: 781 RVA: 0x0001A03C File Offset: 0x0001823C
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("PlasmiteBar"), 1);
			modRecipe.AddIngredient(40, 75);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 75);
			modRecipe.AddRecipe();
		}
	}
}
