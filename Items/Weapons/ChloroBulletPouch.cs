using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x0200008D RID: 141
	public class ChloroBulletPouch : ModItem
	{
		// Token: 0x0600027D RID: 637 RVA: 0x0001687C File Offset: 0x00014A7C
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Chlorophyte Bullet Pouch");
			base.Tooltip.SetDefault("Unlimited Chlorophyte Bullets");
		}

		// Token: 0x0600027E RID: 638 RVA: 0x000168A0 File Offset: 0x00014AA0
		public override void SetDefaults()
		{
			base.item.damage = 10;
			base.item.ranged = true;
			base.item.width = 8;
			base.item.height = 8;
			base.item.consumable = false;
			base.item.knockBack = 3f;
			base.item.value = Item.buyPrice(0, 8, 75, 0);
			base.item.value = Item.sellPrice(0, 8, 75, 0);
			base.item.rare = 5;
			base.item.shootSpeed = 16f;
			base.item.ammo = AmmoID.Bullet;
			base.item.shoot = 207;
		}

		// Token: 0x0600027F RID: 639 RVA: 0x00016960 File Offset: 0x00014B60
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == 14)
			{
				type = 207;
			}
			return true;
		}

		// Token: 0x06000280 RID: 640 RVA: 0x00016974 File Offset: 0x00014B74
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(1006, 25);
			modRecipe.AddIngredient(1179, 1400);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
