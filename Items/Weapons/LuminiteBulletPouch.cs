using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x0200009F RID: 159
	public class LuminiteBulletPouch : ModItem
	{
		// Token: 0x060002D0 RID: 720 RVA: 0x00018748 File Offset: 0x00016948
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Luminite Bullet Pouch");
			base.Tooltip.SetDefault("Unlimited Luminite Bullets");
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0001876C File Offset: 0x0001696C
		public override void SetDefaults()
		{
			base.item.damage = 20;
			base.item.ranged = true;
			base.item.width = 8;
			base.item.height = 8;
			base.item.consumable = false;
			base.item.knockBack = 3f;
			base.item.value = Item.buyPrice(0, 12, 0, 0);
			base.item.value = Item.sellPrice(0, 12, 0, 0);
			base.item.rare = 5;
			base.item.shootSpeed = 16f;
			base.item.ammo = AmmoID.Bullet;
			base.item.shoot = 638;
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0001882C File Offset: 0x00016A2C
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == 14)
			{
				type = 638;
			}
			return true;
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x00018840 File Offset: 0x00016A40
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(1006, 20);
			modRecipe.AddIngredient(3567, 3996);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
