using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x02000087 RID: 135
	public class BlackLight : ModItem
	{
		// Token: 0x06000264 RID: 612 RVA: 0x00016136 File Offset: 0x00014336
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Black Light");
			base.Tooltip.SetDefault("Shoots an unstoppable Black Light");
		}

		// Token: 0x06000265 RID: 613 RVA: 0x00016158 File Offset: 0x00014358
		public override void SetDefaults()
		{
			base.item.damage = 60;
			base.item.magic = true;
			base.item.width = 24;
			base.item.height = 28;
			base.item.useTime = 30;
			base.item.useAnimation = 30;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 2f;
			base.item.value = Item.buyPrice(0, 1, 10, 0);
			base.item.value = Item.sellPrice(0, 1, 10, 0);
			base.item.rare = 6;
			base.item.mana = 15;
			base.item.UseSound = SoundID.Item21;
			base.item.autoReuse = true;
			base.item.shoot = base.mod.ProjectileType("BlackLightShot");
			base.item.shootSpeed = 12f;
		}

		// Token: 0x06000266 RID: 614 RVA: 0x00016264 File Offset: 0x00014464
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("ShadoniumBar"), 12);
			modRecipe.AddIngredient(531, 1);
			modRecipe.AddIngredient(173, 6);
			modRecipe.AddTile(101);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("VyssoniumBar"), 12);
			modRecipe.AddIngredient(531, 1);
			modRecipe.AddIngredient(173, 6);
			modRecipe.AddTile(101);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
