using System;
using Terraria;
using Terraria.ModLoader;

namespace Archeon.Items.Accessories
{
	public class DodgeDash : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dodge Dash");
			Tooltip.SetDefault("Dashing into an attack will dodge it, afterwards you will take double damage for 5 seconds");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 26;
			item.value = Item.buyPrice(0, 4, 0, 0);
			item.rare = 4;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			modPlayer.dodgeDashAcc = true;
			modPlayer.dashMod = 1;
		}
	}
}
