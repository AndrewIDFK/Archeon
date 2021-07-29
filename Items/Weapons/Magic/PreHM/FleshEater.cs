using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Magic.PreHM
{
	public class FleshEater : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flesh Eater");
			Tooltip.SetDefault("Casts a devouring mist");
		}

		public override void SetDefaults()
		{
			item.damage = 24;
			item.magic = true;
			item.width = 38;
			item.height = 38;
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true;
			item.knockBack = 2.5f;
			item.value = Item.buyPrice(0, 0, 90, 0);
			item.rare = 4;
			item.mana = 10;
			item.UseSound = SoundID.Item21;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("FleshEaterProj");
			item.shootSpeed = 9.5f;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 value = Vector2.Normalize(new Vector2(speedX, speedY)) * 11f;
			if (Collision.CanHit(position, 0, 0, position + value, 0, 0))
			{
				position += value;
				
			}
			Projectile.NewProjectile(position.X, position.Y, value.X, value.Y, type, damage, knockBack, player.whoAmI, 0f, 0f);
			
			return false;
		}
	}
}
