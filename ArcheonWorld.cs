using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
using Archeon;
using Archeon.Items;
using System.Linq;

namespace Archeon
{
	public class ArcheonWorld : ModWorld
	{
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
					WorldGen.TileRunner(num, num2, (double)WorldGen.genRand.Next(6, 7), WorldGen.genRand.Next(6, 7), mod.TileType("VyssoniumTile"), true, 0f, 0f, false, true);
				}
			}
			for (int j = 0; j < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0003); j++)
			{
				int num3 = WorldGen.genRand.Next(0, Main.maxTilesX);
				int num4 = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY);
				Tile tileSafely2 = Framing.GetTileSafely(num3, num4);
				if (tileSafely2.active() && tileSafely2.type == 25)
				{
					WorldGen.TileRunner(num3, num4, (double)WorldGen.genRand.Next(6, 7), WorldGen.genRand.Next(6, 7), mod.TileType("ShadoniumTile"), true, 0f, 0f, false, true);
				}
			}
		}

		public override void PostWorldGen()
		{
			int[] array = new int[]
			{
				mod.ItemType("Stormer")
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
	}
}
