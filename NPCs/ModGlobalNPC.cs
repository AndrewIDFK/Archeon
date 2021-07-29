using System;
using Archeon.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.NPCs
{
	public class ModGlobalNPC : GlobalNPC
	{
		public bool LunarDebuff;
		
		public bool SteeleDebuff;
		
		public bool FireElementDebuff;
		
		public bool AirElementDebuff;
		
		public bool EarthElementDebuff;

		public bool FrostElementDebuff;
		
		public bool cosmicalPoisoning;
		
		public bool DarkMatterDebuff;
		
		public bool VyssoniumPoisoning;
		
		public bool StroidDebuff;
		
		public bool CorrosionDebuff;
		
		public bool ShadoniumDebuff;
		public bool VyssoniumDebuff;
		
		public static int hallowedTwin1 = -1;
		public static int hallowedTwin2 = -1;
		
		
		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}
		public override void ResetEffects(NPC npc)
		{
			cosmicalPoisoning = false;
			LunarDebuff = false;
			SteeleDebuff = false;
			FireElementDebuff = false;
			AirElementDebuff = false;
			EarthElementDebuff = false;
			FrostElementDebuff = false;
			DarkMatterDebuff = false;
			VyssoniumPoisoning = false;
			StroidDebuff = false;
			CorrosionDebuff = false;
			
			ShadoniumDebuff = false;
			VyssoniumDebuff = false;
			
			if (ModGlobalNPC.hallowedTwin1 >= 0 && !Main.npc[ModGlobalNPC.hallowedTwin1].active)
			{
				ModGlobalNPC.hallowedTwin1 = -1;
			}
			if (ModGlobalNPC.hallowedTwin2 >= 0 && !Main.npc[ModGlobalNPC.hallowedTwin2].active)
			{
				ModGlobalNPC.hallowedTwin2 = -1;
			}
		}

		public override void SetDefaults(NPC npc)
		{
			npc.buffImmune[mod.BuffType("CosmicalPoisoning")] = npc.buffImmune[36];
		}
		
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (type == 19 && Main.hardMode)
			{
				shop.item[nextSlot].SetDefaults(164, false);
				shop.item[nextSlot].shopCustomPrice = new int?(65000);
				nextSlot++;
			}
		}

		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			if (LunarDebuff)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 240;
				if (damage < 60)
				{
					damage = 60;
				}
			}
			
			if (SteeleDebuff)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 100;
				if (damage < 10)
				{
					damage = 10;
				}
			}
			
			if (FireElementDebuff)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 180;
				if (damage < 20)
				{
					damage = 20;
				}
			}
			
			if (AirElementDebuff)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 100;
				if (damage < 10)
				{
					damage = 10;
				}
			}
			
			if (EarthElementDebuff)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 90;
				if (damage < 15)
				{
					damage = 15;
				}
			}
			
			if (FrostElementDebuff)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 140;
				if (damage < 15)
				{
					damage = 15;
				}
			}
			
			if (DarkMatterDebuff)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 180;
				if (damage < 40)
				{
					damage = 40;
				}
			}
			
			if (StroidDebuff)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 140;
				if (damage < 14)
				{
					damage = 14;
				}
			}
			
			if (VyssoniumPoisoning)
			{	
				int num69 = Main.hardMode ? 12 : 6;
				
				int num420 = num69 - (npc.defense / 3);
				if (num420 < 0)
				{
					num420 = 0;
				}
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= num420 * 7;
				if (damage < num420)
				{
					damage = num420;
				}
			}
			
			if (CorrosionDebuff)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 100;
				if (damage < 12)
				{
					damage = 12;
				}
			}
			
			if (ShadoniumDebuff)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 55;
				if (damage < 6)
				{
					damage = 6;
				}
			}
			
			if (VyssoniumDebuff)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 40;
				if (damage < 12)
				{
					damage = 12;
				}
			}
		}
		
		public override void DrawEffects(NPC npc, ref Color drawColor)
		{
			if(VyssoniumPoisoning && Main.rand.Next(4) < 2)
			{
				int num9 = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 90, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 2.4f);
				Main.dust[num9].noGravity = true;
				Main.dust[num9].velocity *= 1.15f;
				Dust dust9 = Main.dust[num9];
				dust9.velocity.Y = dust9.velocity.Y + 0.12f;
				if (Main.rand.Next(5) == 0)
				{
					Main.dust[num9].noGravity = false;
					Main.dust[num9].scale *= 0.7f;
				}
			}
		}

		public override void NPCLoot(NPC npc)
		{		
			if (npc.type == 134)
			{
				if (!ArcheonWorld.spawnRockSteele)
				{
					if (Main.netMode == 2)
					{
						NetworkText networkText2 = NetworkText.FromKey("The earth shakes, did something happen underground?", new object[0]);
						NetMessage.BroadcastChatMessage(networkText2, new Color(50, 120, 240), -1);
						NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
					}
					Main.NewText("The earth shakes, did something happen underground?", 50, 120, 240, false);
					for (int j = 0; j < (int)(Main.rockLayer * (double)Main.maxTilesY * 0.002); j++)
					{
						int num3 = Main.rand.Next(0, Main.maxTilesX);
						int num4 = Main.rand.Next((int)Main.rockLayer, Main.maxTilesY - 200);
						WorldGen.OreRunner(num3, num4, (double)Main.rand.Next(4, 6), Main.rand.Next(6, 7), (ushort)mod.TileType("RockSteeleTile"));
					}
				}
				ArcheonWorld.spawnRockSteele = true;
			}
			if (npc.type == 262)
			{
				if (!Main.expertMode)
				{
					if (Main.rand.Next(4) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Plantasmoid"), 1, false, 0, false, false);
					}
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FeralShard"), Main.rand.Next(22, 28), false, 0, false, false);
				}
				else
				{
					if (Main.rand.Next(2) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Plantasmoid"), 1, false, 0, false, false);
					}
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FeralShard"), Main.rand.Next(28, 36), false, 0, false, false);
				}
				if (!ArcheonWorld.slitherHallow)
				{
					if (Main.netMode == 2)
					{
						NetworkText networkText4 = NetworkText.FromKey("Something is slithering in the Hallow...", new object[0]);
						NetMessage.BroadcastChatMessage(networkText4, new Color(237, 128, 224), -1);
						NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
					}
					Main.NewText("Something is slithering in the Hallow...", 237, 128, 224, false);
				}
				ArcheonWorld.slitherHallow = true;
			}
			
			if (npc.type == 245)
			{
				if (!ArcheonWorld.spawnThanite)
				{
					if (Main.netMode == 2)
					{
						NetworkText networkText3 = NetworkText.FromKey("A powerful being has deemed you worthy. The world is snapping with Thanite!", new object[0]);
						NetMessage.BroadcastChatMessage(networkText3, new Color(110, 40, 175), -1);
						NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
					}
					Main.NewText("A powerful being has deemed you worthy. The world is snapping with Thanite!", 110, 40, 175, false);
					for (int k = 0; k < (int)(Main.rockLayer * (double)Main.maxTilesY * 0.0017); k++)
					{
						int num5 = Main.rand.Next(0, Main.maxTilesX);
						int num6 = Main.rand.Next((int)Main.rockLayer, Main.maxTilesY - 200);
						WorldGen.OreRunner(num5, num6, (double)Main.rand.Next(5, 6), Main.rand.Next(5, 6), (ushort)mod.TileType("ThaniteTile"));
					}
				}
				ArcheonWorld.spawnThanite = true;
			}
			
			if(npc.type == 127)
			{
				if (!ArcheonWorld.elementSpawn)
				{
					if (Main.netMode == 2)
					{
						NetworkText networkText = NetworkText.FromKey("You can feel the elements solidifying...", new object[0]);
						NetMessage.BroadcastChatMessage(networkText, new Color(205, 71, 55), -1);
						NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
					}
					Main.NewText("You can feel the elements solidifying...", 205, 71, 55, false);
				}
				ArcheonWorld.elementSpawn = true;
			}
			
			//These things only spawn after Moon Lord Core has been defeated
			if (npc.type == 398)
			{
				//Archer Gloves from Lunatic Cultist Archers, white and blue
				if (npc.type == 379 && Main.rand.Next(15) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ArcherGloves"), 1, false, 0, false, false);
				}
				if (npc.type == 380 && Main.rand.Next(17) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ArcherGloves"), 1, false, 0, false, false);
				}
				
				//Lunar Fragments from Lunatic Cultist Archers, white and blue
				if (npc.type == 379 && Main.rand.Next(21) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LunarFragment"), 1, false, 0, false, false);
				}
				if (npc.type == 380 && Main.rand.Next(22) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LunarFragment"), 1, false, 0, false, false);
				}
			}
			
			//Fire Element/Essence from Hellish Enemies only in Post-Mechs.
			if(npc.type == 127)
			{
				if (npc.type == 60 && Main.rand.Next(20) == 0) //Hell Bat
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FireElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 24 && Main.rand.Next(18) == 0) //Fire Imp
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FireElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 62 && Main.rand.Next(19) == 0) //Demon
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FireElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 66 && Main.rand.Next(17) == 0) //Demon
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FireElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 39 && Main.rand.Next(17) == 0) //Bone Serpent
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FireElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 59 && Main.rand.Next(18) == 0) //Lava Slime
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FireElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 151 && Main.rand.Next(13) == 0) //Lava Bat
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FireElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 156 && Main.rand.Next(5) == 0) //Red Devil
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FireElement"), 1, false, 0, false, false);
				}
			}
			
			//Frost Element/Essence from Freezing Enemies only in Post-Mech.
			if(npc.type == 127)
			{
				if (npc.type == 150 && Main.rand.Next(16) == 0) //Ice Bat
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrostElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 147 && Main.rand.Next(17) == 0) //Ice Slime
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrostElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 184 && Main.rand.Next(16) == 0) //Spiked Ice Slame
				{	
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrostElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 243 && Main.rand.Next(2) == 0) //Ice Golem
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrostElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 169 && Main.rand.Next(8) == 0) //Ice Elemental
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrostElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 154 && Main.rand.Next(10) == 0) //Ice Tortoise
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrostElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 206 && Main.rand.Next(12) == 0) //Icy Merman
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrostElement"), 1, false, 0, false, false);
				}
			}	
			
			//Earth Element/Essence from Burrowing Enemies only in Post-Mech.
			if(npc.type == 127)
			{
				if (npc.type == 10 && Main.rand.Next(11) == 0) //Giant Worm Head
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EarthElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 513 && Main.rand.Next(10) == 0) //Tomb Crawler Head
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EarthElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 510 && Main.rand.Next(8) == 0) //Dune Splicer Head
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EarthElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 95 && Main.rand.Next(10) == 0) //Digger Head
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EarthElement"), 1, false, 0, false, false);
				}
			}
			
			if (npc.type == 412 && Main.rand.Next(6) == 0) //Crawltipede Head (Solar Worm)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EarthElement"), 1, false, 0, false, false);
			}
			
			if (npc.type == 134 && Main.rand.Next(1) == 0) //The Destroyer Head
			{
				if(!Main.expertMode)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EarthElement"), 3, false, 0, false, false);
				}
			}
			
			//Air Element/Essence from Space Fliers in Post-Mech. 
			if(npc.type == 127)
			{
				if (npc.type == 48 && Main.rand.Next(8) == 0) //Harpy
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AirElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 87 && Main.rand.Next(4) == 0) // Wyvern Head
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AirElement"), 1, false, 0, false, false);
				}
			}
		}
	}
}
