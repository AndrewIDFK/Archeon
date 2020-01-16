using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	public class RainCharge : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Rain Charge");
			base.Tooltip.SetDefault("Shoots projectiles from above and below");
		}

		public override void SetDefaults()
		{
			base.item.damage = 63;
			base.item.magic = true;
			base.item.width = 24;
			base.item.height = 28;
			base.item.useTime = 11;
			base.item.useAnimation = 11;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 1.9f;
			base.item.value = Item.buyPrice(0, 12, 80, 0);
			base.item.value = Item.sellPrice(0, 12, 80, 0);
			base.item.rare = 9;
			base.item.mana = 12;
			base.item.UseSound = SoundID.Item21;
			base.item.autoReuse = true;
			base.item.shoot = base.mod.ProjectileType("RainChargeShot");
			base.item.shootSpeed = 22f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float shootSpeed = base.item.shootSpeed;
			Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
			float num = (float)Main.mouseX + Main.screenPosition.X - vector.X;
			float num2 = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
			if (player.gravDir == -1f)
			{
				num2 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector.Y;
			}
			float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
			if ((!float.IsNaN(num) || !float.IsNaN(num2)) && (num != 0f || num2 != 0f))
			{
				num3 = shootSpeed / num3;
			}
			else
			{
				num = (float)player.direction;
			}
			int num4 = Main.rand.Next(5, 6);
			for (int i = 0; i < num4; i++)
			{
				vector = new Vector2(player.position.X + (float)player.width * 0.5f + (float)Main.rand.Next(111) * (0f - (float)player.direction) + ((float)Main.mouseX + Main.screenPosition.X - player.position.X), player.MountedCenter.Y - 600f);
				vector.X = (vector.X + player.Center.X) / 2f + (float)Main.rand.Next(-110, 111);
				vector.Y -= (float)(100 * i);
				num = (float)Main.mouseX + Main.screenPosition.X - vector.X;
				num2 = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
				if (num2 < 0f)
				{
					num2 *= -1f;
				}
				if (num2 < 20f)
				{
					num2 = 20f;
				}
				num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
				num3 = shootSpeed / num3;
				num *= num3;
				num2 *= num3;
				float num5 = num + (float)Main.rand.Next(-30, 31) * 0.02f;
				float num6 = num2 + (float)Main.rand.Next(-30, 31) * 0.02f;
				int num7 = Projectile.NewProjectile(vector.X, vector.Y, num5, num6, type, damage, knockBack, player.whoAmI, 0f, 0f);
				Main.projectile[num7].extraUpdates++;
				Main.projectile[num7].tileCollide = false;
				
				
				vector = new Vector2(player.position.X + (float)player.width * 0.5f + (float)Main.rand.Next(121) * (0f - (float)player.direction) + ((float)Main.mouseX + Main.screenPosition.X - player.position.X), player.MountedCenter.Y + 600f);
				vector.X = (vector.X + player.Center.X) / 2f + (float)Main.rand.Next(-120, 121);
				vector.Y += (float)(100 * i);
				num = (float)Main.mouseX + Main.screenPosition.X - vector.X;
				num2 = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
				if (num2 < 0f)
				{
					num2 *= -1f;
				}
				if (num2 < 20f)
				{
					num2 = 20f;
				}
				num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
				num3 = shootSpeed / num3;
				num *= num3;
				num2 *= num3;
				float num8 = num + (float)Main.rand.Next(-30, 31) * 0.02f;
				float num9 = num2 + (float)Main.rand.Next(-30, 31) * 0.02f;
				int num10 = Projectile.NewProjectile(vector.X, vector.Y, num8, 0f - num9, type, damage, knockBack, player.whoAmI, 0f, 0f);
				Main.projectile[num10].extraUpdates++;
				Main.projectile[num10].tileCollide = false;
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("LunarFragment"), 25);
			modRecipe.AddIngredient(base.mod.ItemType("UpperCharge"), 1);
			modRecipe.AddIngredient(3467, 5);
			modRecipe.AddTile(412);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
