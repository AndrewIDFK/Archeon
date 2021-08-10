using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Ranged.PreHM
{
	public class Hemorrhage : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hemorrhage");
			Tooltip.SetDefault("Fires fleshy clumps which stick to enemies");
		}

		public override void SetDefaults()
		{
			item.damage = 28;
			item.ranged = true;
			item.width = 54;
			item.height = 16;
			item.useTime = 33;
			item.useAnimation = 31;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 1.5f;
			item.value = Item.buyPrice(0, 0, 90, 0);
			item.rare = 4;
			item.UseSound = SoundID.Item77;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("HemorrhageProj");
			item.shootSpeed = 9.5f;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("VyssoniumBar"), 22);
			modRecipe.AddTile(TileID.Anvils);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(new Vector2(-6, -2));
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{		
			Vector2 value = Vector2.Normalize(new Vector2(speedX, speedY)) * 16f;
			if (Collision.CanHit(position, 0, 0, position + value, 0, 0))
			{
				position += value;
			}	
			Projectile.NewProjectile(position.X, position.Y, value.X, value.Y, mod.ProjectileType("HemorrhageProj"), damage, knockBack, player.whoAmI, 0f, 0f);
			
			return false;
		}
	}
}
