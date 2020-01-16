using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.NPCs.Bosses.MarbleBoss
{
    public class MarbleBossBossBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
        }

		public override int BossBagNPC => mod.NPCType("MarbleBoss"); 
		
        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.consumable = true;
            item.width = 36;
            item.height = 32;
            item.rare = 9;
            item.expert = true;
           
        }

		
        public override bool CanRightClick()
        {
            return true;
        }

        public override void OpenBossBag(Player player)
        {
            player.TryGettingDevArmor();
            int choice = Main.rand.Next(2);
            if (choice == 0)
            {
                player.QuickSpawnItem(mod.ItemType("AttackOrbAccessory"));

            }
            if (choice == 1)
            {
                player.QuickSpawnItem(mod.ItemType("DefenseOrbAccessory"));

            }
        }
    }
}