using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000A1 RID: 161
	public class LunarKnives : ModItem
	{
		// Token: 0x060002DA RID: 730 RVA: 0x00018AF2 File Offset: 0x00016CF2
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Lunar Knives");
			base.Tooltip.SetDefault("Lunar power surges through the knives");
		}

		// Token: 0x060002DB RID: 731 RVA: 0x00018B14 File Offset: 0x00016D14
		public override void SetDefaults()
		{
			base.item.damage = 115;
			base.item.crit = 22;
			base.item.melee = true;
			base.item.width = 16;
			base.item.height = 16;
			base.item.useTime = 15;
			base.item.useAnimation = 15;
			base.item.useStyle = 1;
			base.item.noUseGraphic = true;
			base.item.noMelee = true;
			base.item.knockBack = 3.75f;
			base.item.value = Item.buyPrice(0, 16, 50, 0);
			base.item.value = Item.sellPrice(0, 16, 50, 0);
			base.item.rare = 10;
			base.item.UseSound = SoundID.Item71;
			base.item.autoReuse = true;
			base.item.shoot = base.mod.ProjectileType("LunarKnivesShot");
			base.item.shootSpeed = 76f;
		}

		// Token: 0x060002DC RID: 732 RVA: 0x00018C30 File Offset: 0x00016E30
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("LunarFragment"), 35);
			modRecipe.AddIngredient(base.mod.ItemType("EnchanterKnives"), 1);
			modRecipe.AddTile(412);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		// Token: 0x060002DD RID: 733 RVA: 0x00018C88 File Offset: 0x00016E88
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float num = (float)(5 + Main.rand.Next(9));
			float num2 = MathHelper.ToRadians(21f);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 23f;
			int num3 = 1;
			while ((float)num3 < num)
			{
				Vector2 vector = Utils.RotatedBy(new Vector2(speedX, speedY), (double)MathHelper.Lerp(-num2, num2, (float)num3 / (num - 1f)), default(Vector2)) * 0.2f;
				Projectile.NewProjectile(position.X, position.Y, vector.X + 3, vector.Y + 3, type, damage, knockBack, player.whoAmI, 0f, 0f);
				num3++;
			}
			return false;
		}
	}
}
