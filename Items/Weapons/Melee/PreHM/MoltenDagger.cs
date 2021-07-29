using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Melee.PreHM
{
	public class MoltenDagger : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Molten Dagger");
			Tooltip.SetDefault("Releases flaming sparks when it breaks");
		}

		public override void SetDefaults()
		{
			item.damage = 38;
			item.melee = true;
			item.width = 38;
			item.height = 38;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.knockBack = 3.5f;
			item.value = Item.buyPrice(0, 0, 85, 0);
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("MoltenDaggerProj");
			item.shootSpeed = 17.5f;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(ItemID.HellstoneBar, 15);
			modRecipe.AddIngredient(ItemID.Obsidian, 5);
			modRecipe.AddTile(TileID.Anvils);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("MoltenDaggerThrown"), 1);
			modRecipe.AddTile(TileID.Anvils);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
