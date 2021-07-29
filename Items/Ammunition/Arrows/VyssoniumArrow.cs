using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Ammunition.Arrows
{
	public class VyssoniumArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vyssonium Arrow");
		}

		public override void SetDefaults()
		{
			item.damage = 12;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 9999;
			item.consumable = true;
			item.knockBack = 1.2f;
			item.value = Item.buyPrice(0, 0, 5, 0);
			item.rare = 3;
			item.shoot = mod.ProjectileType("VyssoniumArrowProj");
			item.shootSpeed = 3.5f;
			item.ammo = 40;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("VyssoniumBar"), 1);
			modRecipe.AddIngredient(ItemID.WoodenArrow, 100);
			modRecipe.AddTile(TileID.Anvils);
			modRecipe.SetResult(this, 100);
			modRecipe.AddRecipe();
		}
	}
}
