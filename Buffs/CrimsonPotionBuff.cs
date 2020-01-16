using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Buffs
{
	// Token: 0x02000020 RID: 32
	public class CrimsonPotionBuff : ModBuff
	{
		// Token: 0x06000090 RID: 144 RVA: 0x00005690 File Offset: 0x00003890
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "Archeon/Buffs/CrimsonPotionBuff";
			return base.Autoload(ref name, ref texture);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x000056A1 File Offset: 0x000038A1
		public override void SetDefaults()
		{
			base.DisplayName.SetDefault("Crimtane Power");
			base.Description.SetDefault("Attack with the Power of Crimson!");
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000056C4 File Offset: 0x000038C4
		public override void Update(Player player, ref int buffIndex)
		{
			player.meleeDamage += 0.2f;
			player.magicDamage += 0.2f;
			player.rangedDamage += 0.2f;
			player.thrownDamage += 0.2f;
			player.minionDamage += 0.2f;
		}
	}
}
