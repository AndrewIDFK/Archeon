using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Buffs
{
	// Token: 0x02000025 RID: 37
	public class PhantasmDragonBuff : ModBuff
	{
		// Token: 0x060000A3 RID: 163 RVA: 0x00005BF3 File Offset: 0x00003DF3
		public override void SetDefaults()
		{
			base.DisplayName.SetDefault("Phantasm Dragon");
			base.Description.SetDefault("Tamed and will now protect you.");
			Main.buffNoSave[base.Type] = true;
			Main.buffNoTimeDisplay[base.Type] = true;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00005C30 File Offset: 0x00003E30
		public override void Update(Player player, ref int buffIndex)
		{
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[base.mod.ProjectileType("PhantasmDragonHead")] > 0 || player.ownedProjectileCounts[base.mod.ProjectileType("PhantasmDragonBody")] > 0)
			{
				modPlayer.PhantasmDragonMinion = true;
			}
			if (!modPlayer.PhantasmDragonMinion)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
				return;
			}
			player.buffTime[buffIndex] = 18000;
		}
	}
}
