using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Armor.Vyssonium
{
	// Token: 0x02000042 RID: 66
	[AutoloadEquip(EquipType.Head)]
	public class VyssoniumHelmet2 : ModItem
	{
		// Token: 0x0600010E RID: 270 RVA: 0x00007B0E File Offset: 0x00005D0E
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			base.DisplayName.SetDefault("Vyssonium Visor");
			base.Tooltip.SetDefault("8% Increased melee speed and critical hit chance");
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
			player.meleeSpeed += 0.08f;
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
			player.setBonus = "5% increased critical hit chance \n25% Increased melee speed for a short time after being struck.";
	
			player.GetModPlayer<MyPlayer>().VyssoniumHelmet2 = true;
			
			player.meleeCrit += 5;
			player.rangedCrit += 5;
			player.thrownCrit += 5;
			player.magicCrit += 5;
			
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
