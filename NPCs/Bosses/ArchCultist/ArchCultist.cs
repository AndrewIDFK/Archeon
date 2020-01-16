using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.NPCs.Bosses.ArchCultist
{
	
	public class ArchCultist : ModNPC
	{
		
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Arch Cultist");
			Main.npcFrameCount[base.npc.type] = Main.npcFrameCount[439];
		}

		
		public override void SetDefaults()
		{
			base.npc.CloneDefaults(439);
			this.aiType = 439;
			base.npc.lifeMax = 12000;
			base.npc.damage = 111;
			base.npc.defense = 46;
			base.npc.knockBackResist = 0f;
			base.npc.width = 50;
			base.npc.height = 60;
			this.animationType = 439;
			base.npc.value = (float)Item.buyPrice(0, 3, 75, 45);
			base.npc.lavaImmune = true;
			base.npc.noGravity = true;
			base.npc.noTileCollide = true;
			base.npc.HitSound = SoundID.NPCHit53;
			base.npc.DeathSound = SoundID.NPCDeath43;
			base.npc.buffImmune[24] = true;
			base.npc.netAlways = true;
			base.npc.boss = false;
		}

	
		public override void NPCLoot()
		{
			Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("LunarFragment"), Main.rand.Next(4, 11), false, 0, false, false);
			
			Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, 3460, Main.rand.Next(1, 7), false, 0, false, false);
		}

		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			base.npc.lifeMax = (int)((float)base.npc.lifeMax * bossLifeScale);
			base.npc.damage = (int)((float)base.npc.damage * 0.89f);
		}

		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			scale = 1.15f;
			return null;
		}

		
		public override void HitEffect(int hitDirection, double damage)
		{
			if (base.npc.life <= 0)
			{
				for (int i = 0; i < 7; i++)
				{
					int num = Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, base.mod.DustType("LunarDust"), 0f, 0f, 0, default(Color), 1f);
					Dust dust = Main.dust[num];
					dust.velocity.X = dust.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust.velocity.Y = dust.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust.scale *= 1.8f + (float)Main.rand.Next(-31, 31) * 0.01f;
				}
			}
		}
	}
}
