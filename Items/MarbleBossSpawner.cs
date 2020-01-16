using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items
{
	// Token: 0x02000039 RID: 57
	public class MarbleBossSpawner : ModItem
	{
		// Token: 0x060000E9 RID: 233 RVA: 0x00006FFC File Offset: 0x000051FC
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Petrified Rib");
			base.Tooltip.SetDefault("Summons Prometheus\nOnly usable at Night");
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00007020 File Offset: 0x00005220
		public override void SetDefaults()
		{
			base.item.width = 32;
			base.item.height = 32;
			base.item.maxStack = 25;
			base.item.rare = 4;
			base.item.useAnimation = 45;
			base.item.value = Item.buyPrice(0, 0, 30, 0);
			base.item.value = Item.sellPrice(0, 0, 30, 0);
			base.item.useTime = 45;
			base.item.useStyle = 4;
			base.item.UseSound = SoundID.Item44;
			base.item.consumable = true;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x000070CD File Offset: 0x000052CD
		public override bool CanUseItem(Player player)
		{
			return !Main.dayTime && !NPC.AnyNPCs(base.mod.NPCType("MarbleBoss"));

		}

		// Token: 0x060000EC RID: 236 RVA: 0x000070F8 File Offset: 0x000052F8
		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, base.mod.NPCType("MarbleBoss"));
			
			Main.PlaySound(15, player.position, 0);
			return true;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00007124 File Offset: 0x00005324
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(154, 30); //BONZ
			modRecipe.AddIngredient(3081, 30); //MORBLZ
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
