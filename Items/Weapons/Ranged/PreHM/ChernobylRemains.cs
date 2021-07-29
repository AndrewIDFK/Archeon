using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Ranged.PreHM
{
	public class ChernobylRemains : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chernobyl's Remains");
			Tooltip.SetDefault("The remains of a weapon found in the Wasteland \nInflicts corrosion");
		}
		
		public override void SetDefaults()
		{
			item.damage = 14;
			item.ranged = true;
			item.width = 16;
			item.height = 16;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3.5f;
			item.value = Item.buyPrice(0, 0, 80, 0);
			item.rare = 3;
			item.UseSound = SoundID.Item41;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 17f;
			item.useAmmo = AmmoID.Bullet;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 36f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			Projectile.NewProjectile(position.X, position.Y, muzzleOffset.X * 0.84f, muzzleOffset.Y * 0.84f, mod.ProjectileType("CorrosiveProj"), damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(new Vector2(-15f, -1f));
		}
	}
}
