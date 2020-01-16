using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000B5 RID: 181
	public class Stormer : ModItem
	{
		// Token: 0x0600033B RID: 827 RVA: 0x0001B8F7 File Offset: 0x00019AF7
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Stormer");
			base.Tooltip.SetDefault("Once used by the Dungeoneer to defeat powerful foes");
		}

		// Token: 0x0600033C RID: 828 RVA: 0x0001B91C File Offset: 0x00019B1C
		public override void SetDefaults()
		{
			base.item.damage = 15;
			base.item.noMelee = true;
			base.item.ranged = true;
			base.item.width = 69;
			base.item.height = 40;
			base.item.useTime = 22;
			base.item.useAnimation = 22;
			base.item.useStyle = 5;
			base.item.shoot = AmmoID.Arrow;
			base.item.useAmmo = AmmoID.Arrow;
			base.item.knockBack = 1f;
			base.item.value = Item.buyPrice(0, 1, 60, 0);
			base.item.value = Item.sellPrice(0, 1, 60, 0);
			base.item.rare = 6;
			base.item.UseSound = SoundID.Item5;
			base.item.autoReuse = true;
			base.item.shootSpeed = 35f;
		}

		// Token: 0x0600033D RID: 829 RVA: 0x0001BA20 File Offset: 0x00019C20
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(new Vector2(2f, 1f));
		}

		// Token: 0x0600033E RID: 830 RVA: 0x0001BA38 File Offset: 0x00019C38
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 3; i++)
			{
				Vector2 vector = Utils.RotatedByRandom(new Vector2(speedX, speedY), (double)MathHelper.ToRadians(8f));
				Projectile.NewProjectile(position.X, position.Y, vector.X, vector.Y, type, damage, knockBack, player.whoAmI, 0f, 0f);
			}
			return false;
		}

		// Token: 0x0600033F RID: 831 RVA: 0x0001BAA8 File Offset: 0x00019CA8
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(155, 1);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(163, 1);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(157, 1);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(113, 1);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
