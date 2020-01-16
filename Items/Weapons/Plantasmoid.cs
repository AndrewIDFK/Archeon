using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000AA RID: 170
	public class Plantasmoid : ModItem
	{
		// Token: 0x06000308 RID: 776 RVA: 0x00019DF5 File Offset: 0x00017FF5
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Plantasmoid");
			base.Tooltip.SetDefault("Shoots a powerful Thorn Ball");
		}

		// Token: 0x06000309 RID: 777 RVA: 0x00019E18 File Offset: 0x00018018
		public override void SetDefaults()
		{
			base.item.damage = 130;
			base.item.magic = true;
			base.item.width = 24;
			base.item.height = 28;
			base.item.useTime = 24;
			base.item.useAnimation = 24;
			base.item.useStyle = 5;
			Item.staff[base.item.type] = true;
			base.item.noMelee = true;
			base.item.knockBack = 8f;
			base.item.value = Item.buyPrice(0, 8, 45, 0);
			base.item.value = Item.sellPrice(0, 8, 45, 0);
			base.item.rare = 8;
			base.item.mana = 25;
			base.item.UseSound = SoundID.Item21;
			base.item.autoReuse = true;
			base.item.shoot = base.mod.ProjectileType("PlantasmoidShot");
			base.item.shootSpeed = 12f;
		}
	}
}
