using System;
using Archeon.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Buffs.Debuffs
{
	public class ShadoniumDebuff : ModBuff
	{
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "Archeon/Buffs/Debuffs/SmileDebuff";
			return base.Autoload(ref name, ref texture);
		}
		
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Shadow's Bite");
			Description.SetDefault("You're being corrupted from the inside out");
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<ModGlobalNPC>().ShadoniumDebuff = true;
			
			for (int i = 0; i < 3; i++)
			{
				if(Main.rand.Next(1) == 0)
				{ 				
					int num = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 1f), npc.width + 1, npc.height + 2, 100, npc.velocity.X * 0.5f, npc.velocity.Y * 0.4f, 64, default(Color), 1.2f);
					Main.dust[num].noGravity = true;
					Main.dust[num].scale = 0.95f;
					Main.dust[num].color = Color.Indigo;
				}
			
				if(Main.rand.Next(2) == 0)
				{
					int num168 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 1f), npc.width + 1, npc.height + 2, 112, npc.velocity.X * 0.5f, npc.velocity.Y * 0.4f, 64, default(Color), 1.2f);
					Main.dust[num168].noGravity = true;
					Main.dust[num168].color = Color.Purple;
					
					int num = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 1f), npc.width + 1, npc.height + 2, 157, npc.velocity.X * 0.5f, npc.velocity.Y * 0.4f, 64, default(Color), 1.2f);
					Main.dust[num].noGravity = true;
					Main.dust[num].color = Color.Black;
				}
			}
		}
	}
}
