using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Ranged.PreHM
{
	public class Stormer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stormer");
			Tooltip.SetDefault("Once used by the Dungeoneer to explore ancient structures");
		}
		
		public override void SetDefaults()
		{
			item.damage = 16;
			item.noMelee = true;
			item.ranged = true;
			item.width = 69;
			item.height = 40;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = 5;
			item.shoot = AmmoID.Arrow;
			item.useAmmo = AmmoID.Arrow;
			item.knockBack = 1f;
			item.value = Item.buyPrice(0, 1, 60, 0);
			item.rare = 4;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shootSpeed = 12f;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(new Vector2(2f, 1f));
		}
		
		
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if(Main.rand.Next(3) == 0)
			{
				for (int i = 0; i < 3; i++)
				{
					Vector2 vector = Utils.RotatedByRandom(new Vector2(speedX, speedY), (double)MathHelper.ToRadians(8f));
					Projectile.NewProjectile(position.X, position.Y, vector.X / 3 * 2, vector.Y / 3 * 2, type, damage, knockBack, player.whoAmI, 0f, 0f);
				}
			}
			else
			{
				for (int i = 0; i < 2; i++)
				{
					Vector2 vector = Utils.RotatedByRandom(new Vector2(speedX, speedY), (double)MathHelper.ToRadians(6.5f));
					Projectile.NewProjectile(position.X, position.Y, vector.X / 3 * 2, vector.Y / 3 * 2, type, damage, knockBack, player.whoAmI, 0f, 0f);
				}
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(155, 1);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(163, 1);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(157, 1);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(113, 1);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
