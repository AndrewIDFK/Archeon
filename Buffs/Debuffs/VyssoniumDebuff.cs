using System;
using Archeon.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Buffs.Debuffs
{
	public class VyssoniumDebuff : ModBuff
	{
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "Archeon/Buffs/Debuffs/SmileDebuff";
			return base.Autoload(ref name, ref texture);
		}
		
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Boiling Blood");
			Description.SetDefault("You're being corrupted from the inside out");
		}
		
		public override void Update(NPC npc, ref int buffIndex)
		{		
			if(Main.rand.Next(6) == 0)
			{ 				
				int num = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 1f), npc.width + 1, npc.height + 2, 125, npc.velocity.X * 0.5f, npc.velocity.Y * 0.4f, 64, default(Color), 1.2f);
				Main.dust[num].noGravity = true;
				Main.dust[num].scale = 0.95f;
				Main.dust[num].color = Color.Crimson;
			}
		
			if(Main.rand.Next(11) == 0)
			{
				int num168 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 1f), npc.width + 1, npc.height + 2, 114, npc.velocity.X * 0.5f, npc.velocity.Y * 0.4f, 64, default(Color), 1.2f);
				Main.dust[num168].noGravity = true;
				Main.dust[num168].color = Color.Red;
			}
			
		
			if(Main.rand.Next(75) == 69)
			{
				for (int i = 0; i < Main.rand.Next(1, 3); i++)
				{
					float xStuff = Main.rand.Next(-5, 5);
					float yStuff = Main.rand.Next(-5, -4);
					Projectile.NewProjectile(npc.Center.X, npc.position.Y, xStuff, yStuff, mod.ProjectileType("BloodthirstBloodProj"), 18, 0.5f, Main.myPlayer, 0f, 0f);
				}
			}
		}
	}
}
