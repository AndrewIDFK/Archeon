using System;
using Archeon.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Buffs.Debuffs
{
	public class MarkOfCainDebuff : ModBuff
	{
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "Archeon/Buffs/Debuffs/MarkOfCainDebuff";
			return base.Autoload(ref name, ref texture);
		}
		
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Hunger of The Mark");
			Description.SetDefault("The Mark is starving for blood");
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			for (int i = 0; i < 2; i++)
			{
				if(Main.rand.Next(2) == 0)
				{
					int num168 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 1f), npc.width + 1, npc.height + 2, 5, npc.velocity.X * 0.5f, npc.velocity.Y * 0.4f, 64, default(Color), 1.2f);
					Main.dust[num168].noGravity = true;
					Main.dust[num168].color = Color.Red;
				}
			}
		}
	}
}
