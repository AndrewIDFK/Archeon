using System;
using Archeon.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Buffs
{
	// Token: 0x02000023 RID: 35
	public class CorrosionDebuff : ModBuff
	{
		// Token: 0x0600009B RID: 155 RVA: 0x0000589D File Offset: 0x00003A9D
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "Archeon/Buffs/CorrosionDebuff";
			return base.Autoload(ref name, ref texture);
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000058AE File Offset: 0x00003AAE
		public override void SetDefaults()
		{
			base.DisplayName.SetDefault("Corrosion");
			base.Description.SetDefault("Corrodes your insides");
		}

		// Token: 0x0600009D RID: 157 RVA: 0x000058D0 File Offset: 0x00003AD0
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<ModGlobalNPC>().SteeleDebuff = true;
			int num = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 1f), npc.width + 1, npc.height + 2, base.mod.DustType("CorrosiveDust"), npc.velocity.X * 0.5f, npc.velocity.Y * 0.4f, 64, default(Color), 1.2f);
			Main.dust[num].noGravity = true;
			Main.dust[num].scale = 1.45f;
			int num2 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 1f), npc.width + 1, npc.height + 2, base.mod.DustType("CorrosiveDust"), npc.velocity.X * 0.5f, npc.velocity.Y * 0.4f, 64, default(Color), 1.2f);
			Main.dust[num2].noGravity = true;
			Main.dust[num2].scale = 1.42f;
			int num3 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 1f), npc.width + 1, npc.height + 2, base.mod.DustType("CorrosiveDust"), npc.velocity.X * 0.5f, npc.velocity.Y * 0.4f, 64, default(Color), 1.2f);
			Main.dust[num3].noGravity = true;
			Main.dust[num3].scale = 1.49f;
			int num4 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 1f), npc.width + 1, npc.height + 2, base.mod.DustType("CorrosiveDust"), npc.velocity.X * 0.5f, npc.velocity.Y * 0.4f, 64, default(Color), 1.2f);
			Main.dust[num4].noGravity = true;
			Main.dust[num4].scale = 1.52f;
			int num5 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 1f), npc.width + 1, npc.height + 2, base.mod.DustType("CorrosiveDust"), npc.velocity.X * 0.5f, npc.velocity.Y * 0.4f, 64, default(Color), 1.2f);
			Main.dust[num5].noGravity = true;
			Main.dust[num5].scale = 1.55f;
		}
	}
}
