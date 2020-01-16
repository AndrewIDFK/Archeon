using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Tools
{
	// Token: 0x02000085 RID: 133
	public class ThaniteDrill : ModItem
	{
		// Token: 0x0600025C RID: 604 RVA: 0x00015E22 File Offset: 0x00014022
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Thanite Drill");
			base.Tooltip.SetDefault("Can be used to mine Plasmite");
		}

		// Token: 0x0600025D RID: 605 RVA: 0x00015E44 File Offset: 0x00014044
		public override void SetDefaults()
		{
			base.item.damage = 28;
			base.item.melee = true;
			base.item.width = 20;
			base.item.height = 12;
			base.item.useTime = 4;
			base.item.useAnimation = 20;
			base.item.channel = true;
			base.item.noUseGraphic = true;
			base.item.noMelee = true;
			base.item.pick = 210;
			base.item.tileBoost++;
			base.item.useStyle = 5;
			base.item.knockBack = 2f;
			base.item.value = Item.buyPrice(0, 4, 50, 0);
			base.item.value = Item.sellPrice(0, 4, 50, 0);
			base.item.rare = 5;
			base.item.UseSound = SoundID.Item23;
			base.item.autoReuse = true;
			base.item.shoot = base.mod.ProjectileType("ThaniteDrillShot");
			base.item.shootSpeed = 40f;
			base.item.useTurn = true;
		}

		// Token: 0x0600025E RID: 606 RVA: 0x00015F8C File Offset: 0x0001418C
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("ThaniteBar"), 18);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
