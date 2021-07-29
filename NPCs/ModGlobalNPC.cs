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
		public bool VyssoniumPoisoning;
		public bool CorrosionDebuff;
		public bool ShadoniumDebuff;
		public bool VyssoniumDebuff;
		
		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}
		
		public override void ResetEffects(NPC npc)
		{	
			VyssoniumPoisoning = false;
			CorrosionDebuff = false;
			ShadoniumDebuff = false;
			VyssoniumDebuff = false;
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
	}
}
