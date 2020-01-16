using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000B3 RID: 179
	public class StarFalcon : ModItem
	{
		// Token: 0x06000330 RID: 816 RVA: 0x0001AFF0 File Offset: 0x000191F0
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Star Falcon");
			base.Tooltip.SetDefault("May the Stars be your guide");
		}

		// Token: 0x06000331 RID: 817 RVA: 0x0001B014 File Offset: 0x00019214
		public override void SetDefaults()
		{
			base.item.damage = 50;
			base.item.melee = true;
			base.item.width = 30;
			base.item.height = 36;
			base.item.useTime = 22;
			base.item.useAnimation = 22;
			base.item.useStyle = 1;
			base.item.knockBack = 8f;
			base.item.value = Item.buyPrice(0, 5, 0, 0);
			base.item.value = Item.sellPrice(0, 5, 0, 0);
			base.item.rare = 7;
			base.item.shootSpeed = 14f;
			base.item.shoot = base.mod.ProjectileType("StarfuryStar");
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
		}

		// Token: 0x06000332 RID: 818 RVA: 0x0001B108 File Offset: 0x00019308
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int num = 1;
			for (int i = 0; i < num; i++)
			{
				Vector2 vector = new Vector2((float)((double)player.position.X + (double)player.width * 0.5 + (double)(Main.rand.Next(201) * -(double)player.direction) + ((double)Main.mouseX + (double)Main.screenPosition.X - (double)player.position.X)), (float)((double)player.position.Y + (double)player.height * 0.5 - 600.0));
				vector.X = (float)(((double)vector.X + (double)player.Center.X) / 2.0) + (float)Main.rand.Next(-200, 201);
				vector.Y -= (float)(100 * i);
				float num2 = (float)Main.mouseX + Main.screenPosition.X - vector.X;
				float num3 = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
				if ((double)num3 < 0.0)
				{
					num3 *= -1f;
				}
				if ((double)num3 < 20.0)
				{
					num3 = 20f;
				}
				float num4 = base.item.shootSpeed / num3;
				float num5 = num2 * num4;
				float num6 = num3 * num4;
				float num7 = num5 + (float)Main.rand.Next(-40, 41) * 0.02f;
				float num8 = num6 + (float)Main.rand.Next(-40, 41) * 0.02f;
				Projectile.NewProjectile(vector.X, vector.Y, num7, num8, type, damage, knockBack, Main.myPlayer, 0f, (float)Main.rand.Next(1));
			}
			Vector2 value = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + value, 0, 0))
			{
				position += value;
			}
			return false;
		}

		// Token: 0x06000333 RID: 819 RVA: 0x0001B338 File Offset: 0x00019538
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			int num = 1;
			for (int i = 0; i < num; i++)
			{
				Vector2 vector = new Vector2((float)((double)player.position.X + (double)player.width * 0.5 + (double)(Main.rand.Next(201) * -(double)player.direction) + ((double)Main.mouseX + (double)Main.screenPosition.X - (double)player.position.X)), (float)((double)player.position.Y + (double)player.height * 0.5 - 600.0));
				vector.X = (float)(((double)vector.X + (double)player.Center.X) / 2.0) + (float)Main.rand.Next(-200, 201);
				vector.Y -= (float)(100 * i);
				float num2 = (float)Main.mouseX + Main.screenPosition.X - vector.X;
				float num3 = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
				if ((double)num3 < 0.0)
				{
					num3 *= -1f;
				}
				if ((double)num3 < 20.0)
				{
					num3 = 20f;
				}
				float num4 = base.item.shootSpeed / num3;
				float num5 = num2 * num4;
				float num6 = num3 * num4;
				float num7 = num5 + (float)Main.rand.Next(-40, 41) * 0.02f;
				float num8 = num6 + (float)Main.rand.Next(-40, 41) * 0.02f;
				Projectile.NewProjectile(vector.X, vector.Y, num7, num8, base.mod.ProjectileType("StroidEmpalerStar"), 85, 6f, Main.myPlayer, 0f, (float)Main.rand.Next(2));
			}
		}

		// Token: 0x06000334 RID: 820 RVA: 0x0001B52C File Offset: 0x0001972C
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(65, 1);
			modRecipe.AddRecipeGroup("TiorAdSword", 1);
			modRecipe.AddIngredient(528, 2);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
