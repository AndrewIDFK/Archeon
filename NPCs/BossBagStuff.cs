using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Archeon.NPCs
{
	public class BossBagStuff : GlobalItem
	{
		public override void OpenVanillaBag(string context, Player player, int arg) {
			if (context == "bossBag" && arg == ItemID.PlanteraBossBag) {
				player.QuickSpawnItem(mod.ItemType("FeralShard"), Main.rand.Next(26, 38));
				player.QuickSpawnItem(mod.ItemType("Plantasmoid"), 1);
			}
			
			if (context == "bossBag" && arg == ItemID.DestroyerBossBag) {
				player.QuickSpawnItem(mod.ItemType("EarthElement"), Main.rand.Next(3, 7));
			}
		}
	}
}