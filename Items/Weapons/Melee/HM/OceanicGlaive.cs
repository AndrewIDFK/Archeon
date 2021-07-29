using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Melee.HM
{
	public class OceanicGlaive : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Oceanic Glaive");
			Tooltip.SetDefault("Though an imitation of the ancient relic, it's exceptionally crafted");
		}

		public override void SetDefaults()
		{
			item.melee = true;
			item.width = 40;
			item.height = 50;
			item.knockBack = 6f;
			item.value = Item.buyPrice(0, 12, 0, 0);
			item.rare = 6;
			item.UseSound = SoundID.Item1;
			item.useTime = 25;
			item.useAnimation = 25;
			item.damage = 38;
			item.shootSpeed = 5f;
			item.useStyle = 5;
			item.noUseGraphic = true;
			item.shoot = mod.ProjectileType("OceanicGlaiveSpear");
			item.autoReuse = true;
		}
		
		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[item.shoot] < 1;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(ItemID.HallowedBar, 15);
			modRecipe.AddIngredient(ItemID.SharkFin, 2);
			modRecipe.AddIngredient(mod.ItemType("DeepSeaGlaive"), 1);
			modRecipe.AddTile(TileID.MythrilAnvil);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
