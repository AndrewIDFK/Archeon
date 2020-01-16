using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;

namespace Archeon
{
	// Token: 0x02000002 RID: 2
	public class Archeon : Mod
	{
		

		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public Archeon()
		{
			Archeon.instance = this;
			ModProperties properties = default(ModProperties);
			properties.Autoload = true;
			properties.AutoloadGores = true;
			properties.AutoloadSounds = true;
			properties.AutoloadBackgrounds = true;
			base.Properties = properties;
		}





	
		public override void PostSetupContent() {
			// Showcases mod support with Boss Checklist without referencing the mod
			Mod bossChecklist = ModLoader.GetMod("BossChecklist");
			if (bossChecklist != null) {
				bossChecklist.Call("AddBossWithInfo", "The Hallowed One", 10.5f, (Func<bool>)(() => ArcheonWorld.downedHallowedOne), "Use a [i:" + base.ItemType("PrismBait") + "] in the hallowed at night.");
			}
		}

		// Token: 0x06000003 RID: 3 RVA: 0x0000212C File Offset: 0x0000032C
		public override void UpdateMusic(ref int music, ref MusicPriority priority)
		{
			if (Main.myPlayer == -1 || Main.gameMenu || !Main.LocalPlayer.active)
			{
				return;
			}
			if (Main.LocalPlayer.GetModPlayer<MyPlayer>().zoneStroidBiome)
			{
				music = 8;
			}
			if (ArcheonWorld.LunacyEventUp && Main.invasionX == (double)Main.spawnTileX)
			{
				music = 38;
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002198 File Offset: 0x00000398
		public override void AddRecipeGroups()
		{
			RecipeGroup recipeGroup = new RecipeGroup(() => "Gold or Platinum Bar", new int[]
			{
				19,
				706
			});
			RecipeGroup.RegisterGroup("GoldOrPlatinumBar", recipeGroup);
			
			recipeGroup = new RecipeGroup(() => "Adamantite or Titanium Sword", new int[]
			{
				1199,
				482
			});
			RecipeGroup.RegisterGroup("TiorAdSword", recipeGroup);
			
			recipeGroup = new RecipeGroup(() => "Silver or Tungsten Bar", new int[]
			{
				21,
				705
			});
			RecipeGroup.RegisterGroup("SilverOrTungstenBar", recipeGroup);
			
			recipeGroup = new RecipeGroup(() => "Iron or Lead Bar", new int[]
			{
				22,
				704
			});
			RecipeGroup.RegisterGroup("IronOrLeadBar", recipeGroup);
			
			recipeGroup = new RecipeGroup(() => "Demonite or Crimtane Bar", new int[]
			{
				57,
				1257
			});
			RecipeGroup.RegisterGroup("DemoniteOrCrimtaneBar", recipeGroup);
			
			recipeGroup = new RecipeGroup(() => "Corrupt or Crimson Seed", new int[]
			{
				59,
				2171
			});
			RecipeGroup.RegisterGroup("CorruptOrCrimsonSeed", recipeGroup);
			
			recipeGroup = new RecipeGroup(() => "Any Catchable Fish", new int[]
			{
				2303,
				2289,
				2436,
				2317,
				2305,
				2304,
				2313,
				2318,
				2312,
				2306,
				2308,
				2437,
				2319,
				2314,
				2302,
				2315,
				2438,
				2310,
				2301,
				2298,
				2316,
				2309,
				2321,
				2297,
				2300,
				2311
			});
			RecipeGroup.RegisterGroup("AnyCatchableFish", recipeGroup);
		}

		// Token: 0x04000001 RID: 1
		internal static Archeon instance;

		// Token: 0x04000002 RID: 2
		public static Archeon Instance;
	}
	

}
