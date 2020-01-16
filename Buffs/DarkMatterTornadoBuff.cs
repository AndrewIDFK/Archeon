using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Buffs
{
	// Token: 0x02000DD3 RID: 3539
	public class DarkMatterTornadoBuff : ModBuff
	{
		// Token: 0x06004B61 RID: 19297 RVA: 0x0037F424 File Offset: 0x0037D624
		public override void SetDefaults()
		{
			base.DisplayName.SetDefault("Shadow's Cyclone");
			base.Description.SetDefault("The Shadow's Cyclones will Unleash Carnage");
			Main.buffNoTimeDisplay[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
		}

		// Token: 0x06004B62 RID: 19298 RVA: 0x0037F460 File Offset: 0x0037D660
		public override void Update(Player player, ref int buffIndex)
		{
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[base.mod.ProjectileType("DarkMatterTornado1")] > 0)
			{
				modPlayer.DarkMatterTornado = true;
			}
			if (!modPlayer.DarkMatterTornado)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
				return;
			}
			player.buffTime[buffIndex] = 18000;
		}
	}
}
