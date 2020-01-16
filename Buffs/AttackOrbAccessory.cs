using System;
using Terraria;
using Terraria.ModLoader;

namespace Archeon.Buffs
{
	public class AttackOrbAccessory : ModBuff
	{
		public override void SetDefaults()
		{
			base.DisplayName.SetDefault("The Orb of Attack");
			base.Description.SetDefault("The Orb shall fight for you!");
			Main.buffNoTimeDisplay[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[base.mod.ProjectileType("AttackOrbAccessory")] > 0)
			{
				modPlayer.AttOrbAcc = true;
			}
			if (!modPlayer.AttOrbAcc)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
				return;
			}
			player.buffTime[buffIndex] = 66666;
		}
	}
}
