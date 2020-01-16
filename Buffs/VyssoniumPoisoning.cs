using System;
using Terraria;
using Archeon.NPCs;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Buffs
{
	// Token: 0x0200001E RID: 30
	public class VyssoniumPoisoning : ModBuff
	{
		// Token: 0x06000088 RID: 136 RVA: 0x00005572 File Offset: 0x00003772
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "Archeon/Buffs/VyssoniumPoisoning";
			return base.Autoload(ref name, ref texture);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00005583 File Offset: 0x00003783
		public override void SetDefaults()
		{
			base.DisplayName.SetDefault("Vyssonium Poisoning");
			base.Description.SetDefault("Your insides are ripping apart!");
		}
		
		// Token: 0x06004AB4 RID: 19124 RVA: 0x0037D6BB File Offset: 0x0037B8BB
		public override void Update(NPC npc, ref int buffIndex)
		{
			
			npc.GetGlobalNPC<ModGlobalNPC>().VyssoniumPoisoning = true;
		}
	}
}
