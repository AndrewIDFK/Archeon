using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.NPCs
{
    public class NPCItemSales : GlobalNPC
    {


        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
			
			if (type == NPCID.Demolitionist && Main.hardMode) //Townie Name
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("ShrapnelExplosive")); //Thing it sells
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(00, 00, 50, 00); //Buy Price
                nextSlot++; //Needed, makes it appear in the next open slot of the shop?
            }
		
			
			if (type == NPCID.ArmsDealer && NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("ChernobylRemains"));
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(00, 6, 0, 00);
                nextSlot++;
            }
			/*if (type == NPCID.Dryad && tGood <= 0 && Main.hardMode)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("DarkMatter"));
				shop.item[nextSlot].shopCustomPrice = Item.buyPrice(00, 00, 50, 00);
				nextSlot++;
			}*/
            
        }
        /*public override void SetupTravelShop(int[] shop, ref int nextSlot)
        {
            if (Main.rand.Next(0, 5) == 0)
            {
                shop[nextSlot] = ModContent.ItemType<Items.Accesories.Metronome>;
                nextSlot++;
            }
            int selectAccesory = Main.rand.Next(4);
            switch (selectAccesory)
            {
                case 0:
                    shop[nextSlot] = mod.ItemType("SwordEmbiggenner");
                    nextSlot++;
                    break;
                case 1:
                    shop[nextSlot] = mod.ItemType("Gemini");
                    nextSlot++;
                    break;
                case 2:
                    shop[nextSlot] = mod.ItemType("QuestionableSubstance");
                    nextSlot++;
                    break;
                case 4:
                    shop[nextSlot] = mod.ItemType("BookOfMinionTactics");
                    nextSlot++;
                    break;

            }
		}*/
    }
}