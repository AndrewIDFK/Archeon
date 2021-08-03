using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Magic.PreHM
{
	public class CursedBook : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Book");
			Tooltip.SetDefault("A spell-book written by a Salem witch");
		}

		public override void SetDefaults()
		{
			item.damage = 26;
			item.magic = true;
			item.width = 24;
			item.height = 28;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3.5f;
			item.value = Item.buyPrice(0, 1, 15, 0);
			item.rare = 3;
			item.mana = 7;
			item.UseSound = SoundID.Item21;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("CursedBookProj");
			item.shootSpeed = 8.5f;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 value = Vector2.Normalize(new Vector2(speedX, speedY)) * 8f;
			if (Collision.CanHit(position, 0, 0, position + value, 0, 0))
			{
				position += value;
				
			}
			int projNr = Main.rand.Next(2, 3);
			for (int af = 0; af < projNr; af++)
			{
				Vector2 value2 = Utils.RotatedByRandom(new Vector2(speedX, speedY), (double)MathHelper.ToRadians(9.5f));
				float scaleFactor = 1f - Utils.NextFloat(Main.rand) * 0.15f;
				value2 *= scaleFactor;
				Projectile.NewProjectile(position.X, position.Y, value2.X, value2.Y, type, damage, knockBack, player.whoAmI, 0f, 0f);
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(ItemID.ShadowScale, 20);
			modRecipe.AddIngredient(ItemID.Amethyst, 5);
			modRecipe.AddTile(TileID.Anvils);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(ItemID.ShadowScale, 1);
			modRecipe.AddTile(114); //Tinkerer's Table
			modRecipe.SetResult(ItemID.TissueSample, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(ItemID.TissueSample, 1);
			modRecipe.AddTile(114); //Tinkerer's Table
			modRecipe.SetResult(ItemID.ShadowScale, 1);
			modRecipe.AddRecipe();
		}
	}
}
