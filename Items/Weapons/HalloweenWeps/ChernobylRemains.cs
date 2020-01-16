using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.HalloweenWeps
{
	
	public class ChernobylRemains : ModItem
	{
		
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Chernobyl's Remains");
			base.Tooltip.SetDefault("The remain of a weapon found in the Wasteland \nInflicts corrosion");
		}

		
		public override void SetDefaults()
		{
			base.item.damage = 10;
			base.item.ranged = true;
			base.item.width = 16;
			base.item.height = 16;
			base.item.useTime = 19;
			base.item.useAnimation = 19;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 4f;
			base.item.value = Item.sellPrice(0, 0, 80, 0);
			base.item.rare = 2;
			base.item.UseSound = SoundID.Item41;
			base.item.autoReuse = true;
			base.item.shoot = mod.ProjectileType("CorrosiveShot");
			base.item.shootSpeed = 17f;
			base.item.useAmmo = AmmoID.Bullet;
		}

		
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			
			int numberProjectiles = 1; // 4 or 5 shots
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 34f;
				if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
				{
					position += muzzleOffset;
				}
				Projectile.NewProjectile(position.X, position.Y, muzzleOffset.X * 0.77f, muzzleOffset.Y * 0.77f, mod.ProjectileType("CorrosiveShot"), damage, knockBack, player.whoAmI, 0f, 0f);
			}
			
			
			return false;
		}

		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(new Vector2(-15f, -3f));
		}
	}
}
