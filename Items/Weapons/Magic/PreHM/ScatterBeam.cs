using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Magic.PreHM
{
	public class ScatterBeam : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scatter Beam");
			Tooltip.SetDefault("Casts multiple inaccurate magic beams");
		}

		public override void SetDefaults()
		{
			item.damage = 16;
			item.magic = true;
			item.mana = 18;
			item.width = 28;
			item.height = 30;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 1.2f;
			item.value = Item.buyPrice(0, 1, 80, 0);
			item.rare = 4;
			item.UseSound = SoundID.Item84;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("RubyBeam");
			item.shootSpeed = 10f;
		}

		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 1; i++)
			{
				Vector2 value = Utils.RotatedByRandom(new Vector2(speedX, speedY), (double)MathHelper.ToRadians(26f));
				float scaleFactor = 1.25f - Utils.NextFloat(Main.rand) * 0.84f;
				value *= scaleFactor;
				
				Projectile.NewProjectile(position.X, position.Y, value.X * 1.45f, value.Y * 1.45f, mod.ProjectileType("DiamondBeam"), damage + 4, knockBack, player.whoAmI, 0f, 0f);
			}
			
			for (int i = 0; i < 1; i++)
			{
				Vector2 value = Utils.RotatedByRandom(new Vector2(speedX, speedY), (double)MathHelper.ToRadians(28f));
				float scaleFactor = 1.26f - Utils.NextFloat(Main.rand) * 0.85f;
				value *= scaleFactor;
				
				Projectile.NewProjectile(position.X, position.Y, value.X, value.Y, type, damage + 3, knockBack, player.whoAmI, 0f, 0f);
			}
			
			for (int i = 0; i < 1; i++)
			{
				Vector2 value = Utils.RotatedByRandom(new Vector2(speedX, speedY), (double)MathHelper.ToRadians(29f));
				float scaleFactor = 1.27f - Utils.NextFloat(Main.rand) * 0.86f;
				value *= scaleFactor;
				
				Projectile.NewProjectile(position.X, position.Y, value.X * 1.45f, value.Y * 1.45f, mod.ProjectileType("EmeraldBeam"), damage + 2, knockBack, player.whoAmI, 0f, 0f);
			}
			
			for (int i = 0; i < 1; i++)
			{
				Vector2 value = Utils.RotatedByRandom(new Vector2(speedX, speedY), (double)MathHelper.ToRadians(31f));
				float scaleFactor = 1.28f - Utils.NextFloat(Main.rand) * 0.87f;
				value *= scaleFactor;
				
				Projectile.NewProjectile(position.X, position.Y, value.X, value.Y, mod.ProjectileType("SapphireBeam"), damage + 1, knockBack, player.whoAmI, 0f, 0f);
			}
			
			for (int i = 0; i < 1; i++)
			{
				Vector2 value = Utils.RotatedByRandom(new Vector2(speedX, speedY), (double)MathHelper.ToRadians(33f));
				float scaleFactor = 1.29f - Utils.NextFloat(Main.rand) * 0.88f;
				value *= scaleFactor;
				
				Projectile.NewProjectile(position.X, position.Y, value.X * 1.45f, value.Y * 1.45f, mod.ProjectileType("AmethystBeam"), damage, knockBack, player.whoAmI, 0f, 0f);
			}
			return false; 
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(ItemID.Book);
			modRecipe.AddIngredient(ItemID.Diamond, 3);
			modRecipe.AddIngredient(ItemID.Ruby, 3);
			modRecipe.AddIngredient(ItemID.Emerald, 3);
			modRecipe.AddIngredient(ItemID.Sapphire, 3);
			modRecipe.AddIngredient(ItemID.Amethyst, 3);
			modRecipe.AddTile(TileID.Anvils);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
