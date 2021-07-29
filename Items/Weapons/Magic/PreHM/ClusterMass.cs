using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Magic.PreHM
{
	public class ClusterMass : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cluster Mass");
			Tooltip.SetDefault("Casts a growing cluster of infected mass");
		}

		public override void SetDefaults()
		{
			item.damage = 34;
			item.magic = true;
			item.width = 38;
			item.height = 38;
			item.useTime = 34;
			item.useAnimation = 34;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true;
			item.knockBack = 2.5f;
			item.value = Item.buyPrice(0, 0, 90, 0);
			item.rare = 4;
			item.mana = 12;
			item.UseSound = SoundID.Item21;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("ClusterMassProj");
			item.shootSpeed = 8f;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 value = Vector2.Normalize(new Vector2(speedX, speedY)) * 10f;
			if (Collision.CanHit(position, 0, 0, position + value, 0, 0))
			{
				position += value;
				
			}
			Projectile.NewProjectile(position.X, position.Y, value.X, value.Y, type, damage, knockBack, player.whoAmI, 0f, 0f);
			
			return false;
		}
	}
}
