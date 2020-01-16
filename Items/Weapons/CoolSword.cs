using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x0200008E RID: 142
	public class CoolSword : ModItem
	{
		// Token: 0x06000282 RID: 642 RVA: 0x000169CB File Offset: 0x00014BCB
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Lunar Reaver");
			base.Tooltip.SetDefault("Become one with Lunar itself!");
		}

		// Token: 0x06000283 RID: 643 RVA: 0x000169F0 File Offset: 0x00014BF0
		public override void SetDefaults()
		{
			base.item.damage = 160;
			base.item.melee = true;
			base.item.width = 60;
			base.item.height = 68;
			base.item.useTime = 15;
			base.item.useAnimation = 15;
			base.item.useStyle = 1;
			base.item.knockBack = 9f;
			base.item.value = Item.buyPrice(0, 28, 50, 0);
			base.item.value = Item.sellPrice(0, 28, 50, 0);
			base.item.rare = 10;
			base.item.shoot = base.mod.ProjectileType("CoolSwordShot");
			base.item.shootSpeed = 16f;
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
			base.item.useTurn = true;
			base.item.scale = 1.2f;
		}

		// Token: 0x06000284 RID: 644 RVA: 0x00016B08 File Offset: 0x00014D08
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("LunarFragment"), 40);
			modRecipe.AddIngredient(base.mod.ItemType("Terruption"), 1);
			modRecipe.AddIngredient(3018, 1);
			modRecipe.AddIngredient(3065, 1);
			modRecipe.AddIngredient(2880, 1);
			modRecipe.AddTile(412);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		// Token: 0x06000285 RID: 645 RVA: 0x00016B90 File Offset: 0x00014D90
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Utils.NextBool(Main.rand, 2))
			{
				Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, base.mod.DustType("LunarDust"), 0f, 0f, 0, default(Color), 1f);
				Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, base.mod.DustType("LunarDust"), 0f, 0f, 0, default(Color), 1f);
			}
		}

		// Token: 0x06000286 RID: 646 RVA: 0x00016C51 File Offset: 0x00014E51
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.immune[base.item.owner] = 0;
			target.AddBuff(base.mod.BuffType("LunarDebuff"), 360, false);
		}

		// Token: 0x06000287 RID: 647 RVA: 0x00016C84 File Offset: 0x00014E84
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int num = 4 + Main.rand.Next(2);
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
				if (Utils.NextBool(Main.rand, 2))
				{
					Projectile.NewProjectile(vector.X, vector.Y, num7 / 1.35f, num8 / 1.35f, base.mod.ProjectileType("CoolSwordStar"), damage / 4, knockBack, Main.myPlayer, 0f, (float)Main.rand.Next(1));
				}
				else
				{
					Projectile.NewProjectile(vector.X, vector.Y, num7 / 1.35f, num8 / 1.35f, base.mod.ProjectileType("CoolSwordStar2"), damage / 4, knockBack, Main.myPlayer, 0f, (float)Main.rand.Next(1));
				}
			}
			if (Utils.NextBool(Main.rand, 1))
			{
				Vector2 vector2 = Utils.RotatedByRandom(new Vector2(speedX, speedY), (double)MathHelper.ToRadians(1f));
				Projectile.NewProjectile(position.X, position.Y, vector2.X, vector2.Y, type, damage * 4, knockBack, player.whoAmI, 0f, 0f);
			}
			return false;
		}
	}
}
