using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Armor.Vyssonium
{
	[AutoloadEquip(EquipType.Head)]
	public class VyssoniumHelmet2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Vyssonium Visor");
			Tooltip.SetDefault("8% Increased melee speed and critical hit chance");
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
			player.meleeSpeed += 0.08f;
			player.meleeCrit += 8;
			player.rangedCrit += 8;
			player.thrownCrit += 8;
			player.magicCrit += 8;
			
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("VyssoniumChestplate") && legs.type == mod.ItemType("VyssoniumLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "5% increased critical hit chance \n25% Increased melee speed for a short time after being hit";
	
			player.GetModPlayer<MyPlayer>().VyssoniumHelmet2 = true;
			
			player.meleeCrit += 5;
			player.rangedCrit += 5;
			player.thrownCrit += 5;
			player.magicCrit += 5;
			
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("VyssoniumBar"), 16);
			modRecipe.AddIngredient(1329, 8);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
			player.armorEffectDrawShadowSubtle = false;
			player.armorEffectDrawOutlines = false;
			player.armorEffectDrawShadowLokis = true;
			player.armorEffectDrawShadowBasilisk = false;
			player.armorEffectDrawOutlinesForbidden = true;
			player.armorEffectDrawShadowEOCShield = false;
		}
	}
}
