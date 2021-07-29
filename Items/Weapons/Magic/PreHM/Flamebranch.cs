using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Magic.PreHM
{
	public class Flamebranch : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flamebranch");
			Tooltip.SetDefault("Casts a bright light");
		}

		public override void SetDefaults()
		{
			item.damage = 12;
			item.magic = true;
			item.width = 38;
			item.height = 38;
			item.useTime = 29;
			item.useAnimation = 29;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true;
			item.knockBack = 1;
			item.value = Item.buyPrice(0, 0, 40, 0);
			item.rare = 2;
			item.mana = 15;
			item.UseSound = SoundID.Item21;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("FlamebranchProj");
			item.shootSpeed = 8f;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 value = Vector2.Normalize(new Vector2(speedX, speedY)) * 12f;
			if (Collision.CanHit(position, 0, 0, position + value, 0, 0))
			{
				position += value;
				
			}
			Vector2 value2 = Utils.RotatedByRandom(new Vector2(speedX, speedY), (double)MathHelper.ToRadians(4.5f));
			float scaleFactor = 1f - Utils.NextFloat(Main.rand) * 0.125f;
			value2 *= scaleFactor;
			Projectile.NewProjectile(position.X, position.Y, value2.X, value2.Y, type, damage, knockBack, player.whoAmI, 0f, 0f);
			
			return false;
		}
		
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(ItemID.Wood, 20);
			modRecipe.AddIngredient(ItemID.Gel, 40);
			modRecipe.AddTile(TileID.WorkBenches);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
