using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Buffs
{
	// Token: 0x02000026 RID: 38
	public class StroidWormerBuff : ModBuff
	{
		// Token: 0x060000A6 RID: 166 RVA: 0x00005CB2 File Offset: 0x00003EB2
		public override void SetDefaults()
		{
			base.DisplayName.SetDefault("Stroid Eel");
			base.Description.SetDefault("Most likely protects you");
			Main.buffNoSave[base.Type] = true;
			Main.buffNoTimeDisplay[base.Type] = true;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00005CF0 File Offset: 0x00003EF0
		public override void Update(Player player, ref int buffIndex)
		{
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[base.mod.ProjectileType("StroidWormerHead")] > 0 || player.ownedProjectileCounts[base.mod.ProjectileType("StroidWormerBody")] > 0)
			{
				modPlayer.StroidWormer = true;
			}
			if (!modPlayer.StroidWormer)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
				return;
			}
			player.buffTime[buffIndex] = 18000;
		}
	}
}
