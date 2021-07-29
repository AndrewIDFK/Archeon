using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Armor.Vyssonium
{
	[AutoloadEquip(EquipType.Head)]
	public class VyssoniumHelmet1 : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Vyssonium Headgear");
			Tooltip.SetDefault("8% increased melee damage and critical hit chance");
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
			player.meleeDamage += 0.08f;
			player.thrownDamage += 0.08f;
			player.rangedDamage += 0.08f;
			player.magicDamage += 0.08f;
			player.minionDamage += 0.08f;
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
			player.setBonus = "5% increased melee damage \nAttacks inflict Vyssonium poisoning, does extra damage in Hardmode";
			
			player.GetModPlayer<MyPlayer>().VyssoniumHelmet1 = true;
			
			player.meleeDamage += 0.05f;
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
			player.armorEffectDrawShadow = false;
			player.armorEffectDrawShadowSubtle = true;
			player.armorEffectDrawOutlines = true;
			player.armorEffectDrawShadowLokis = false;
			player.armorEffectDrawShadowBasilisk = true;
			player.armorEffectDrawOutlinesForbidden = false;
			player.armorEffectDrawShadowEOCShield = false;
		}
	}
}
