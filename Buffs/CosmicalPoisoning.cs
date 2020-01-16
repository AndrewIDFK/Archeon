using System;
using Archeon.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Buffs
{
	// Token: 0x0200001F RID: 31
	public class CosmicalPoisoning : ModBuff
	{
		// Token: 0x0600008C RID: 140 RVA: 0x000055BE File Offset: 0x000037BE
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "Archeon/Buffs/CosmicalPoisoning";
			return base.Autoload(ref name, ref texture);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x000055CF File Offset: 0x000037CF
		public override void SetDefaults()
		{
			base.DisplayName.SetDefault("Cosmical Poisoning");
			base.Description.SetDefault("Reduced defense and damage");
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000055F4 File Offset: 0x000037F4
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<ModGlobalNPC>().cosmicalPoisoning = true;
			int num = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 1f), npc.width + 1, npc.height + 2, base.mod.DustType("PlasmaDust1"), npc.velocity.X * 0.5f, npc.velocity.Y * 0.4f, 30, default(Color), 1.2f);
			Main.dust[num].noGravity = true;
		}
	}
}
