using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Projectiles.Melee
{
	public class LemmyProj : ModProjectile
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
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 5.25f;
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 170f;
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 12.25f;
		}
		
		string shitLemSaid = "I hate you";
		int hitCounter = 0;
		public override void AI()
		{
			switch (Main.rand.Next(1, 17))
			{
			case 1:
				shitLemSaid = "You did a lot of tomfoolary";
				return;
			case 2:
				shitLemSaid = "Lol I was your endless amounts of trolling";
				return;
			case 3:
				shitLemSaid = "He be clowning";
				return;
			case 4:
				shitLemSaid = "Yeah my PP is a bit too big";
				return;
			case 5:
				shitLemSaid = "I am now a slave to socity";
				return;
			case 6:
				shitLemSaid = "and yeah I am 80 now";
				return;
			case 7:
				shitLemSaid = "Sure i could try and throw in my two sense";
				return;
			case 8:
				shitLemSaid = "Giving birth to yourself sure is exhausting";
				return;
			case 9:
				shitLemSaid = "i feel kinda dumb tbh";
				return;
			case 10:
				shitLemSaid = "It's kinda like emo and e-girl mixed into one";
				return;
			case 11:
				shitLemSaid = "im assuming its a joke but is a kinda racist joke";
				return;
			case 12:
				shitLemSaid = "ok im not modding for noxium anymore \nfor real this time \nim getting tired of the modding community \ni try my best but no one cares \nmaybe i should kill my self \nbecause i am nothing \nthe only reason im still here is because of some people \nthats it \nbesides \nno one likes me \ni cant code \ni cant sprite \nim not good at anything \nthe only thing im good at \nis being bad at stuff \ni wont be missed \ni will be the first one you forget about when i leave \ni wish i was dead \nplease dont dm me \ni hope you dont become me \nbesides \nim not anyone to look up too \nugh \nand the sad part is \ni might comeback here because of how dumb i am \nbut whatever \nbye \nand please dont dm \nme";
				return;
			case 13:
				shitLemSaid = "your just 2 values \ngottem";
				return;
			case 14:
				shitLemSaid = "your trolling";
				return;
			case 15:
				shitLemSaid = "I dont know how to make it not move left and right like that";
				return;
			case 16:
				shitLemSaid = "I think this is a scam";
				break;
			default:
				return;
			}
			
			if(hitCounter >= 5)
			{
				float num = 0.45f;
				double num2 = (double)(num / Main.rand.Next(12, 18));
				for (int i = 0; i < 8; i++)
				{
					double num3 = num2 * (double)(i + i * i) / 2.0 + (double)(Main.rand.Next(45, 55) * (float)i);
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)(Math.Sin(num3) * 8.0), (float)(Math.Cos(num3) * 8), 228, projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
				}
				hitCounter = 0;
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			hitCounter++;
			if(target.life <= 0)
			{
				CombatText.NewText(target.Hitbox, Color.Lime, shitLemSaid, true);
			}
		}
	}
}
