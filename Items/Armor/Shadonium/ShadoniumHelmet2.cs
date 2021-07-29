using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Armor.Shadonium
{
	[AutoloadEquip(EquipType.Head)]
	public class ShadoniumHelmet2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Shadonium Hood");
			Tooltip.SetDefault("Significantly Increased Life Regeneration\n6% increased damage and critical hit chance");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 0, 85, 0);
			item.rare = 4;
			item.defense = 5;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.06f;
			player.thrownDamage += 0.06f;
			player.rangedDamage += 0.06f;
			player.magicDamage += 0.06f;
			player.minionDamage += 0.06f;
			player.meleeCrit += 6;
			player.rangedCrit += 6;
			player.thrownCrit += 6;
			player.magicCrit += 6;
			player.lifeRegen += 6;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == base.mod.ItemType("ShadoniumChestplate") && legs.type == base.mod.ItemType("ShadoniumLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "9% increased critical hit chance \nIncreased Immunity Frames and Movement Speed when taking more than 30 damage.";
	
			player.GetModPlayer<MyPlayer>().ShadoniumHelmet2 = true;
			
			player.meleeCrit += 9;
			player.rangedCrit += 9;
			player.thrownCrit += 9;
			player.magicCrit += 9;
			
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
			player.armorEffectDrawShadow = true;
			player.armorEffectDrawShadowSubtle = false;
			player.armorEffectDrawOutlines = false;
			player.armorEffectDrawShadowLokis = false;
			player.armorEffectDrawShadowBasilisk = false;
			player.armorEffectDrawOutlinesForbidden = false;
			player.armorEffectDrawShadowEOCShield = false;
		}
	}
}
