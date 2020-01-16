using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000BE RID: 190
	public class ThaniteBow : ModItem
	{
		// Token: 0x0600036A RID: 874 RVA: 0x0001CBE2 File Offset: 0x0001ADE2
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Thanite Bow");
			base.Tooltip.SetDefault("Shoots powerful arrows that create explosions on impact");
		}

		// Token: 0x0600036B RID: 875 RVA: 0x0001CC04 File Offset: 0x0001AE04
		public override void SetDefaults()
		{
			base.item.damage = 66;
			base.item.noMelee = true;
			base.item.ranged = true;
			base.item.width = 69;
			base.item.height = 40;
			base.item.useTime = 26;
			base.item.useAnimation = 26;
			base.item.useStyle = 5;
			base.item.shoot = AmmoID.Arrow;
			base.item.useAmmo = AmmoID.Arrow;
			base.item.knockBack = 1f;
			base.item.value = Item.buyPrice(0, 4, 0, 0);
			base.item.value = Item.sellPrice(0, 4, 0, 0);
			base.item.rare = 7;
			base.item.UseSound = SoundID.Item5;
			base.item.autoReuse = true;
			base.item.shootSpeed = 90f;
		}

		// Token: 0x0600036C RID: 876 RVA: 0x0001CD06 File Offset: 0x0001AF06
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(new Vector2(2f, 1f));
		}

		// Token: 0x0600036D RID: 877 RVA: 0x0001CD1C File Offset: 0x0001AF1C
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX * 5.5f, speedY * 5.5f, base.mod.ProjectileType("SuperPoweredArrowShot"), damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}

		/*public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("ThaniteBar"), 15);
			modRecipe.AddIngredient(548, 5);
			modRecipe.AddIngredient(549, 5);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}*/
	}
}
