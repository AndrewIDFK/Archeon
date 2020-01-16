using System;
using Terraria;
using Terraria.ModLoader;

namespace Archeon.Accessories
{
	public class DodgeDash : ModItem
	{

		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Dodge Dash");
			base.Tooltip.SetDefault("Dashing into an attack will dodge it, however after the dodge you will take double damage for 5 seconds");
		}

		public override void SetDefaults()
		{
			base.item.width = 26;
			base.item.height = 26;
			base.item.value = Item.buyPrice(0, 4, 0, 0);
			base.item.rare = 4;
			base.item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			modPlayer.dodgeDashAcc = true;
			modPlayer.dashMod = 1;
		}
	}
}
