using System;
using Terraria;
using Terraria.ModLoader;

namespace Archeon.Buffs
{
	public class DefenseOrbAccessory : ModBuff
	{
		public override void SetDefaults()
		{
			base.DisplayName.SetDefault("The Orb of Defense");
			base.Description.SetDefault("The Orb shall aid you in your journey!");
			Main.buffNoTimeDisplay[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[base.mod.ProjectileType("DefenseOrbAccessory")] > 0)
			{
				modPlayer.DefOrbAcc = true;
			}
			if (!modPlayer.DefOrbAcc)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
				return;
			}
			player.buffTime[buffIndex] = 66666;
		}
	}
}
