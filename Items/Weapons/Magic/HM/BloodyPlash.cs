using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Magic.HM
{
	public class BloodyPlash : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloody Plash");
			Tooltip.SetDefault("Casts a burrowing infected parasite");
		}

		public override void SetDefaults()
		{
			item.damage = 52;
			item.magic = true;
			item.width = 38;
			item.height = 38;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true;
			item.knockBack = 3f;
			item.value = Item.buyPrice(0, 2, 10, 0);
			item.rare = 6;
			item.mana = 14;
			item.UseSound = SoundID.Item21;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("BloodyPlashProj");
			item.shootSpeed = 12f;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 value = Vector2.Normalize(new Vector2(speedX, speedY)) * 22f;
			if (Collision.CanHit(position, 0, 0, position + value, 0, 0))
			{
				position += value;
				
			}
			Projectile.NewProjectile(position.X, position.Y, value.X, value.Y, type, damage, knockBack, player.whoAmI, 0f, 0f);
			
			return false;
		}
		
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("ClusterMass"), 1);
			modRecipe.AddIngredient(ItemID.Ichor, 10);
			modRecipe.AddIngredient(ItemID.SoulofNight, 5);
			modRecipe.AddTile(TileID.MythrilAnvil);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
