using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.HalloweenWeps
{
	
	public class JackOBOOM : ModItem
	{
		// Token: 0x06000301 RID: 769 RVA: 0x00019BEC File Offset: 0x00017DEC
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Jack O' BOOM");
			base.Tooltip.SetDefault("Fires an explosive beam of Jack O' Flame");
		}

		// Token: 0x06000302 RID: 770 RVA: 0x00019C10 File Offset: 0x00017E10
		public override void SetDefaults()
		{
			base.item.damage = 50;
			base.item.crit = 6;
			base.item.ranged = true;
			base.item.width = 16;
			base.item.height = 16;
			base.item.useTime = 16;
			base.item.useAnimation = 16;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 2f;
			base.item.value = Item.buyPrice(0, 7, 80, 0);
			base.item.value = Item.sellPrice(0, 7, 80, 0);
			base.item.rare = 8;
			base.item.UseSound = SoundID.Item41;
			base.item.autoReuse = true;
			base.item.shoot = base.mod.ProjectileType("BOOMBEAM");
			base.item.shootSpeed = 15f;
			base.item.useAmmo = 97;
		}

		// Token: 0x06000303 RID: 771 RVA: 0x00019D20 File Offset: 0x00017F20
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("FireElement"), 10);
			modRecipe.AddIngredient(1725, 45);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

	

		// Token: 0x06000305 RID: 773 RVA: 0x00019D8C File Offset: 0x00017F8C
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, base.mod.ProjectileType("BOOMBEAM"), damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}

		// Token: 0x06000306 RID: 774 RVA: 0x00019DD7 File Offset: 0x00017FD7
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(new Vector2(-16f, -4f));
		}
	}
}
