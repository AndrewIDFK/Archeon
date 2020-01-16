using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000BD RID: 189
	public class Terruption : ModItem
	{
		// Token: 0x06000365 RID: 869 RVA: 0x0001C9E5 File Offset: 0x0001ABE5
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Terruption");
			base.Tooltip.SetDefault("It wants to erupt the world!");
		}

		// Token: 0x06000366 RID: 870 RVA: 0x0001CA08 File Offset: 0x0001AC08
		public override void SetDefaults()
		{
			base.item.damage = 104;
			base.item.melee = true;
			base.item.width = 40;
			base.item.height = 40;
			base.item.crit = 2;
			base.item.useTime = 16;
			base.item.useAnimation = 16;
			base.item.useStyle = 1;
			base.item.knockBack = 8f;
			base.item.value = Item.buyPrice(0, 14, 0, 0);
			base.item.value = Item.sellPrice(0, 14, 0, 0);
			base.item.rare = 7;
			base.item.shoot = base.mod.ProjectileType("TerruptionShot");
			base.item.shootSpeed = 16f;
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
			base.item.useTurn = true;
			item.scale = 1.1f;
		}

		// Token: 0x06000367 RID: 871 RVA: 0x0001CB14 File Offset: 0x0001AD14
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(757, 1);
			modRecipe.AddIngredient(base.mod.ItemType("FeralShard"), 18);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		// Token: 0x06000368 RID: 872 RVA: 0x0001CB6C File Offset: 0x0001AD6C
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 1; i++)
			{
				Vector2 vector = Utils.RotatedByRandom(new Vector2(speedX, speedY), (double)MathHelper.ToRadians(1f));
				Projectile.NewProjectile(position.X, position.Y, vector.X, vector.Y, type, damage, knockBack, player.whoAmI, 0f, 0f);
			}
			return false;
		}
	}
}
