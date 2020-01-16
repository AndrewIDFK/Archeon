using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000B2 RID: 178
	public class RockSteeleYoyo : ModItem
	{
		// Token: 0x0600032C RID: 812 RVA: 0x0001AE95 File Offset: 0x00019095
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("RockSteele Yoyo");
			base.Tooltip.SetDefault("Somehow it doesnt feel heavy");
		}

		// Token: 0x0600032D RID: 813 RVA: 0x0001AEB8 File Offset: 0x000190B8
		public override void SetDefaults()
		{
			base.item.damage = 55;
			base.item.melee = true;
			base.item.useTime = 13;
			base.item.useAnimation = 35;
			base.item.useStyle = 5;
			base.item.channel = true;
			base.item.knockBack = 3f;
			base.item.value = Item.buyPrice(0, 3, 50, 0);
			base.item.value = Item.sellPrice(0, 3, 50, 0);
			base.item.rare = 4;
			base.item.autoReuse = true;
			base.item.shoot = base.mod.ProjectileType("RockSteeleYoyoShot");
			base.item.noUseGraphic = true;
			base.item.noMelee = true;
			base.item.UseSound = SoundID.Item1;
		}

		// Token: 0x0600032E RID: 814 RVA: 0x0001AFA8 File Offset: 0x000191A8
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(null, "RockSteeleBar", 12);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
