using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Buffs
{
	// Token: 0x0200001D RID: 29
	public class BabyStroidBuff : ModBuff
	{
		// Token: 0x06000085 RID: 133 RVA: 0x000054C1 File Offset: 0x000036C1
		public override void SetDefaults()
		{
			base.DisplayName.SetDefault("Baby Stroider");
			base.Description.SetDefault("Baby Stroider fights along your side!");
			Main.buffNoTimeDisplay[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00005500 File Offset: 0x00003700
		public override void Update(Player player, ref int buffIndex)
		{
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[base.mod.ProjectileType("StroidMinion")] > 0)
			{
				modPlayer.StroidMinion = true;
			}
			if (!modPlayer.StroidMinion)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
				return;
			}
			player.buffTime[buffIndex] = 6666666;
		}
	}
}
