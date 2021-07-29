using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon
{
	public class ArcheonGProjectile : GlobalProjectile
	{
		public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
		{
			if (projectile.owner == Main.myPlayer)
			{			
				if (projectile.minion || ProjectileID.Sets.MinionShot[projectile.type])
				{
					if (Main.player[projectile.owner].GetModPlayer<MyPlayer>().feralArmorDebuffs)
					{
						target.AddBuff(70, 320, false);
						target.AddBuff(20, 320, false);
						
					}
				}	
			}	
		}
	}
}
