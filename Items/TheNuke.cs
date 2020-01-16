using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items
{
	// Token: 0x0200003E RID: 62
	public class TheNuke : ModItem
	{
		// Token: 0x060000FC RID: 252 RVA: 0x000075CE File Offset: 0x000057CE
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("The Nuke");
			base.Tooltip.SetDefault("Use at your own risk... Seriously!");
		}

		// Token: 0x060000FD RID: 253 RVA: 0x000075F0 File Offset: 0x000057F0
		public override void SetDefaults()
		{
			base.item.damage = 0;
			base.item.width = 10;
			base.item.height = 32;
			base.item.maxStack = 1;
			base.item.consumable = true;
			base.item.useStyle = 1;
			base.item.rare = 9;
			base.item.UseSound = SoundID.Item1;
			base.item.useAnimation = 50;
			base.item.useTime = 50;
			base.item.value = Item.buyPrice(0, 2, 50, 0);
			base.item.value = Item.sellPrice(0, 2, 50, 0);
			base.item.noUseGraphic = true;
			base.item.noMelee = true;
			base.item.shoot = base.mod.ProjectileType("TheNukeExplosion");
			base.item.shootSpeed = 9f;
		}

		// Token: 0x060000FE RID: 254 RVA: 0x000076EC File Offset: 0x000058EC
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(167, 60);
			modRecipe.AddIngredient(null, "VyssoniumBar", 10);
			modRecipe.AddIngredient(null, "ShadoniumBar", 10);
			modRecipe.AddIngredient(null, "RockSteeleBar", 10);
			modRecipe.AddIngredient(null, "ThaniteBar", 10);
			modRecipe.AddIngredient(null, "StroidBar", 10);
			modRecipe.AddIngredient(null, "PlasmiteBar", 10);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
