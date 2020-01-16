using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Armor.RockSteele
{
	// Token: 0x02000042 RID: 66
	[AutoloadEquip(EquipType.Head)]
	public class RockSteeleHelmet : ModItem
	{
		// Token: 0x0600010E RID: 270 RVA: 0x00007B0E File Offset: 0x00005D0E
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			base.DisplayName.SetDefault("RockSteele Helmet");
			base.Tooltip.SetDefault("You feel your vision improving\n8% increased damage\n5% increased critical hit chance");
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00007B38 File Offset: 0x00005D38
		public override void SetDefaults()
		{
			base.item.width = 18;
			base.item.height = 18;
			base.item.value = Item.buyPrice(0, 2, 60, 0);
			base.item.value = Item.sellPrice(0, 2, 60, 0);
			base.item.rare = 6;
			base.item.defense = 20;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00007BA4 File Offset: 0x00005DA4
		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.08f;
			player.thrownDamage += 0.08f;
			player.rangedDamage += 0.08f;
			player.magicDamage += 0.08f;
			player.minionDamage += 0.08f;
			player.meleeCrit += 5;
			player.rangedCrit += 5;
			player.thrownCrit += 5;
			player.magicCrit += 5;
			player.nightVision = true;
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00007C4A File Offset: 0x00005E4A
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == base.mod.ItemType("RockSteeleChestplate") && legs.type == base.mod.ItemType("RockSteeleLeggings");
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00007C80 File Offset: 0x00005E80
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "You start Shining. Increased life regeneration. 10% increased damage and 6% increased critical hit chance";
			player.meleeDamage += 0.1f;
			player.thrownDamage += 0.1f;
			player.rangedDamage += 0.1f;
			player.magicDamage += 0.1f;
			player.minionDamage += 0.1f;
			player.lifeRegen += 4;
			player.meleeCrit += 6;
			player.rangedCrit += 6;
			player.thrownCrit += 6;
			player.magicCrit += 6;
			Lighting.AddLight((int)(player.Center.X / 16f), (int)(player.Center.Y / 16f), 0.465f, 0.905f, 1.065f);
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00007D80 File Offset: 0x00005F80
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("RockSteeleBar"), 17);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00007DCA File Offset: 0x00005FCA
		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = false;
			player.armorEffectDrawShadowSubtle = false;
			player.armorEffectDrawOutlines = false;
			player.armorEffectDrawShadowLokis = true;
			player.armorEffectDrawShadowBasilisk = false;
			player.armorEffectDrawOutlinesForbidden = false;
			player.armorEffectDrawShadowEOCShield = true;
		}
	}
}
