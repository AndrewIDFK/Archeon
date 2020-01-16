using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000A6 RID: 166
	public class OnyxScythe : ModItem
	{
		// Token: 0x060002EF RID: 751 RVA: 0x0001930A File Offset: 0x0001750A
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Onyxycle");
			base.Tooltip.SetDefault("Projectiles hit enemies multiple times");
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x0001932C File Offset: 0x0001752C
		public override void SetDefaults()
		{
			base.item.damage = 64;
			base.item.melee = true;
			base.item.width = 54;
			base.item.height = 50;
			base.item.useTime = 19;
			base.item.useAnimation = 19;
			base.item.useStyle = 1;
			base.item.knockBack = 8f;
			base.item.shoot = base.mod.ProjectileType("OnyxSickle");
			base.item.shootSpeed = 12f;
			base.item.value = Item.buyPrice(0, 5, 0, 0);
			base.item.value = Item.sellPrice(0, 5, 0, 0);
			base.item.rare = 7;
			base.item.UseSound = SoundID.Item24;
			base.item.autoReuse = true;
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x00019430 File Offset: 0x00017630
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(1198, 12);
			modRecipe.AddIngredient(527, 1);
			modRecipe.AddIngredient(521, 8);
			modRecipe.AddIngredient(548, 10);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(391, 12);
			modRecipe.AddIngredient(527, 1);
			modRecipe.AddIngredient(521, 8);
			modRecipe.AddIngredient(548, 10);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
