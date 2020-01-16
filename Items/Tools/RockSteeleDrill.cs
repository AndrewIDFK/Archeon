using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Tools
{
	// Token: 0x02000082 RID: 130
	public class RockSteeleDrill : ModItem
	{
		// Token: 0x06000250 RID: 592 RVA: 0x000159A8 File Offset: 0x00013BA8
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("RockSteele Drill");
			base.Tooltip.SetDefault("Can be used to mine Thanite");
		}

		// Token: 0x06000251 RID: 593 RVA: 0x000159CC File Offset: 0x00013BCC
		public override void SetDefaults()
		{
			base.item.damage = 22;
			base.item.melee = true;
			base.item.width = 20;
			base.item.height = 12;
			base.item.useTime = 6;
			base.item.useAnimation = 20;
			base.item.channel = true;
			base.item.noUseGraphic = true;
			base.item.noMelee = true;
			base.item.pick = 200;
			base.item.tileBoost++;
			base.item.useStyle = 5;
			base.item.knockBack = 2f;
			base.item.value = Item.buyPrice(0, 3, 50, 0);
			base.item.value = Item.sellPrice(0, 3, 50, 0);
			base.item.rare = 5;
			base.item.UseSound = SoundID.Item23;
			base.item.autoReuse = true;
			base.item.shoot = base.mod.ProjectileType("RockSteeleDrillShot");
			base.item.shootSpeed = 40f;
			base.item.useTurn = true;
		}

		// Token: 0x06000252 RID: 594 RVA: 0x00015B14 File Offset: 0x00013D14
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("RockSteeleBar"), 20);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
