using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Buffs
{
	// Token: 0x02000024 RID: 36
	public class OverwhelmingPower : ModBuff
	{
		// Token: 0x0600009F RID: 159 RVA: 0x00005B51 File Offset: 0x00003D51
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "Archeon/Buffs/OverwhelmingPower";
			return base.Autoload(ref name, ref texture);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00005B62 File Offset: 0x00003D62
		public override void SetDefaults()
		{
			base.DisplayName.SetDefault("Overwhelming Power");
			base.Description.SetDefault("Significant damage up!");
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00005B84 File Offset: 0x00003D84
		public override void Update(Player player, ref int buffIndex)
		{
			player.meleeDamage += 0.35f;
			player.magicDamage += 0.35f;
			player.rangedDamage += 0.35f;
			player.thrownDamage += 0.35f;
			player.minionDamage += 0.35f;
		}
	}
}
