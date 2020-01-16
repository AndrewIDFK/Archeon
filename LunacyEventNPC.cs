using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace Archeon
{
	public class LunacyEventNPC : GlobalNPC
	{	
		public override void EditSpawnPool(IDictionary< int, float > pool, NPCSpawnInfo spawnInfo)
        {
			//If the custom invasion is up and the invasion has reached the spawn pos
            if(ArcheonWorld.LunacyEventUp && (Main.invasionX == (double)Main.spawnTileX))
            {
                pool.Clear();
				if(NPC.downedMoonlord)
				{
					if(Main.rand.Next(7) > 5)
					{
						foreach(int i in LunacyEvent.BossInvaders)
						{
							pool.Add(i, 1f);
						}
					}
					else
					{
						foreach(int i in LunacyEvent.invaders)
						{
							pool.Add(i, 6f);
						}
					}
				}
				else
				{	
					
					foreach(int i in LunacyEvent.invaders)
					{
						pool.Add(i, 6f);
					}
				}
            }
		}
		
		public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
		{
			//Change spawn stuff if invasion up and invasion at spawn
			if(ArcheonWorld.LunacyEventUp && (Main.invasionX == (double)Main.spawnTileX))
			{
				spawnRate = 85;
				maxSpawns = 130;
			}
		}
		
		public override void PostAI(NPC npc)
		{
			//Changes NPCs so they do not despawn when invasion up and invasion at spawn
			if(ArcheonWorld.LunacyEventUp && (Main.invasionX == (double)Main.spawnTileX))
			{
				npc.timeLeft = 1000;
			}
		}
		
		public override void NPCLoot(NPC npc)
		{
			//When an NPC (from the invasion list) dies, add progress by decreasing size
			if(ArcheonWorld.LunacyEventUp)
			{
				int[] FullList = LunacyEvent.GetFullInvaderList();
				foreach(int invader in FullList)
				{
					if(npc.type == invader)
					{
						Main.invasionSize -= 1;
					}
				}
			}
		}
	}
}