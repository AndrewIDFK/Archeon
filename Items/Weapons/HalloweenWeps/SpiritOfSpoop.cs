using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Archeon.Items.Weapons.HalloweenWeps
{

	public class SpiritOfSpoop : ModItem
	{

		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Spirit's Tome");
			base.Tooltip.SetDefault("Unleash the spirits that spoop in the night!");
		}

		public override void SetDefaults()
		{
			base.item.damage = 69;
			base.item.magic = true;
			base.item.width = 24;
			base.item.height = 28;
			//base.item.useTime = 11;
			//base.item.useAnimation = 22;
			item.useAnimation = 27;
			item.useTime = 9;
			item.reuseDelay = 31;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 2f;
			base.item.value = Item.buyPrice(0, 3, 50, 0);
			base.item.value = Item.sellPrice(0, 3, 50, 0);
			base.item.rare = 6;
			base.item.mana = 20;
			base.item.autoReuse = true;
			base.item.shoot = base.mod.ProjectileType("SpiritOfProj1");
			base.item.shootSpeed = 14f;
			base.item.UseSound = SoundID.Item84;
		}
		

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(531, 1); //Spell Tome
			modRecipe.AddIngredient(3261, 22);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}


		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 1; // 4 or 5 shots
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 value = Utils.RotatedByRandom(new Vector2(speedX, speedY), (double)MathHelper.ToRadians(11f));
				float scaleFactor = 1f - Utils.NextFloat(Main.rand) * 0.3f;
				value *= scaleFactor;
				if (Collision.CanHit(position, 0, 0, position + value, 0, 0))
				{
					position += value;
				}
				
				
				if (Utils.NextBool(Main.rand, 2))
				{
					Projectile.NewProjectile(position.X, position.Y, value.X * 0.97f, value.Y * 0.97f, type, damage, knockBack, player.whoAmI, 0f, 0f);

				}
				else
				{
					Projectile.NewProjectile(position.X, position.Y, value.X * 1.04f, value.Y * 1.04f, base.mod.ProjectileType("SpiritOfProj2"), damage, knockBack, player.whoAmI, 0f, 0f);
				}
			}
			return false; // return false because we don't want tmodloader to shoot projectile
		}

		/*public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("StarFusedBar"), 15);
			modRecipe.AddIngredient(531); // Spell Tome
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}*/ // IDK WHAT THE RECIPE SHOULD BE! MAYBE NEW CRAFTING MATERIAL FOR IT LIKE THE ELDRITCH ESSENCE OR WHAT

	}
}
