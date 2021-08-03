using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Buffs.Minions
{
	public class RougeWardMinionBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Crimson Guard");
			Description.SetDefault("The infected amalgam above you wants nothing but to protect you");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("RougeWardMinion")] > 0 && player.ownedProjectileCounts[mod.ProjectileType("RougeWardMinion2")] > 0 )
			{
				modPlayer.rougeWard = true;
			}
			if (!modPlayer.rougeWard)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
				return;
			}
			player.buffTime[buffIndex] = 18000;
		}
	}
}
