using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Projectiles.Melee
{
	public class SiggatorProj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.extraUpdates = 0;
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 99;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 5f;
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 160f;
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 10.5f;
		}
		string shitSigSaid = "i fail to see the funny";
		
		public override void AI()
		{
			switch (Main.rand.Next(1, 20))
			{
			case 1:
				shitSigSaid = "I got an email for 25% off fishing apparel";
				return;
			case 2:
				shitSigSaid = "can you change your name to something other than a cussword";
				return;
			case 3:
				shitSigSaid = "i dont actually have to put my legal first name and last name rigghht";
				return;
			case 4:
				shitSigSaid = "can't - dont have a phone";
				return;
			case 5:
				shitSigSaid = "it should be random enough to get alot of views";
				return;
				case 6:
				shitSigSaid = "needs more curve";
				return;
			case 7:
				shitSigSaid = "i do not understand how stars work at all!";
				return;
			case 8:
				shitSigSaid = "is it ok if I 'trace' it";
				return;
			case 9:
				shitSigSaid = "whats this minecraft game, never heard of it despite it being the #1 most sold game in history";
				return;
			case 10:
				shitSigSaid = "yeah i totally got carried";
				return;
			case 11:
			shitSigSaid = "they might aswell name this bullet hell hell";
				return;
			case 12:
				shitSigSaid = "okay im mad";
				return;
			case 13:
				shitSigSaid = "wait i literally lied";
				return;
			case 14:
				shitSigSaid = "join or boomer";
				return;
			case 15:
				shitSigSaid = "what is GTFO";
				return;
			case 16:
				shitSigSaid = "because you can literally get hacked \nthis isn't some fake news article";
				return;
			case 17:
				shitSigSaid = "I don't know, maybe i shouldn't trust someone who thinks the National Security Agency is NASA?";
				return;
			case 18:
				shitSigSaid = "all the sudden a man with a chrome mask starting chucking ram everywhere!";
				return;
			case 19:
				shitSigSaid = "ohh so your a conspiracy theorist \nno wonder i can't give you any truth";
				break;
			default:
				return;
			}
		}
	
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if(target.life <= 0)
			{
				CombatText.NewText(target.Hitbox, Color.Cyan, shitSigSaid, true);
			}
			target.AddBuff(44, 140, false);
		}
		
	}
}
