using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Armor.Vyssonium
{
	[AutoloadEquip(EquipType.Legs)]
	public class BloodiedLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloodied Leggings");
			Tooltip.SetDefault("10% increased movement speed");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 0, 70, 0);
			item.rare = 4;
			item.defense = 7;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.1f;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("VyssoniumBar"), 20);
			modRecipe.AddIngredient(ItemID.Bone, 10);
			modRecipe.AddTile(TileID.Anvils);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
