using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Magic.HM
{
	public class ChronologyOfSpells : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chronology of Spells");
			Tooltip.SetDefault("A collection of the most powerful spells from the greatest sorcerers");
		}

		public override void SetDefaults()
		{
			item.damage = 75;
			item.magic = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 5.5f;
			item.value = Item.buyPrice(0, 36, 50, 0);
			item.rare = 5;
			item.mana = 16;
			item.UseSound = SoundID.Item21;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("ChronologyOfSpellsProj");
			item.shootSpeed = 15f;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 value = Vector2.Normalize(new Vector2(speedX, speedY)) * 26f;
			if (Collision.CanHit(position, 0, 0, position + value, 0, 0))
			{
				position += value;
				
			}
			Vector2 value2 = Utils.RotatedByRandom(new Vector2(speedX, speedY), (double)MathHelper.ToRadians(2f));
			Projectile.NewProjectile(position.X, position.Y, value2.X, value2.Y, type, damage, knockBack, player.whoAmI, 0f, 0f);
			
			return false;
		}
		
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("SindomsCodex"), 1);
			modRecipe.AddIngredient(mod.ItemType("BlazingOpus"), 1);
			modRecipe.AddIngredient(mod.ItemType("FrozenOpus"), 1);
			modRecipe.AddIngredient(ItemID.SoulofLight, 10);
			modRecipe.AddIngredient(ItemID.SoulofNight, 10);
			modRecipe.AddIngredient(ItemID.HallowedBar, 12);
			modRecipe.AddTile(TileID.Bookcases);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
