using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000C0 RID: 192
	public class TheInfinity : ModItem
	{
		// Token: 0x06000376 RID: 886 RVA: 0x0001D0AB File Offset: 0x0001B2AB
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("The Infinity");
			base.Tooltip.SetDefault("Does not consume any ammo!\nJust like the one from the Stories that Marcus used to tell us!");
		}

		// Token: 0x06000377 RID: 887 RVA: 0x0001D0D0 File Offset: 0x0001B2D0
		public override void SetDefaults()
		{
			base.item.damage = 77;
			base.item.crit = 18;
			base.item.ranged = true;
			base.item.width = 16;
			base.item.height = 16;
			base.item.useTime = 8;
			base.item.useAnimation = 8;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 3f;
			base.item.value = Item.buyPrice(0, 5, 50, 0);
			base.item.value = Item.sellPrice(0, 5, 50, 0);
			base.item.rare = 7;
			base.item.UseSound = SoundID.Item41;
			base.item.autoReuse = true;
			base.item.shoot = 10;
			base.item.useAmmo = AmmoID.Bullet;
			base.item.shootSpeed = 18f;
		}

		// Token: 0x06000378 RID: 888 RVA: 0x0001D1DC File Offset: 0x0001B3DC
		public override bool ConsumeAmmo(Player player)
		{
			return Utils.NextFloat(Main.rand) >= 1f;
		}

		// Token: 0x06000379 RID: 889 RVA: 0x0001D1F4 File Offset: 0x0001B3F4
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("StroidBar"), 8);
			modRecipe.AddIngredient(1006, 12);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		// Token: 0x0600037A RID: 890 RVA: 0x0001D24C File Offset: 0x0001B44C
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 vector = Utils.RotatedByRandom(new Vector2(speedX * 2f, speedY * 2f), (double)MathHelper.ToRadians(5f));
			speedX = vector.X;
			speedY = vector.Y;
			return true;
		}

		// Token: 0x0600037B RID: 891 RVA: 0x0001D294 File Offset: 0x0001B494
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(new Vector2(-5f, 2f));
		}
	}
}
