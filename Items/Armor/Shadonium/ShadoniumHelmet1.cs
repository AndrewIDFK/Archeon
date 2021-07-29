using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Armor.Shadonium
{
	[AutoloadEquip(EquipType.Head)]
	public class ShadoniumHelmet1 : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Shadonium Headgear");
			Tooltip.SetDefault("3% increased damage and critical hit chance");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 0, 85, 0);
			item.rare = 4;
			item.defense = 10;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.03f;
			player.thrownDamage += 0.03f;
			player.rangedDamage += 0.03f;
			player.magicDamage += 0.03f;
			player.minionDamage += 0.03f;
			player.meleeCrit += 3;
			player.rangedCrit += 3;
			player.thrownCrit += 3;
			player.magicCrit += 3;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("ShadoniumChestplate") && legs.type == mod.ItemType("ShadoniumLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Reduces damage taken by 8% and increases all damage by 10%";
			
			player.endurance += 0.08f;

			player.meleeDamage += 0.1f;
			player.thrownDamage += 0.1f;
			player.rangedDamage += 0.1f;
			player.magicDamage += 0.1f;
			player.minionDamage += 0.1f;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("ShadoniumBar"), 16);
			modRecipe.AddIngredient(86, 8);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = false;
			player.armorEffectDrawShadowSubtle = false;
			player.armorEffectDrawOutlines = true;
			player.armorEffectDrawShadowLokis = false;
			player.armorEffectDrawShadowBasilisk = false;
			player.armorEffectDrawOutlinesForbidden = false;
			player.armorEffectDrawShadowEOCShield = false;
		}
	}
}
