using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Buffs
{
	// Token: 0x0200001E RID: 30
	public class VyssoniumArmorMeleeSpeed : ModBuff
	{
		// Token: 0x06000088 RID: 136 RVA: 0x00005572 File Offset: 0x00003772
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "Archeon/Buffs/VyssoniumArmorMeleeSpeed";
			return base.Autoload(ref name, ref texture);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00005583 File Offset: 0x00003783
		public override void SetDefaults()
		{
			base.DisplayName.SetDefault("Scarlet Melee Speed Boost");
			base.Description.SetDefault("Swing significantly faster!");
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000055A5 File Offset: 0x000037A5
		public override void Update(Player player, ref int buffIndex)
		{
			player.meleeSpeed += 0.25f;
		}
	}
}
