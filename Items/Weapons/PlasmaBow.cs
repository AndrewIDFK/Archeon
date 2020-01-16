using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000AC RID: 172
	public class PlasmaBow : ModItem
	{
		// Token: 0x0600030F RID: 783 RVA: 0x0001A098 File Offset: 0x00018298
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Plasma Bow");
			base.Tooltip.SetDefault("Shoot 2 plasma infused Arrows");
		}

		// Token: 0x06000310 RID: 784 RVA: 0x0001A0BC File Offset: 0x000182BC
		public override void SetDefaults()
		{
			base.item.damage = 87;
			base.item.noMelee = true;
			base.item.ranged = true;
			base.item.width = 69;
			base.item.height = 40;
			base.item.useTime = 16;
			base.item.useAnimation = 16;
			base.item.useStyle = 5;
			base.item.shoot = base.mod.ProjectileType("PlasmaArrowShot");
			base.item.useAmmo = AmmoID.Arrow;
			base.item.knockBack = 1f;
			base.item.value = Item.buyPrice(0, 6, 75, 0);
			base.item.value = Item.sellPrice(0, 6, 75, 0);
			base.item.rare = 8;
			base.item.UseSound = SoundID.Item5;
			base.item.autoReuse = true;
			base.item.shootSpeed = 18f;
		}

		// Token: 0x06000311 RID: 785 RVA: 0x0001A1CB File Offset: 0x000183CB
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(new Vector2(2f, 1f));
		}

		// Token: 0x06000312 RID: 786 RVA: 0x0001A1E4 File Offset: 0x000183E4
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 2; i++)
			{
				Vector2 vector = Utils.RotatedByRandom(new Vector2(speedX, speedY), (double)MathHelper.ToRadians(9f));
				Projectile.NewProjectile(position.X, position.Y, vector.X, vector.Y, base.mod.ProjectileType("PlasmaArrowShot"), damage, knockBack, player.whoAmI, 0f, 0f);
			}
			return false;
		}

		// Token: 0x06000313 RID: 787 RVA: 0x0001A254 File Offset: 0x00018454
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("PlasmiteBar"), 14);
			modRecipe.AddIngredient(base.mod.ItemType("ThaniteBow"));
			modRecipe.AddIngredient(521, 10);
			modRecipe.AddIngredient(520, 10);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
