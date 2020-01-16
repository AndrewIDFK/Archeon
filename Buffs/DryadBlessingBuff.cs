using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Buffs
{
	// Token: 0x02000021 RID: 33
	public class DryadBlessingBuff : ModBuff
	{
		// Token: 0x06000094 RID: 148 RVA: 0x00005733 File Offset: 0x00003933
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "Archeon/Buffs/DryadBlessingBuff";
			return base.Autoload(ref name, ref texture);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00005744 File Offset: 0x00003944
		public override void SetDefaults()
		{
			base.DisplayName.SetDefault("Dryad Blessing");
			base.Description.SetDefault("Dryad wards you!");
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00005766 File Offset: 0x00003966
		public override void Update(Player player, ref int buffIndex)
		{
			player.statDefense += 8;
			player.lifeRegen += 6;
			if (player.thorns < 1f)
			{
				player.thorns += 0.2f;
			}
		}
	}
}
