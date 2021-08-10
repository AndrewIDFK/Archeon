using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Melee.PreHM
{
	public class TheLemmy : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Lemmy");
			//Tooltip.SetDefault("'Isn't there already a jungle yoyo in the game?' \n'Is there? Damn...' \n'Well, who cares about that, this yoyo will be better!");
			Tooltip.SetDefault("'What should this yoyo do?' \n'Oh I know, how about it fires a spread of spores!' \n'Yeah that sounds good, but only after hitting enemies a few times, yeah?'");
		}

		public override void SetDefaults()
		{
			item.damage = 24;
			item.melee = true;
			item.useTime = 14;
			item.useAnimation = 28;
			item.useStyle = 5;
			item.channel = true;
			item.knockBack = 3.5f;
			item.value = Item.buyPrice(0, 0, 95, 0);
			item.rare = 4;
			item.shoot = mod.ProjectileType("LemmyProj");
			item.noUseGraphic = true;
			item.noMelee = true;
			item.UseSound = SoundID.Item1;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("TheSiggator"), 1);
			modRecipe.AddIngredient(ItemID.JungleSpores, 10);
			modRecipe.AddIngredient(ItemID.Stinger, 10);
			modRecipe.AddTile(TileID.Anvils);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
