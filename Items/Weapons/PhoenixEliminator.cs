using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000A9 RID: 169
	public class PhoenixEliminator : ModItem
	{
		// Token: 0x06000301 RID: 769 RVA: 0x00019BEC File Offset: 0x00017DEC
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Phoenix Eliminator");
			base.Tooltip.SetDefault("Shoots an extra RockSteele bullet when firing\n32% chance to not consume ammo");
		}

		// Token: 0x06000302 RID: 770 RVA: 0x00019C10 File Offset: 0x00017E10
		public override void SetDefaults()
		{
			base.item.damage = 30;
			base.item.crit = 4;
			base.item.ranged = true;
			base.item.width = 16;
			base.item.height = 16;
			base.item.useTime = 14;
			base.item.useAnimation = 14;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 4f;
			base.item.value = Item.buyPrice(0, 1, 20, 0);
			base.item.value = Item.sellPrice(0, 1, 20, 0);
			base.item.rare = 6;
			base.item.UseSound = SoundID.Item41;
			base.item.autoReuse = true;
			base.item.shoot = 10;
			base.item.shootSpeed = 15f;
			base.item.useAmmo = AmmoID.Bullet;
		}

		// Token: 0x06000303 RID: 771 RVA: 0x00019D20 File Offset: 0x00017F20
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("RockSteeleBar"), 8);
			modRecipe.AddIngredient(219, 1);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		// Token: 0x06000304 RID: 772 RVA: 0x00019D75 File Offset: 0x00017F75
		public override bool ConsumeAmmo(Player player)
		{
			return Utils.NextFloat(Main.rand) >= 0.32f;
		}

		// Token: 0x06000305 RID: 773 RVA: 0x00019D8C File Offset: 0x00017F8C
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, base.mod.ProjectileType("RockSteeleBulletShot"), damage + 1, knockBack, player.whoAmI, 0f, 0f);
			return true;
		}

		// Token: 0x06000306 RID: 774 RVA: 0x00019DD7 File Offset: 0x00017FD7
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(new Vector2(-5f, 2f));
		}
	}
}
