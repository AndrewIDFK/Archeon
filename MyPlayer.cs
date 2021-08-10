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
		public bool BloodiedCharge;	
		public int BloodiedChargeCount;	
		public bool penumbraWard;
		public bool rougeWard;
		public bool MarkOfCain;
		
		public override void ResetEffects()
		{
			BloodiedCharge = false;		
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
			if(BloodiedCharge)
			{
				if(BloodiedChargeCount >= 6)
				{
					BloodiedChargeCount = 6;
				}
			}
			else BloodiedChargeCount = -1;
		}
		
		public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			if (player.whoAmI == Main.myPlayer)
			{
				if (BloodiedCharge)
				{
					BloodiedChargeCount = 0;
				}
			}
		}
		
		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
		{
			if (player.whoAmI == Main.myPlayer)
			{
				if (BloodiedCharge)
				{
					if(Main.rand.Next(6) == 1)
					{
						BloodiedChargeCount++;			
						if(player.ownedProjectileCounts[mod.ProjectileType("BloodiedCharge")] == 0)
						{
							Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("BloodiedCharge"), 0, 0, Main.myPlayer, 0f, 0f);
						}
						else if (player.ownedProjectileCounts[mod.ProjectileType("BloodiedCharge2")] == 0)
						{
							Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("BloodiedCharge2"), 0, 0, Main.myPlayer, 0f, 0f);
						}
						else if (player.ownedProjectileCounts[mod.ProjectileType("BloodiedCharge3")] == 0)
						{
							Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("BloodiedCharge3"), 0, 0, Main.myPlayer, 0f, 0f);
						}
						else if (player.ownedProjectileCounts[mod.ProjectileType("BloodiedCharge4")] == 0)
						{
							Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("BloodiedCharge4"), 0, 0, Main.myPlayer, 0f, 0f);
						}
						else if (player.ownedProjectileCounts[mod.ProjectileType("BloodiedCharge5")] == 0)
						{
							Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("BloodiedCharge5"), 0, 0, Main.myPlayer, 0f, 0f);
						}
					}
				}
				if(MarkOfCain)
				{
					MOCHurt -= 100;
				}
			}
		}
		
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if (player.whoAmI == Main.myPlayer)
			{
				if (BloodiedCharge)
				{
					if(Main.rand.Next(4) == 3)
					{
						BloodiedChargeCount++;			
						if(player.ownedProjectileCounts[mod.ProjectileType("BloodiedCharge")] == 0)
						{
							Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("BloodiedCharge"), 0, 0, Main.myPlayer, 0f, 0f);
						}
						else if (player.ownedProjectileCounts[mod.ProjectileType("BloodiedCharge2")] == 0)
						{
							Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("BloodiedCharge2"), 0, 0, Main.myPlayer, 0f, 0f);
						}
						else if (player.ownedProjectileCounts[mod.ProjectileType("BloodiedCharge3")] == 0)
						{
							Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("BloodiedCharge3"), 0, 0, Main.myPlayer, 0f, 0f);
						}
						else if (player.ownedProjectileCounts[mod.ProjectileType("BloodiedCharge4")] == 0)
						{
							Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("BloodiedCharge4"), 0, 0, Main.myPlayer, 0f, 0f);
						}
						else if (player.ownedProjectileCounts[mod.ProjectileType("BloodiedCharge5")] == 0)
						{
							Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("BloodiedCharge5"), 0, 0, Main.myPlayer, 0f, 0f);
						}
					}
				}
				if(MarkOfCain)
				{
					MOCHurt -= 100;
				}
			}
		}
	}
}
