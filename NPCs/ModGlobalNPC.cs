using System;
using Archeon.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.NPCs
{
	// Token: 0x020000C5 RID: 197
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
		
		public static int hallowedTwin1 = -1;

		// Token: 0x040003EF RID: 1007
		public static int hallowedTwin2 = -1;
		
		
		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000389 RID: 905 RVA: 0x0001D7A7 File Offset: 0x0001B9A7
		public override void ResetEffects(NPC npc)
		{
			this.cosmicalPoisoning = false;
			this.LunarDebuff = false;
			this.SteeleDebuff = false;
			this.FireElementDebuff = false;
			this.AirElementDebuff = false;
			this.EarthElementDebuff = false;
			this.FrostElementDebuff = false;
			this.DarkMatterDebuff = false;
			this.VyssoniumPoisoning = false;
			this.StroidDebuff = false;
			this.CorrosionDebuff = false;
			
			if (ModGlobalNPC.hallowedTwin1 >= 0 && !Main.npc[ModGlobalNPC.hallowedTwin1].active)
			{
				ModGlobalNPC.hallowedTwin1 = -1;
			}
			if (ModGlobalNPC.hallowedTwin2 >= 0 && !Main.npc[ModGlobalNPC.hallowedTwin2].active)
			{
				ModGlobalNPC.hallowedTwin2 = -1;
			}
		}

		// Token: 0x0600038A RID: 906 RVA: 0x0001D7B7 File Offset: 0x0001B9B7
		public override void SetDefaults(NPC npc)
		{
			//npc.buffImmune[Mod.BuffType<Buffs.CosmicalPoisoning>] = npc.buffImmune[36];
			npc.buffImmune[BuffType<Buffs.CosmicalPoisoning>()] = npc.buffImmune[36];
		}

		
		/*public override bool PreNPCLoot(NPC npc)
		{
			if (npc.type == 262)
			{
				NPCLoader.blockLoot.Add(1141);
			}
			return true;
		}*/

		
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (type == 19 && Main.hardMode)
			{
				shop.item[nextSlot].SetDefaults(164, false);
				shop.item[nextSlot].shopCustomPrice = new int?(65000);
				nextSlot++;
			}
		}

		// Token: 0x0600038D RID: 909 RVA: 0x0001D833 File Offset: 0x0001BA33
		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			if (this.LunarDebuff)
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
			
			if (this.SteeleDebuff)
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
			
			if (this.FireElementDebuff)
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
			
			if (this.AirElementDebuff)
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
			
			if (this.EarthElementDebuff)
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
			
			if (this.FrostElementDebuff)
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
			
			if (this.DarkMatterDebuff)
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
			
			if (this.StroidDebuff)
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
			
			if (this.VyssoniumPoisoning)
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
			
			if (this.CorrosionDebuff)
			{
				
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 5;
				if (damage < 5)
				{
					damage = 5;
				}
			}
		}
		
		public override void DrawEffects(NPC npc, ref Color drawColor)
		{
			if(this.VyssoniumPoisoning && Main.rand.Next(4) < 2)
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
			/*if (npc.type == 113)
			{
				if (!ArcheonWorld.spawnOre2)
				{
					if (Main.netMode == 2)
					{
						NetworkText networkText = NetworkText.FromKey("Powerful energy is resonating in the Underworld", new object[0]);
						NetMessage.BroadcastChatMessage(networkText, new Color(200, 50, 100), -1);
						NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
					}
					Main.NewText("Powerful energy is resonating in the Underworld", 200, 50, 100, false);
					for (int i = 0; i < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 5E-05); i++)
					{
						int num = Main.rand.Next(0, Main.maxTilesX);
						int num2 = Main.rand.Next(Main.maxTilesY - 200, Main.maxTilesY);
						Tile tileSafely = Framing.GetTileSafely(num, num2);
						if (tileSafely.active() && tileSafely.type == 57)
						{
							WorldGen.OreRunner(num, num2, (double)Main.rand.Next(5, 7), Main.rand.Next(5, 9), (ushort)base.mod.TileType("PlasmiteTile"));
						}
					}
				}
				ArcheonWorld.spawnOre2 = true;
			}*/
			if (npc.type == 134)
			{
				if (!ArcheonWorld.spawnOre3)
				{
					if (Main.netMode == 2)
					{
						NetworkText networkText2 = NetworkText.FromKey("You have been blessed with some kind of Metal", new object[0]);
						NetMessage.BroadcastChatMessage(networkText2, new Color(50, 120, 240), -1);
						NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
					}
					Main.NewText("You have been blessed with some kind of Metal", 50, 120, 240, false);
					for (int j = 0; j < (int)(Main.rockLayer * (double)Main.maxTilesY * 0.0019); j++)
					{
						int num3 = Main.rand.Next(0, Main.maxTilesX);
						int num4 = Main.rand.Next((int)Main.rockLayer, Main.maxTilesY - 200);
						WorldGen.OreRunner(num3, num4, (double)Main.rand.Next(4, 6), Main.rand.Next(6, 7), (ushort)base.mod.TileType("RockSteeleTile"));
					}
				}
				ArcheonWorld.spawnOre3 = true;
			}
			if (npc.type == 262)
			{
				if (!Main.expertMode)
				{
					if (Main.rand.Next(3) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("Plantasmoid"), 1, false, 0, false, false);
					}
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("FeralShard"), Main.rand.Next(22, 32), false, 0, false, false);
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
				if (!ArcheonWorld.spawnOre4)
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
						WorldGen.OreRunner(num5, num6, (double)Main.rand.Next(5, 6), Main.rand.Next(5, 6), (ushort)base.mod.TileType("ThaniteTile"));
					}
				}
				ArcheonWorld.spawnOre4 = true;
			}
			
			/*int tGood = WorldGen.tGood;
			if (tGood <= 0)
			{
				if (!ArcheonWorld.worldPure)
				{
					if (Main.netMode == 2)
					{
						NetworkText networkText2 = NetworkText.FromKey("The Dryad has something to sell you for your hard work!", new object[0]);
						NetMessage.BroadcastChatMessage(networkText2, new Color(50, 195, 70), -1);
						NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
					}
					Main.NewText("The Dryad has something to sell you for your hard work!", 50, 195, 70, false);
				}
				ArcheonWorld.worldPure = true;
			}*/
			
			/*if (WorldGen.crimson)
			{
				if (tile.type != 203)
				{
					if (Main.netMode == 2)
					{
						NetworkText networkText2 = NetworkText.FromKey("TEST BOIS", new object[0]);
						NetMessage.BroadcastChatMessage(networkText2, new Color(50, 120, 240), -1);
						NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
					}
					Main.NewText("TESTBOIS", 50, 120, 240, false);
				}
			}*/
			
			if(npc.type == 127)
			{
				if (!ArcheonWorld.elementSpawn)
				{
					if (Main.netMode == 2)
					{
						NetworkText networkText = NetworkText.FromKey("The Elements have gone Bump in the Night", new object[0]);
						NetMessage.BroadcastChatMessage(networkText, new Color(205, 71, 55), -1);
						NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
					}
					Main.NewText("The Elements have gone Bump in the Night", 205, 71, 55, false);
				}
				ArcheonWorld.elementSpawn = true;
			}
			
			//These things only spawn after Moon Lord Core has been defeated
			if (npc.type == 398)
			{
				//Archer Gloves from Lunatic Cultist Archers, white and blue
				if (npc.type == 379 && Main.rand.Next(15) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("ArcherGloves"), 1, false, 0, false, false);
				}
				if (npc.type == 380 && Main.rand.Next(17) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("ArcherGloves"), 1, false, 0, false, false);
				}
				
				//Lunar Fragments from Lunatic Cultist Archers, white and blue
				if (npc.type == 379 && Main.rand.Next(21) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("LunarFragment"), 1, false, 0, false, false);
				}
				if (npc.type == 380 && Main.rand.Next(22) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("LunarFragment"), 1, false, 0, false, false);
				}
			}
			
			//Fire Element/Essence from Hellish Enemies only in Post-Mechs. ADD A NEW ENEMY AND THEN PUT IT HERE ASWELL.
			if(npc.type == 127)
			{
				if (npc.type == 60 && Main.rand.Next(20) == 0) //Hell Bat
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("FireElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 24 && Main.rand.Next(18) == 0) //Fire Imp
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("FireElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 62 && Main.rand.Next(19) == 0) //Demon
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("FireElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 66 && Main.rand.Next(17) == 0) //Demon
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("FireElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 39 && Main.rand.Next(17) == 0) //Bone Serpent
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("FireElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 59 && Main.rand.Next(18) == 0) //Lava Slime
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("FireElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 151 && Main.rand.Next(13) == 0) //Lava Bat
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("FireElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 156 && Main.rand.Next(5) == 0) //Red Devil
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("FireElement"), 1, false, 0, false, false);
				}
			}
			
			//Frost Element/Essence from Freezing Enemies only in Post-Mech. ADD A NEW ENEMY AND THEN PUT IT HERE ASWELL.
			if(npc.type == 127)
			{
				if (npc.type == 150 && Main.rand.Next(16) == 0) //Ice Bat
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("FrostElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 147 && Main.rand.Next(17) == 0) //Ice Slime
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("FrostElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 184 && Main.rand.Next(16) == 0) //Spiked Ice Slame
				{	
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("FrostElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 243 && Main.rand.Next(2) == 0) //Ice Golem
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("FrostElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 169 && Main.rand.Next(8) == 0) //Ice Elemental
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("FrostElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 154 && Main.rand.Next(10) == 0) //Ice Tortoise
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("FrostElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 206 && Main.rand.Next(12) == 0) //Icy Merman
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("FrostElement"), 1, false, 0, false, false);
				}
			}	
			
			//Earth Element/Essence from Burrowing Enemies only in Post-Mech. ADD A NEW ENEMY AND PUT IT HERE ASWELL.
			if(npc.type == 127)
			{
				if (npc.type == 10 && Main.rand.Next(11) == 0) //Giant Worm Head
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("EarthElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 513 && Main.rand.Next(10) == 0) //Tomb Crawler Head
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("EarthElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 510 && Main.rand.Next(8) == 0) //Dune Splicer Head
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("EarthElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 95 && Main.rand.Next(10) == 0) //Digger Head
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("EarthElement"), 1, false, 0, false, false);
				}
			}
			
			if (npc.type == 412 && Main.rand.Next(6) == 0) //Crawltipede Head (Solar Worm)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("EarthElement"), 1, false, 0, false, false);
			}
			
			if (npc.type == 134 && Main.rand.Next(1) == 0) //The Destroyer Head
			{
				if(!Main.expertMode)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("EarthElement"), 3, false, 0, false, false);
				}
			}
			
			//Air Element/Essence from Space Fliers in Post-Mech. 
			if(npc.type == 127)
			{
				if (npc.type == 48 && Main.rand.Next(8) == 0) //Harpy
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("AirElement"), 1, false, 0, false, false);
				}
				
				if (npc.type == 87 && Main.rand.Next(4) == 0) // Wyvern Head
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("AirElement"), 1, false, 0, false, false);
				}
			}
		}
	}
}
