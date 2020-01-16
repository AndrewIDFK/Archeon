using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Tools
{
	// Token: 0x0200007E RID: 126
	public class CrystallicPickaxe : ModItem
	{
		// Token: 0x06000241 RID: 577 RVA: 0x00015488 File Offset: 0x00013688
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Crystallic Pickaxe");
			base.Tooltip.SetDefault("Can be used to mine Stroid Meteors");
		}

		// Token: 0x06000242 RID: 578 RVA: 0x000154AC File Offset: 0x000136AC
		public override void SetDefaults()
		{
			base.item.damage = 48;
			base.item.melee = true;
			base.item.width = 34;
			base.item.height = 34;
			base.item.useTime = 4;
			base.item.useAnimation = 10;
			base.item.pick = 215;
			base.item.useStyle = 1;
			base.item.knockBack = 8f;
			base.item.value = Item.buyPrice(0, 7, 0, 0);
			base.item.value = Item.sellPrice(0, 7, 0, 0);
			base.item.rare = 8;
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
			base.item.useTurn = true;
		}
	}
}
