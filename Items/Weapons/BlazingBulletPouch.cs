using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x0200008A RID: 138
	public class BlazingBulletPouch : ModItem
	{
		// Token: 0x0600026F RID: 623 RVA: 0x000164BC File Offset: 0x000146BC
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Blazing Bullet Pouch");
			base.Tooltip.SetDefault("Unlimited Blazing Bullets");
		}

		// Token: 0x06000270 RID: 624 RVA: 0x000164E0 File Offset: 0x000146E0
		public override void SetDefaults()
		{
			base.item.damage = 9;
			base.item.ranged = true;
			base.item.width = 8;
			base.item.height = 8;
			base.item.consumable = false;
			base.item.knockBack = 3f;
			base.item.value = Item.buyPrice(0, 4, 25, 0);
			base.item.value = Item.sellPrice(0, 4, 25, 0);
			base.item.rare = 5;
			base.item.shootSpeed = 14f;
			base.item.ammo = AmmoID.Bullet;
			base.item.shoot = base.mod.ProjectileType("BlazingBulletShot");
		}

		// Token: 0x06000271 RID: 625 RVA: 0x000165AB File Offset: 0x000147AB
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == 14)
			{
				type = base.mod.ProjectileType("BlazingBulletShot");
			}
			return true;
		}

		// Token: 0x06000272 RID: 626 RVA: 0x000165C8 File Offset: 0x000147C8
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(175, 25);
			modRecipe.AddIngredient(base.mod.ItemType("BlazingBullet"), 1400);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
