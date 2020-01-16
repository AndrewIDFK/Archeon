using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000A8 RID: 168
	public class PhoenixAnnihilator : ModItem
	{
		// Token: 0x060002FA RID: 762 RVA: 0x000199A6 File Offset: 0x00017BA6
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Phoenix Annihilator");
			base.Tooltip.SetDefault("Shoots 2 extra chlorophyte bullets when firing\n42% chance to not consume ammo");
		}

		// Token: 0x060002FB RID: 763 RVA: 0x000199C8 File Offset: 0x00017BC8
		public override void SetDefaults()
		{
			base.item.damage = 34;
			base.item.crit = 6;
			base.item.ranged = true;
			base.item.width = 16;
			base.item.height = 16;
			base.item.useTime = 15;
			base.item.useAnimation = 15;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 5f;
			base.item.value = Item.buyPrice(0, 2, 40, 0);
			base.item.value = Item.sellPrice(0, 2, 40, 0);
			base.item.rare = 7;
			base.item.UseSound = SoundID.Item41;
			base.item.autoReuse = true;
			base.item.shoot = 10;
			base.item.shootSpeed = 18f;
			base.item.useAmmo = AmmoID.Bullet;
		}

		// Token: 0x060002FC RID: 764 RVA: 0x00019AD8 File Offset: 0x00017CD8
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("RockSteeleBar"), 5);
			modRecipe.AddIngredient(base.mod.ItemType("PhoenixEliminator"), 1);
			modRecipe.AddIngredient(1006, 8);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		// Token: 0x060002FD RID: 765 RVA: 0x00019B44 File Offset: 0x00017D44
		public override bool ConsumeAmmo(Player player)
		{
			return Utils.NextFloat(Main.rand) >= 0.42f;
		}

		// Token: 0x060002FE RID: 766 RVA: 0x00019B5C File Offset: 0x00017D5C
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 207, damage - 2, knockBack, player.whoAmI, 0f, 0f);
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 207, damage - 3, knockBack, player.whoAmI, 0f, 0f);
			return true;
		}

		// Token: 0x060002FF RID: 767 RVA: 0x00019BCE File Offset: 0x00017DCE
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(new Vector2(-5f, 2f));
		}
	}
}
