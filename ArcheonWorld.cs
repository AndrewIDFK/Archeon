using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using Archeon.Tiles;
using Archeon;
using Archeon.Items;
using Archeon.NPCs;
using System.Linq;

namespace Archeon
{
	public class ArcheonWorld : ModWorld
	{
		private const int saveVersion = 0;
		public static int StroidBiome;
		public static bool spawnOre;
		public static bool spawnOre2;
		public static bool spawnOre3;
		public static bool spawnOre4;
		public static bool slitherHallow;
		public static bool elementSpawn;
		public static bool worldPure;
		public static bool spawnComet;
		public static bool downedHallowedOne;
		public static bool LunacyEventUp = false;
		public static bool downedLunacyEvent = false;
		
		
		//public static bool CraftingUnlock;

		
		public override void Initialize()
		{
			Main.invasionSize = 0;
			ArcheonWorld.LunacyEventUp = false;
			ArcheonWorld.downedLunacyEvent = false;
			ArcheonWorld.spawnOre = false;
			ArcheonWorld.spawnOre2 = false;
			ArcheonWorld.spawnOre3 = false;
			ArcheonWorld.spawnOre4 = false;
			ArcheonWorld.slitherHallow = false;
			ArcheonWorld.elementSpawn = false;
			ArcheonWorld.worldPure = false;
			ArcheonWorld.spawnComet = false;
			ArcheonWorld.downedHallowedOne = false;
			

			//ArcheonWorld.CraftingUnlock = false;
		}

		public override TagCompound Save()
		{
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			
			
			if (ArcheonWorld.downedHallowedOne)
			{
				list2.Add("downedHallowedOne");
			}
			if (ArcheonWorld.downedLunacyEvent)
			{
				list2.Add("LunacyEvent");
			}
			if (ArcheonWorld.worldPure)
			{
				list2.Add("worldPure");
			}
			if (ArcheonWorld.spawnOre)
			{
				list.Add("spawnOre");
			}
			if (ArcheonWorld.spawnOre2)
			{
				list.Add("spawnOre2");
			}
			if (ArcheonWorld.spawnOre3)
			{
				list.Add("spawnOre3");
			}
			if (ArcheonWorld.spawnOre4)
			{
				list.Add("spawnOre4");
			}
			if (ArcheonWorld.slitherHallow)
			{
				list.Add("slitherHallow");
			}
			if (ArcheonWorld.elementSpawn)
			{
				list.Add("elementSpawn");
			}
			if (ArcheonWorld.spawnComet)
			{
				list.Add("spawnComet");
			}
		
			
			
			TagCompound tagCompound = new TagCompound();
			tagCompound.Add("spawned", list);
			tagCompound.Add("downed", list2);
			return tagCompound;
		}

		public override void Load(TagCompound tag)
		{
			IList<string> list = tag.GetList<string>("spawned");
			IList<string> list2 = tag.GetList<string>("downed");
			IList<string> list3 = tag.GetList<string>("summoned");
			ArcheonWorld.spawnOre = list.Contains("spawnOre");
			ArcheonWorld.spawnOre2 = list.Contains("spawnOre2");
			ArcheonWorld.spawnOre3 = list.Contains("spawnOre3");
			ArcheonWorld.spawnOre4 = list.Contains("spawnOre4");
			ArcheonWorld.spawnComet = list.Contains("spawnComet");
			ArcheonWorld.elementSpawn = list.Contains("elementSpawn");
			ArcheonWorld.slitherHallow = list.Contains("slitherHallow");
			ArcheonWorld.downedHallowedOne = list2.Contains("downedHallowedOne");
			ArcheonWorld.worldPure = list2.Contains("worldPure");	
			ArcheonWorld.downedLunacyEvent = list2.Contains("LunacyEvent");
			
			
			//ArcheonWorld.worldPure = list2.Contains("CraftingUnlock");
		}

		
		public override void LoadLegacy(BinaryReader reader)
		{
			int loadVersion = reader.ReadInt32();
			if (loadVersion == 0)
			{
				BitsByte flags = reader.ReadByte();
				BitsByte flags2 = reader.ReadByte();
				ArcheonWorld.spawnOre = flags[0];
				ArcheonWorld.spawnOre2 = flags[1];
				ArcheonWorld.spawnOre3 = flags[2];
				ArcheonWorld.spawnOre4 = flags[3];
				ArcheonWorld.spawnComet = flags[4];
				ArcheonWorld.downedHallowedOne = flags[5];
				ArcheonWorld.elementSpawn = flags[6];
				ArcheonWorld.slitherHallow = flags2[0];
				//ArcheonWorld.CraftingUnlock = flags[6];
				//ArcheonWorld.ReaperSummoned = reader.ReadByte()[0];
			}
		}

		public override void NetSend(BinaryWriter writer)
		{
			BitsByte flags = new BitsByte();
			BitsByte flags2 = new BitsByte();
			flags[0] = ArcheonWorld.spawnOre;
			flags[1] = ArcheonWorld.spawnOre2;
			flags[2] = ArcheonWorld.spawnOre3;
			flags[3] = ArcheonWorld.spawnOre4;
			flags[4] = ArcheonWorld.spawnComet;
			flags[5] = ArcheonWorld.downedHallowedOne;
			//flags[6] = ArcheonWorld.downedLunacyEvent;
			//flags[6] = ArcheonWorld.worldPure;
			flags[6] = ArcheonWorld.elementSpawn;
			
			flags2[0] = ArcheonWorld.slitherHallow;
			
			
			//flags[7] = ArcheonWorld.CraftingUnlock;
			
			
			writer.Write(flags);
			writer.Write(flags2);
			
		}

		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			BitsByte flags2 = reader.ReadByte();
			ArcheonWorld.spawnOre = flags[0];
			ArcheonWorld.spawnOre2 = flags[1];
			ArcheonWorld.spawnOre3 = flags[2];
			ArcheonWorld.spawnOre4 = flags[3];
			ArcheonWorld.spawnComet = flags[4];
			ArcheonWorld.downedHallowedOne = flags[5];
			//ArcheonWorld.downedLunacyEvent = flags[6];
			//ArcheonWorld.worldPure = flags[6];
			ArcheonWorld.elementSpawn = flags[6];
			ArcheonWorld.slitherHallow = flags[0];
			
			
			//ArcheonWorld.CraftingUnlock = flags[7];
		}

		public override void ResetNearbyTileEffects()
		{
			Main.LocalPlayer.GetModPlayer<MyPlayer>();
			ArcheonWorld.StroidBiome = 0;
		}

		public override void TileCountsAvailable(int[] tileCounts)
		{
			ArcheonWorld.StroidBiome = tileCounts[base.mod.TileType("StroidTile")];
		}

		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			int num = tasks.FindIndex((GenPass genpass) => genpass.Name.Equals("Final Cleanup"));
			if (num != -1)
			{
				tasks.Insert(num + 1, new PassLegacy("Generating The Evil", new WorldGenLegacyMethod(this.ArcheonOres)));
			}
		}

		private void ArcheonOres(GenerationProgress progress)
		{
			
			progress.Message = "Generating the Evil";
			for (int i = 0; i < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0003); i++)
			{
				int num = WorldGen.genRand.Next(0, Main.maxTilesX);
				int num2 = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY);
				Tile tileSafely = Framing.GetTileSafely(num, num2);
				if (tileSafely.active() && tileSafely.type == 203)
				{
					WorldGen.TileRunner(num, num2, (double)WorldGen.genRand.Next(6, 7), WorldGen.genRand.Next(6, 7), base.mod.TileType("VyssoniumTile"), true, 0f, 0f, false, true);
				}
			}
			for (int j = 0; j < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0003); j++)
			{
				int num3 = WorldGen.genRand.Next(0, Main.maxTilesX);
				int num4 = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY);
				Tile tileSafely2 = Framing.GetTileSafely(num3, num4);
				if (tileSafely2.active() && tileSafely2.type == 25)
				{
					WorldGen.TileRunner(num3, num4, (double)WorldGen.genRand.Next(6, 7), WorldGen.genRand.Next(6, 7), base.mod.TileType("ShadoniumTile"), true, 0f, 0f, false, true);
				}
			}
			
			
		}

		public override void PostWorldGen()
		{
			int[] array = new int[]
			{
				base.mod.ItemType("Stormer")
			};
			int num = 0;
			for (int i = 0; i < 6; i++)
			{
				Chest chest = Main.chest[i];
				if (chest != null && Main.tile[chest.x, chest.y].type == 21 && Main.tile[chest.x, chest.y].frameX == 72)
				{
					for (int j = 0; j < 40; j++)
					{
						if (chest.item[j].type == 0)
						{
							chest.item[j].SetDefaults(array[num], false);
							num = (num + 1) % array.Length;
							break;
						}
					}
				}
			}
		}


		public override void PreUpdate()
		{
		}

		public static void DropComet()
		{
			bool flag = true;
			if (Main.netMode == 1)
			{
				return;
			}
			for (int i = 0; i < 255; i++)
			{
				if (Main.player[i].active)
				{
					flag = false;
					break;
				}
			}
			int num = 0;
			float num2 = (float)(Main.maxTilesX / 4200);
			int num3 = (int)(400f * num2);
			for (int j = 5; j < Main.maxTilesX - 5; j++)
			{
				int num4 = 5;
				while ((double)num4 < Main.worldSurface)
				{
					if (Main.tile[j, num4].active() && Main.tile[j, num4].type == (ushort)Archeon.instance.TileType("StroidTile"))
					{
						num++;
						if (num > num3)
						{
							return;
						}
					}
					num4++;
				}
			}
			float num5 = 600f;
			while (!flag)
			{
				float num6 = (float)Main.maxTilesX * 0.08f;
				int num7 = Main.rand.Next(150, Main.maxTilesX - 150);
				while ((float)num7 > (float)Main.spawnTileX - num6 && (float)num7 < (float)Main.spawnTileX + num6)
				{
					num7 = Main.rand.Next(150, Main.maxTilesX - 150);
				}
				int k = (int)(Main.worldSurface * 0.3);
				while (k < Main.maxTilesY)
				{
					if (Main.tile[num7, k].active() && Main.tileSolid[(int)Main.tile[num7, k].type])
					{
						int num8 = 0;
						int num9 = 15;
						for (int l = num7 - num9; l < num7 + num9; l++)
						{
							for (int m = k - num9; m < k + num9; m++)
							{
								if (WorldGen.SolidTile(l, m))
								{
									num8++;
									if (Main.tile[l, m].type == 189 || Main.tile[l, m].type == 202)
									{
										num8 -= 100;
									}
								}
								else if (Main.tile[l, m].liquid > 0)
								{
									num8--;
								}
							}
						}
						if ((float)num8 < num5)
						{
							num5 -= 0.5f;
							break;
						}
						flag = ArcheonWorld.Comet(num7, k);
						if (flag)
						{
							break;
						}
						break;
					}
					else
					{
						k++;
					}
				}
				if (num5 < 100f)
				{
					return;
				}
			}
		}

		public static bool Comet(int i, int j)
		{
			if (i < 50 || i > Main.maxTilesX - 32)
			{
				return false;
			}
			if (j < 50 || j > Main.maxTilesY - 32)
			{
				return false;
			}
			int num = 35;
			Rectangle rectangle = new Rectangle((i - num) * 13, (j - num) * 15, num * 3 * 16, num * 3 * 16);
			for (int k = 0; k < 255; k++)
			{
				if (Main.player[k].active)
				{
					Rectangle value = new Rectangle((int)(Main.player[k].position.X + (float)(Main.player[k].width / 2) - (float)(NPC.sWidth / 2) - (float)NPC.safeRangeX), (int)(Main.player[k].position.Y + (float)(Main.player[k].height / 2) - (float)(NPC.sHeight / 2) - (float)NPC.safeRangeY), NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);
					if (rectangle.Intersects(value))
					{
						return false;
					}
				}
			}
			for (int l = 0; l < 200; l++)
			{
				if (Main.npc[l].active)
				{
					Rectangle value2 = new Rectangle((int)Main.npc[l].position.X, (int)Main.npc[l].position.Y, Main.npc[l].width, Main.npc[l].height);
					if (rectangle.Intersects(value2))
					{
						return false;
					}
				}
			}
			for (int m = i - num; m < i + num; m++)
			{
				for (int n = j - num; n < j + num; n++)
				{
					if (Main.tile[m, n].active() && Main.tile[m, n].type == 21)
					{
						return false;
					}
				}
			}
			num = WorldGen.genRand.Next(19, 22);
			for (int num2 = i - num; num2 < i + num; num2++)
			{
				for (int num3 = j - num; num3 < j + num; num3++)
				{
					if (num3 > j + Main.rand.Next(-2, 3) - 5)
					{
						float num4 = (float)Math.Abs(i - num2);
						float num5 = (float)Math.Abs(j - num3);
						float num6 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
						if ((double)num6 < (double)num * 0.95 + (double)Main.rand.Next(-12, 13))
						{
							if (!Main.tileSolid[(int)Main.tile[num2, num3].type])
							{
								Main.tile[num2, num3].active(false);
							}
							Main.tile[num2, num3].type = (ushort)Archeon.instance.TileType("StroidTile");
						}
					}
				}
			}
			num = WorldGen.genRand.Next(12, 19);
			for (int num7 = i - num; num7 < i + num; num7++)
			{
				for (int num8 = j - num; num8 < j + num; num8++)
				{
					if (num8 > j + Main.rand.Next(-2, 5) - 4)
					{
						float num9 = (float)Math.Abs(i - num7);
						float num10 = (float)Math.Abs(j - num8);
						float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
						if ((double)num11 < (double)num * 0.9 + (double)Main.rand.Next(-5, 8))
						{
							Main.tile[num7, num8].active(false);
						}
					}
				}
			}
			num = WorldGen.genRand.Next(26, 33);
			for (int num12 = i - num; num12 < i + num; num12++)
			{
				for (int num13 = j - num; num13 < j + num; num13++)
				{
					float num14 = (float)Math.Abs(i - num12);
					float num15 = (float)Math.Abs(j - num13);
					float num16 = (float)Math.Sqrt((double)(num14 * num14 + num15 * num15));
					if ((double)num16 < (double)num * 0.9)
					{
						if (Main.tile[num12, num13].type == 5 || Main.tile[num12, num13].type == 32 || Main.tile[num12, num13].type == 352)
						{
							WorldGen.KillTile(num12, num13, false, false, false);
						}
						Main.tile[num12, num13].liquid = 0;
					}
					if (Main.tile[num12, num13].type == (ushort)Archeon.instance.TileType("StroidTile"))
					{
						if (!WorldGen.SolidTile(num12 - 1, num13) && !WorldGen.SolidTile(num12 + 1, num13) && !WorldGen.SolidTile(num12, num13 - 1) && !WorldGen.SolidTile(num12, num13 + 1))
						{
							Main.tile[num12, num13].active(false);
						}
						else if ((Main.tile[num12, num13].halfBrick() || Main.tile[num12 - 1, num13].topSlope()) && !WorldGen.SolidTile(num12, num13 + 1))
						{
							Main.tile[num12, num13].active(false);
						}
					}
					WorldGen.SquareTileFrame(num12, num13, true);
					WorldGen.SquareWallFrame(num12, num13, true);
				}
			}
			num = WorldGen.genRand.Next(24, 30);
			for (int num17 = i - num; num17 < i + num; num17++)
			{
				for (int num18 = j - num; num18 < j + num; num18++)
				{
					if (num18 > j + WorldGen.genRand.Next(-3, 4) - 3 && Main.tile[num17, num18].active() && Main.rand.Next(10) == 0)
					{
						float num19 = (float)Math.Abs(i - num17);
						float num20 = (float)Math.Abs(j - num18);
						float num21 = (float)Math.Sqrt((double)(num19 * num19 + num20 * num20));
						if ((double)num21 < (double)num * 0.98)
						{
							if (Main.tile[num17, num18].type == 5 || Main.tile[num17, num18].type == 32 || Main.tile[num17, num18].type == 352)
							{
								WorldGen.KillTile(num17, num18, false, false, false);
							}
							Main.tile[num17, num18].type = (ushort)Archeon.instance.TileType("StroidTile");
							WorldGen.SquareTileFrame(num17, num18, true);
						}
					}
				}
			}
			num = WorldGen.genRand.Next(24, 30);
			for (int num22 = i - num; num22 < i + num; num22++)
			{
				for (int num23 = j - num; num23 < j + num; num23++)
				{
					if (num23 > j + WorldGen.genRand.Next(-2, 5) && Main.tile[num22, num23].active() && Main.rand.Next(20) == 0)
					{
						float num24 = (float)Math.Abs(i - num22);
						float num25 = (float)Math.Abs(j - num23);
						float num26 = (float)Math.Sqrt((double)(num24 * num24 + num25 * num25));
						if ((double)num26 < (double)num * 0.95)
						{
							if (Main.tile[num22, num23].type == 5 || Main.tile[num22, num23].type == 32 || Main.tile[num22, num23].type == 450)
							{
								WorldGen.KillTile(num22, num23, false, false, false);
							}
							Main.tile[num22, num23].type = (ushort)Archeon.instance.TileType("StroidTile");
							WorldGen.SquareTileFrame(num22, num23, true);
						}
					}
				}
			}
			return true;
		}

		public override void PostUpdate()
		{
			
			if (ArcheonWorld.LunacyEventUp)
			{
				if (Main.invasionX == (double)Main.spawnTileX)
				{
					LunacyEvent.CheckLunacyEventProgress();
				}
				LunacyEvent.UpdateLunacyEvent();
			}
		}

	}
}
