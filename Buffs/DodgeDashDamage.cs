using System;
using Archeon.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Buffs
{
	// Token: 0x02000024 RID: 36
	public class DodgeDashDamage : ModBuff
	{
		// Token: 0x0600009F RID: 159 RVA: 0x00005B51 File Offset: 0x00003D51
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "Archeon/Buffs/TANTRUMBUFF";
			return base.Autoload(ref name, ref texture);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00005B62 File Offset: 0x00003D62
		public override void SetDefaults()
		{
			base.DisplayName.SetDefault("Fragility");
			base.Description.SetDefault("Your defense is cut in half");
			this.longerExpertDebuff = false;
			this.canBeCleared = false;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00005B84 File Offset: 0x00003D84
		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<MyPlayer>().dodgeDashDamage = true;
			
		}
		
	}
}
