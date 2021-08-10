using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Armor.Vyssonium
{
	[AutoloadEquip(EquipType.Head)]
	public class BloodiedHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Bloodied Helmet");
			Tooltip.SetDefault("7% increased critical hit chance");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 0, 85, 0);
			item.rare = 4;
			item.defense = 6;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeCrit += 7;
			player.rangedCrit += 7;
			player.thrownCrit += 7;
			player.magicCrit += 7;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("BloodiedChestplate") && legs.type == mod.ItemType("BloodiedLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Attacking enemies has a chance to build up a Bloodied Charge \nBloodied Charge releases when its at max or when you get hit";	
			player.GetModPlayer<MyPlayer>().BloodiedCharge = true;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("VyssoniumBar"), 15);
			modRecipe.AddIngredient(ItemID.Bone, 5);
			modRecipe.AddTile(TileID.Anvils);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
		
		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowSubtle = true;
		}
	}
}
