using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.CraftingStations
{
	public class GemConstructor : ModItem
	{
		public override void SetStaticDefaults() {
			base.DisplayName.SetDefault("Gem Amplifier");
			base.Tooltip.SetDefault("Functions as a Hellforge\nUsed to craft various gem related items");
		}

		public override void SetDefaults() {
			item.width = 28;
			item.height = 28;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 25000;
			item.createTile = TileType<CraftingStations.GemConstructorTile>();
		}
		
		public override void AddRecipes() //RECIPES FOR THE GEM AMPLIFIER
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(ItemID.Hellforge);
			modRecipe.AddIngredient(ItemID.Obsidian, 25);
			modRecipe.AddRecipeGroup("IronOrLeadBar", 10);
			modRecipe.AddRecipeGroup("DemoniteOrCrimtaneBar", 4);
			modRecipe.AddIngredient(207); //Lava Bucket
			modRecipe.SetResult(this, 1); // Gem Constructor
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(ItemID.Glass, 25);
			modRecipe.AddIngredient(172, 25); // Ash
			modRecipe.AddTile(base.mod.TileType("GemConstructorTile"));
			modRecipe.SetResult(182, 1); // D I A M O N D
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(3380, 3); // Sturdy Fossil
			modRecipe.AddIngredient(ItemID.BottledHoney, 1); 
			modRecipe.AddTile(base.mod.TileType("GemConstructorTile"));
			modRecipe.SetResult(999, 3); // A M B E R
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddRecipeGroup("AnyCatchableFish");
			modRecipe.AddIngredient(ItemID.Obsidian, 2); 
			modRecipe.AddTile(base.mod.TileType("GemConstructorTile"));
			modRecipe.SetResult(178, 4); // R U B Y
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(ItemID.Cactus, 5);
			modRecipe.AddRecipeGroup("IronOrLeadBar", 2);
			modRecipe.AddTile(base.mod.TileType("GemConstructorTile"));
			modRecipe.SetResult(179, 1); // E M E R A L D
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(206, 2);
			modRecipe.AddIngredient(ItemID.Obsidian, 1);
			modRecipe.AddTile(base.mod.TileType("GemConstructorTile"));
			modRecipe.SetResult(177, 1); // S A P P H I R E
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddRecipeGroup("GoldOrPlatinumBar", 1);
			modRecipe.AddIngredient(ItemID.AntlionMandible, 2);
			modRecipe.AddTile(base.mod.TileType("GemConstructorTile"));
			modRecipe.SetResult(177, 2); // T O P A Z
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddRecipeGroup("CorruptOrCrimsonSeed", 1);
			modRecipe.AddIngredient(ItemID.SandBlock, 4);
			modRecipe.AddTile(base.mod.TileType("GemConstructorTile"));
			modRecipe.SetResult(181, 2); // A M E T H Y S T
			modRecipe.AddRecipe();
		}
	}
}