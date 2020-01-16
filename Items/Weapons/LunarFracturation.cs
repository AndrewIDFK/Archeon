using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000A0 RID: 160
	public class LunarFracturation : ModItem
	{
		// Token: 0x060002D5 RID: 725 RVA: 0x00018891 File Offset: 0x00016A91
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Lunar Fracturation");
			base.Tooltip.SetDefault("The Sky has Evolved");
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x000188B4 File Offset: 0x00016AB4
		public override void SetDefaults()
		{
			base.item.damage = 135;
			base.item.crit = 20;
			base.item.magic = true;
			base.item.width = 24;
			base.item.height = 28;
			base.item.useTime = 14;
			base.item.useAnimation = 14;
			base.item.useStyle = 5;
			Item.staff[base.item.type] = true;
			base.item.noMelee = true;
			base.item.knockBack = 5f;
			base.item.value = Item.buyPrice(0, 13, 45, 0);
			base.item.value = Item.sellPrice(0, 13, 45, 0);
			base.item.rare = 9;
			base.item.mana = 8;
			base.item.UseSound = SoundID.Item21;
			base.item.autoReuse = true;
			base.item.shoot = base.mod.ProjectileType("LunarFracturationShot");
			base.item.shootSpeed = 28f;
			base.item.scale = 1.2f;
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x000189F4 File Offset: 0x00016BF4
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 8; i++)
			{
				float num = Utils.NextFloat(Main.rand) * 18.849556f;
				Vector2 vector = position + Utils.ToRotationVector2(num) * MathHelper.Lerp(60f, 90f, Utils.NextFloat(Main.rand));
				Vector2 value = Main.MouseWorld - vector;
				value.Normalize();
				Projectile.NewProjectile(vector, value * 15f, type, damage, knockBack, Main.myPlayer, 0f, 0f);
			}
			return false;
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x00018A94 File Offset: 0x00016C94
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("LunarFragment"), 24);
			modRecipe.AddIngredient(3787, 1);
			modRecipe.AddTile(412);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
