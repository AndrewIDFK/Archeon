using System;
using Archeon.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Buffs
{
	// Token: 0x02000023 RID: 35
	public class DarkMatterDebuff : ModBuff
	{
		// Token: 0x0600009B RID: 155 RVA: 0x0000589D File Offset: 0x00003A9D
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "Archeon/Buffs/DarkMatterDebuff";
			return base.Autoload(ref name, ref texture);
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000058AE File Offset: 0x00003AAE
		public override void SetDefaults()
		{
			base.DisplayName.SetDefault("Dark Matter Infusion");
			base.Description.SetDefault("It's infused with you, killing every cell in your body!");
		}

		// Token: 0x0600009D RID: 157 RVA: 0x000058D0 File Offset: 0x00003AD0
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<ModGlobalNPC>().AirElementDebuff = true;
			int num = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 1f), npc.width + 1, npc.height + 2, base.mod.DustType("DarkMatterDust1"), npc.velocity.X * 0.5f, npc.velocity.Y * 0.4f, 64, default(Color), 1.2f);
			Main.dust[num].noGravity = true;
			Main.dust[num].scale = 1.15f;
			int num2 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 1f), npc.width + 1, npc.height + 2, base.mod.DustType("DarkMatterDust2"), npc.velocity.X * 0.5f, npc.velocity.Y * 0.4f, 64, default(Color), 1.2f);
			Main.dust[num2].noGravity = true;
			Main.dust[num2].scale = 1.15f;

		}
	}
}
