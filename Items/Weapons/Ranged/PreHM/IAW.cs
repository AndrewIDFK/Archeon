using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Ranged.PreHM
{
	public class IAW : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The IAW");
			Tooltip.SetDefault("You get flashbacks to the time when you used to kill terrorists \nConverts Musket Balls into High Velocity Bullets");
		}

		public override void SetDefaults()
		{
			item.damage = 70;
			item.crit = 46;
			item.ranged = true;
			item.width = 16;
			item.height = 16;
			item.useTime = 45;
			item.useAnimation = 45;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 14f;
			item.value = Item.buyPrice(0, 1, 10, 0);
			item.rare = 5;
			item.UseSound = SoundID.Item38;
			item.autoReuse = false;
			item.shoot = 10;
			item.shootSpeed = 26f;
			item.useAmmo = AmmoID.Bullet;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == 14)
			{
				type = 242;
			}
			Vector2 value = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + value, 0, 0))
			{
				position += value;
			}
			Projectile.NewProjectile(position.X, position.Y, speedX * 1.2f, speedY * 1.2f, type, damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("VyssoniumBar"), 18);
			modRecipe.AddIngredient(800, 1);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("ShadoniumBar"), 18);
			modRecipe.AddIngredient(96, 1);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(new Vector2(-17f, -2f));
		}
	}
}
