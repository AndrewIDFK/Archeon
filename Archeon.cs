using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon
{
	public class Archeon : Mod
	{

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
			
			recipeGroup = new RecipeGroup(() => "Gold or Platinum Sword", new int[]
			{
				3520,
				3484
			});
			RecipeGroup.RegisterGroup("GoldOrPlatinumSword", recipeGroup);
			
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
		internal static Archeon instance;
		public static Archeon Instance;
	}
}
