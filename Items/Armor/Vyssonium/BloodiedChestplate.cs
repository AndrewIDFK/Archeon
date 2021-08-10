using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Armor.Vyssonium
{
	[AutoloadEquip(EquipType.Body)]
	public class BloodiedChestplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Bloodied Breastplate");
			Tooltip.SetDefault("5% increased all damage");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 0, 95, 0);
			item.rare = 4;
			item.defense = 9;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.05f;
			player.rangedDamage += 0.05f;
			player.thrownDamage += 0.05f;
			player.magicDamage += 0.05f;
			player.minionDamage += 0.05f;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("VyssoniumBar"), 25);
			modRecipe.AddIngredient(ItemID.Bone, 15);
			modRecipe.AddTile(TileID.Anvils);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
