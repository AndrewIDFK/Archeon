using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000AE RID: 174
	public class PlasmiteYoyo : ModItem
	{
		// Token: 0x06000319 RID: 793 RVA: 0x0001A44D File Offset: 0x0001864D
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Plasmite Yoyo");
			base.Tooltip.SetDefault("A yoyo made from pure Energy");
		}

		// Token: 0x0600031A RID: 794 RVA: 0x0001A470 File Offset: 0x00018670
		public override void SetDefaults()
		{
			base.item.damage = 95;
			base.item.melee = true;
			base.item.useTime = 12;
			base.item.useAnimation = 40;
			base.item.useStyle = 5;
			base.item.channel = true;
			base.item.knockBack = 2.1f;
			base.item.value = Item.buyPrice(0, 5, 60, 0);
			base.item.value = Item.sellPrice(0, 5, 60, 0);
			base.item.rare = 5;
			base.item.autoReuse = true;
			base.item.shoot = base.mod.ProjectileType("PlasmiteYoyoShot");
			base.item.noUseGraphic = true;
			base.item.noMelee = true;
			base.item.UseSound = SoundID.Item1;
		}

		// Token: 0x0600031B RID: 795 RVA: 0x0001A560 File Offset: 0x00018760
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(null, "PlasmiteBar", 13);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
