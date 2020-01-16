using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000B1 RID: 177
	public class RockSteeleBulletPouch : ModItem
	{
		// Token: 0x06000327 RID: 807 RVA: 0x0001AD1B File Offset: 0x00018F1B
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("RockSteele Bullet Pouch");
			base.Tooltip.SetDefault("Unlimited RockSteele Bullets");
		}

		// Token: 0x06000328 RID: 808 RVA: 0x0001AD40 File Offset: 0x00018F40
		public override void SetDefaults()
		{
			base.item.damage = 10;
			base.item.ranged = true;
			base.item.width = 8;
			base.item.height = 8;
			base.item.consumable = false;
			base.item.knockBack = 3f;
			base.item.value = Item.buyPrice(0, 8, 50, 0);
			base.item.value = Item.sellPrice(0, 8, 50, 0);
			base.item.rare = 5;
			base.item.shootSpeed = 14f;
			base.item.ammo = AmmoID.Bullet;
			base.item.shoot = base.mod.ProjectileType("RockSteeleBulletShot");
		}

		// Token: 0x06000329 RID: 809 RVA: 0x0001AE0B File Offset: 0x0001900B
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == 14)
			{
				type = base.mod.ProjectileType("RockSteeleBulletShot");
			}
			return true;
		}

		// Token: 0x0600032A RID: 810 RVA: 0x0001AE28 File Offset: 0x00019028
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("RockSteeleBar"), 25);
			modRecipe.AddIngredient(base.mod.ItemType("RockSteeleBullet"), 1400);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
