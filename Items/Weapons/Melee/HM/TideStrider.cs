using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Melee.HM
{
	public class TideStrider : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tide Strider");
			Tooltip.SetDefault("Javelins that break the stride of anyone they attack");
		}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.damage = 78;
			item.melee = true;
			item.knockBack = 4.5f;
			item.UseSound = SoundID.Item1;
			item.useTurn = true;
			item.autoReuse = true;
			item.value = Item.buyPrice(0, 26, 0, 0);
			item.rare = 7;
			item.shoot = mod.ProjectileType("TideStriderProj");
			item.noMelee = true;
			item.noUseGraphic = true;
			item.shootSpeed = 18.5f;
			item.useStyle = 1;
			item.useAnimation = 22;
			item.useTime = 22;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("ThaniteBar"), 20);
			modRecipe.AddIngredient(mod.ItemType("FeralShard"), 5);
			modRecipe.AddIngredient(mod.ItemType("OceanicGlaive"), 1);
			modRecipe.AddTile(TileID.MythrilAnvil);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
