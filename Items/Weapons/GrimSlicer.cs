using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x0200009A RID: 154
	public class GrimSlicer : ModItem
	{
		// Token: 0x060002BB RID: 699 RVA: 0x0001810D File Offset: 0x0001630D
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Grim Slicer");
		}

		// Token: 0x060002BC RID: 700 RVA: 0x00018120 File Offset: 0x00016320
		public override void SetDefaults()
		{
			base.item.damage = 25;
			base.item.melee = true;
			base.item.width = 30;
			base.item.height = 30;
			base.item.useTime = 18;
			base.item.useAnimation = 18;
			base.item.noUseGraphic = true;
			base.item.useStyle = 1;
			base.item.knockBack = 6f;
			base.item.value = Item.buyPrice(0, 1, 0, 0);
			base.item.value = Item.sellPrice(0, 1, 0, 0);
			base.item.rare = 4;
			base.item.shootSpeed = 10f;
			base.item.shoot = base.mod.ProjectileType("GrimSlicerShot");
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
			base.item.useTurn = true;
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0001822C File Offset: 0x0001642C
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("VyssoniumBar"), 12);
			modRecipe.AddIngredient(836, 10);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
