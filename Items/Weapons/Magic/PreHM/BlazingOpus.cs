using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Magic.PreHM
{
	public class BlazingOpus : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blazing Opus");
			Tooltip.SetDefault("Casts a flaming ball of fire");
		}

		public override void SetDefaults()
		{
			item.damage = 38;
			item.magic = true;
			item.width = 24;
			item.height = 28;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3.25f;
			item.value = Item.buyPrice(0, 0, 70, 0);
			item.rare = 4;
			item.mana = 6;
			item.UseSound = SoundID.Item21;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("BlazingOpusProj");
			item.shootSpeed = 12.5f;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(ItemID.Obsidian, 12);
			modRecipe.AddIngredient(ItemID.Book, 1);
			modRecipe.AddTile(TileID.Anvils);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
