using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Magic.PreHM
{
	public class SindomsCodex : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sindom's Codex");
			Tooltip.SetDefault("A book of mysteries written by Sindom");
		}

		public override void SetDefaults()
		{
			item.damage = 38;
			item.magic = true;
			item.width = 24;
			item.height = 28;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 2.5f;
			item.value = Item.buyPrice(0, 1, 05, 0);
			item.rare = 4;
			item.mana = 7;
			item.UseSound = SoundID.Item21;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("SindomsCodexProj");
			item.shootSpeed = 12f;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 value = Vector2.Normalize(new Vector2(speedX, speedY)) * 19f;
			if (Collision.CanHit(position, 0, 0, position + value, 0, 0))
			{
				position += value;
				
			}
			Vector2 value2 = Utils.RotatedByRandom(new Vector2(speedX, speedY), (double)MathHelper.ToRadians(3.5f));
			float scaleFactor = 1f - Utils.NextFloat(Main.rand) * 0.15f;
			value2 *= scaleFactor;
			Projectile.NewProjectile(position.X, position.Y, value2.X, value2.Y, type, damage, knockBack, player.whoAmI, 0f, 0f);
			
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(ItemID.Bone, 20);
			modRecipe.AddIngredient(ItemID.Amber, 5);
			modRecipe.AddIngredient(ItemID.Book, 1);
			modRecipe.AddTile(TileID.Anvils);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
