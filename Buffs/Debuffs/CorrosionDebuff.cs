using System;
using Archeon.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Buffs.Debuffs
{
	public class CorrosionDebuff : ModBuff
	{
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "Archeon/Buffs/Debuffs/SmileDebuff";
			return base.Autoload(ref name, ref texture);
		}
		
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Corrosion");
			Description.SetDefault("Corrodes your insides");
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<ModGlobalNPC>().CorrosionDebuff = true;
			for (int i = 0; i < 3; i++)
			{
				int dust = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 1f), npc.width + 1, npc.height + 2, mod.DustType("CorrosiveDust"), npc.velocity.X * 0.5f, npc.velocity.Y * 0.4f, 64, default(Color), 1.2f);
				Main.dust[dust].scale = 1.3f;
			}
		}
	}
}
