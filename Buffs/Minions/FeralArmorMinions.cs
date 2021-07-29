using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Buffs.Minions
{
	public class FeralArmorMinions : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Feral Slimes");
			Description.SetDefault("The Poisonous Slime and the Venomous Slime are here to protect you");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (!modPlayer.feralSlimes)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
				return;
			}
			player.buffTime[buffIndex] = 420;
		}
	}
}
