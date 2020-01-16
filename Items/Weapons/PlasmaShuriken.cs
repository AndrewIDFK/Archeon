using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000AD RID: 173
	public class PlasmaShuriken : ModItem
	{
		// Token: 0x06000315 RID: 789 RVA: 0x0001A2CA File Offset: 0x000184CA
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Plasma Shuriken");
			base.Tooltip.SetDefault("So sharp that it's painful to look at");
		}

		// Token: 0x06000316 RID: 790 RVA: 0x0001A2EC File Offset: 0x000184EC
		public override void SetDefaults()
		{
			base.item.damage = 75;
			base.item.thrown = true;
			base.item.maxStack = 3000;
			base.item.consumable = true;
			base.item.knockBack = 0.3f;
			base.item.value = Item.buyPrice(0, 0, 30, 0);
			base.item.value = Item.sellPrice(0, 0, 30, 0);
			base.item.rare = 6;
			base.item.shoot = base.mod.ProjectileType("PlasmaShurikenShot");
			base.item.shootSpeed = 17.5f;
			base.item.useStyle = 1;
			base.item.useTime = 12;
			base.item.useAnimation = 12;
			base.item.autoReuse = true;
			base.item.useTurn = true;
			base.item.noMelee = true;
			base.item.noUseGraphic = true;
		}

		// Token: 0x06000317 RID: 791 RVA: 0x0001A3F8 File Offset: 0x000185F8
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("PlasmiteBar"), 3);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 200);
			modRecipe.AddRecipe();
		}
	}
}
