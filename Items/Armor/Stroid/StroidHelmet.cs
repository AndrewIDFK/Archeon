using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Armor.Stroid
{
	// Token: 0x02000047 RID: 71
	[AutoloadEquip(EquipType.Head)]
	public class StroidHelmet : ModItem
	{
		// Token: 0x0600012C RID: 300 RVA: 0x000082C6 File Offset: 0x000064C6
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			base.DisplayName.SetDefault("Stroid Helmet");
			base.Tooltip.SetDefault("You can see better in the dark.\n13% increased Minion damage");
		}

		// Token: 0x0600012D RID: 301 RVA: 0x000082F0 File Offset: 0x000064F0
		public override void SetDefaults()
		{
			base.item.width = 18;
			base.item.height = 18;
			base.item.value = Item.buyPrice(0, 5, 60, 0);
			base.item.value = Item.sellPrice(0, 5, 60, 0);
			base.item.rare = 7;
			base.item.defense = 17;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x0000835A File Offset: 0x0000655A
		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.13f;
			player.nightVision = true;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00008375 File Offset: 0x00006575
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == base.mod.ItemType("StroidChestplate") && legs.type == base.mod.ItemType("StroidLeggings");
		}

		// Token: 0x06000130 RID: 304 RVA: 0x000083AC File Offset: 0x000065AC
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Enemies get distracted, making them less likely to target you.\n25% increased Minion damage.\nAdds 2 Extra Minion Slots.";
			player.minionDamage += 0.25f;
			player.maxMinions++;
			player.maxMinions++;
			player.aggro -= 3;
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00008400 File Offset: 0x00006600
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("StroidBar"), 18);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		// Token: 0x06000132 RID: 306 RVA: 0x0000844A File Offset: 0x0000664A
		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = false;
			player.armorEffectDrawShadowSubtle = true;
			player.armorEffectDrawOutlines = false;
			player.armorEffectDrawShadowLokis = true;
			player.armorEffectDrawShadowLokis = true;
			player.armorEffectDrawShadowBasilisk = false;
			player.armorEffectDrawOutlinesForbidden = true;
			player.armorEffectDrawShadowEOCShield = true;
		}
	}
}
