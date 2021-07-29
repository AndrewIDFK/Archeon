using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Melee.PostML
{
	public class NeptunianGrace : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Neptunian Grace");
			Tooltip.SetDefault("The perfect water-based javelin infused with futuristic technology");
		}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.damage = 175;
			item.melee = true;
			item.knockBack = 6.5f;
			item.UseSound = SoundID.Item1;
			item.useTurn = true;
			item.autoReuse = true;
			item.value = Item.buyPrice(0, 42, 0, 0);
			item.rare = 10;
			item.shoot = mod.ProjectileType("NeptunianGraceProj");
			item.noMelee = true;
			item.noUseGraphic = true;
			item.shootSpeed = 27.5f;
			item.useStyle = 1;
			item.useAnimation = 18;
			item.useTime = 18;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(ItemID.LunarBar, 10);
			modRecipe.AddIngredient(ItemID.Nanites, 25);
			modRecipe.AddIngredient(ItemID.DayBreak, 1);
			modRecipe.AddIngredient(mod.ItemType("TideStrider"), 1);
			modRecipe.AddTile(TileID.MythrilAnvil);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
