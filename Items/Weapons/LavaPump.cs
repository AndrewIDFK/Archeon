using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x0200009D RID: 157
	public class LavaPump : ModItem
	{
		// Token: 0x060002C7 RID: 711 RVA: 0x000184BC File Offset: 0x000166BC
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Lava Pumper");
			base.Tooltip.SetDefault("Transforms Musket Balls into Blazing Bullets\n10% chance to not consume ammo");
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x000184E0 File Offset: 0x000166E0
		public override void SetDefaults()
		{
			base.item.damage = 36;
			base.item.crit = 5;
			base.item.ranged = true;
			base.item.width = 16;
			base.item.height = 16;
			base.item.useTime = 38;
			base.item.useAnimation = 38;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 4f;
			base.item.value = Item.buyPrice(0, 1, 50, 0);
			base.item.value = Item.sellPrice(0, 1, 50, 0);
			base.item.rare = 6;
			base.item.UseSound = SoundID.Item38;
			base.item.autoReuse = true;
			base.item.shoot = 10;
			base.item.shootSpeed = 10f;
			base.item.useAmmo = AmmoID.Bullet;
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x000185F0 File Offset: 0x000167F0
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(534, 1);
			modRecipe.AddIngredient(175, 15);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		// Token: 0x060002CA RID: 714 RVA: 0x00018637 File Offset: 0x00016837
		public override bool ConsumeAmmo(Player player)
		{
			return Utils.NextFloat(Main.rand) >= 0.1f;
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0001864D File Offset: 0x0001684D
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(new Vector2(-4f, 1f));
		}

		// Token: 0x060002CC RID: 716 RVA: 0x00018664 File Offset: 0x00016864
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == 14)
			{
				type = base.mod.ProjectileType("BlazingBulletShot");
			}
			int num = 5;
			for (int i = 0; i < num; i++)
			{
				Vector2 value = Utils.RotatedByRandom(new Vector2(speedX, speedY), (double)MathHelper.ToRadians(16f));
				float scaleFactor = 1f - Utils.NextFloat(Main.rand) * 0.5f;
				value *= scaleFactor;
				Projectile.NewProjectile(position.X, position.Y, value.X, value.Y, type, damage, knockBack, player.whoAmI, 0f, 0f);
			}
			return false;
		}
	}
}
