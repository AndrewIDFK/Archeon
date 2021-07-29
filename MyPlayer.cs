using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon
{
	public class MyPlayer : ModPlayer
	{
		public bool ShadoniumHelmet2;	
		public bool VyssoniumHelmet1;	
		public bool VyssoniumHelmet2;
		public bool penumbraWard;
		public bool rougeWard;
		public bool MarkOfCain;
		
		public override void ResetEffects()
		{
			ShadoniumHelmet2 = false;
			VyssoniumHelmet1 = false;
			VyssoniumHelmet2 = false;		
			penumbraWard = false;
			rougeWard = false;
			MarkOfCain = false;
		}
		
		int MOCHurt = 500;
		public override void PostUpdateMiscEffects()
		{			

			if(MarkOfCain)
			{
				MOCHurt++;
				if(MOCHurt < 500)
				{
					player.AddBuff(mod.BuffType("MarkOfCainBuff"), 1, true);
					player.meleeDamage = player.meleeDamage * 1.15f;
					player.meleeSpeed = player.meleeSpeed * 1.15f;
				}
				else
				{
					player.AddBuff(mod.BuffType("MarkOfCainDebuff"), 1, true);
					player.bleed = true;
					player.meleeDamage -= 0.051f;
					player.meleeSpeed -= 0.051f;
					player.statDefense -= 4;
					player.moveSpeed -= 0.1f;
					player.onFire2 = true;
					player.blackout = true;
				}
				if(MOCHurt >= 1000)
				{
					MOCHurt = 1000;
				}
				if(MOCHurt <= 0)
				{
					MOCHurt = 0;
				}
			}
		}
		
		public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			if (player.whoAmI == Main.myPlayer)
			{
				if (ShadoniumHelmet2 && damage > 30)
				{
					player.immuneTime += 15;
					player.AddBuff(mod.BuffType("ShadoniumArmorSpeed"), 115, true);
				}
				if (VyssoniumHelmet2 && damage > 0)
				{
					
					player.AddBuff(mod.BuffType("VyssoniumArmorMeleeSpeed"), 240, true);
				}
			}
		}
		
		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
		{
			if (VyssoniumHelmet1)
			{
				if (Main.rand.Next(2) == 0)
				{
					target.AddBuff(mod.BuffType("VyssoniumPoisoning"), 165, false);
				}
				else
				{
					target.AddBuff(mod.BuffType("VyssoniumPoisoning"), 115, false);
				}
			}
			if(MarkOfCain)
			{
				MOCHurt -= 100;
			}
		}
		
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if (VyssoniumHelmet1)
			{
				if (Main.rand.Next(2) == 0)
				{
					target.AddBuff(mod.BuffType("VyssoniumPoisoning"), 165, false);
				}
				else
				{
					target.AddBuff(mod.BuffType("VyssoniumPoisoning"), 115, false);
				}
			}
			if(MarkOfCain)
			{
				MOCHurt -= 100;
			}
		}
	}
}
