using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Armor.Vyssonium
{
	// Token: 0x02000042 RID: 66
	[AutoloadEquip(EquipType.Head)]
	public class VyssoniumHelmet1 : ModItem
	{
		// Token: 0x0600010E RID: 270 RVA: 0x00007B0E File Offset: 0x00005D0E
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			base.DisplayName.SetDefault("Vyssonium Headgear");
			base.Tooltip.SetDefault("8% increased melee damage and critical hit chance");
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00007B38 File Offset: 0x00005D38
		public override void SetDefaults()
		{
			base.item.width = 18;
			base.item.height = 18;
			base.item.value = Item.buyPrice(0, 0, 85, 0);
			base.item.value = Item.sellPrice(0, 0, 85, 0);
			base.item.rare = 5;
			base.item.defense = 6;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00007BA4 File Offset: 0x00005DA4
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

		// Token: 0x06000111 RID: 273 RVA: 0x00007C4A File Offset: 0x00005E4A
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == base.mod.ItemType("VyssoniumChestplate") && legs.type == base.mod.ItemType("VyssoniumLeggings");
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00007C80 File Offset: 0x00005E80
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "5% increased melee damage \nAttacks inflict Vyssonium poisoning, does extra damage in Hardmode";
			
			player.GetModPlayer<MyPlayer>().VyssoniumHelmet1 = true;
			
			player.meleeDamage += 0.05f;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("VyssoniumBar"), 16);
			modRecipe.AddIngredient(1329, 8);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
		
		// Token: 0x06000114 RID: 276 RVA: 0x00007DCA File Offset: 0x00005FCA
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
