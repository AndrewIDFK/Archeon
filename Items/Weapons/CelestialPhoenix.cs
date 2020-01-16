using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x0200008C RID: 140
	public class CelestialPhoenix : ModItem
	{
		// Token: 0x06000276 RID: 630 RVA: 0x0001665D File Offset: 0x0001485D
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Celestial Phoenix");
			base.Tooltip.SetDefault("Unleash the Lunar power upon your foes!\nShoots 2 extra Luminite bullets when firing\n44% chance to not consume ammo");
		}

		// Token: 0x06000277 RID: 631 RVA: 0x00016680 File Offset: 0x00014880
		public override void SetDefaults()
		{
			base.item.damage = 45;
			base.item.crit = 8;
			base.item.ranged = true;
			base.item.width = 16;
			base.item.height = 16;
			base.item.useTime = 13;
			base.item.useAnimation = 13;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 4f;
			base.item.value = Item.buyPrice(0, 3, 80, 0);
			base.item.value = Item.sellPrice(0, 3, 80, 0);
			base.item.rare = 8;
			base.item.UseSound = SoundID.Item41;
			base.item.autoReuse = true;
			base.item.shoot = 10;
			base.item.shootSpeed = 18f;
			base.item.useAmmo = AmmoID.Bullet;
		}

		// Token: 0x06000278 RID: 632 RVA: 0x00016774 File Offset: 0x00014974
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(3456, 12);
			modRecipe.AddIngredient(base.mod.ItemType("PhoenixAnnihilator"), 1);
			modRecipe.AddIngredient(1006, 5);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		// Token: 0x06000279 RID: 633 RVA: 0x000167D6 File Offset: 0x000149D6
		public override bool ConsumeAmmo(Player player)
		{
			return Utils.NextFloat(Main.rand) >= 0.44f;
		}

		// Token: 0x0600027A RID: 634 RVA: 0x000167EC File Offset: 0x000149EC
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 638, damage - 2, knockBack, player.whoAmI, 0f, 0f);
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 638, damage - 1, knockBack, player.whoAmI, 0f, 0f);
			return true;
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0001685E File Offset: 0x00014A5E
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(new Vector2(-5f, 2f));
		}
	}
}
