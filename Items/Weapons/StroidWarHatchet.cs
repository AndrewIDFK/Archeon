using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000B9 RID: 185
	public class StroidWarHatchet : ModItem
	{
		// Token: 0x06000354 RID: 852 RVA: 0x0001C1FE File Offset: 0x0001A3FE
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Stroid WarHatchet");
			base.Tooltip.SetDefault("Explodes when it touches an enemy");
		}

		// Token: 0x06000355 RID: 853 RVA: 0x0001C220 File Offset: 0x0001A420
		public override void SetDefaults()
		{
			base.item.damage = 125;
			base.item.melee = true;
			base.item.width = 30;
			base.item.height = 30;
			base.item.useTime = 12;
			base.item.useAnimation = 12;
			base.item.noUseGraphic = true;
			base.item.useStyle = 1;
			base.item.knockBack = 6f;
			base.item.value = Item.buyPrice(0, 6, 0, 0);
			base.item.value = Item.sellPrice(0, 6, 0, 0);
			base.item.rare = 8;
			base.item.shootSpeed = 10f;
			base.item.shoot = base.mod.ProjectileType("StroidWarHatchetShot");
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
			base.item.useTurn = true;
		}

		// Token: 0x06000356 RID: 854 RVA: 0x0001C32C File Offset: 0x0001A52C
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("StroidBar"), 17);
			modRecipe.AddIngredient(1122, 1);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
