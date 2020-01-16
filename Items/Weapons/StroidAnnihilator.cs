using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000B6 RID: 182
	public class StroidAnnihilator : ModItem
	{
		// Token: 0x06000341 RID: 833 RVA: 0x0001BB72 File Offset: 0x00019D72
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Stroid Annihilator");
			base.Tooltip.SetDefault("A sniper that is enchanced by the power of Stars\nExtremely high Critical hit chance!");
		}

		// Token: 0x06000342 RID: 834 RVA: 0x0001BB94 File Offset: 0x00019D94
		public override void SetDefaults()
		{
			base.item.damage = 100;
			base.item.crit = 70;
			base.item.ranged = true;
			base.item.width = 16;
			base.item.height = 16;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 15f;
			base.item.value = Item.buyPrice(0, 3, 10, 0);
			base.item.value = Item.sellPrice(0, 3, 10, 0);
			base.item.rare = 8;
			base.item.UseSound = SoundID.Item38;
			base.item.autoReuse = false;
			base.item.shoot = 10;
			base.item.shootSpeed = 66f;
			base.item.useAmmo = AmmoID.Bullet;
			base.item.useAnimation = 68;
			base.item.useTime = 24;
			base.item.reuseDelay = 24;
		}

		// Token: 0x06000343 RID: 835 RVA: 0x0001BCB4 File Offset: 0x00019EB4
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("StroidBar"), 16);
			modRecipe.AddIngredient(base.mod.ItemType("IAW"), 1);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		// Token: 0x06000344 RID: 836 RVA: 0x0001BD18 File Offset: 0x00019F18
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX * 3f, speedY * 3f, 638, damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}

		// Token: 0x06000345 RID: 837 RVA: 0x0001BD64 File Offset: 0x00019F64
		public override bool ConsumeAmmo(Player player)
		{
			return player.itemAnimation >= base.item.useAnimation - 2;
		}

		// Token: 0x06000346 RID: 838 RVA: 0x0001BD7E File Offset: 0x00019F7E
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(new Vector2(-5f, 2f));
		}
	}
}
