using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Projectiles.Magic
{
	public class ApparitionVolumeProj : ModProjectile
	{

		public override void SetDefaults()
		{
			projectile.width = 22;
			projectile.height = 32;
			projectile.netImportant = true;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.timeLeft = 30;
			projectile.penetrate = -4;
			projectile.tileCollide = false;
			projectile.magic = true;
		}
		int rotatatron;
		bool onceDone = false;
		public override void AI()
		{
			if(Main.rand.Next(7) == 0)
			{
				int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, 134, 0f, 0f, 100, default(Color), 1.2f);
				Main.dust[num].noGravity = true;
				Main.dust[num].velocity /= 1.5f;
			}
			if(onceDone == false)
			{
				projectile.rotation -= 0.2f;
				onceDone = true;
			}
			
			rotatatron++;
			if(rotatatron <= 2)
			{
				projectile.rotation += 0.2f;
			}
			else
			{
				projectile.rotation -= 0.2f;
			}
			if(rotatatron == 4)
			{
				rotatatron = 0;
			}
		}

		public override void Kill(int timeLeft)
		{	
			for (int i = 0; i < 6; i++)
			{
				int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 134, 0f, 0f, 0, default(Color), 1f);
				Main.dust[num].velocity *= 1.75f;
				Main.dust[num].noGravity = true;
				if (Main.rand.Next(2) == 0)
				{
					Main.dust[num].scale = 0.75f;
					Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
				}
				if(Main.rand.Next(4) == 0)
				{
					num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 185, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num].noGravity = true;
				}
			}
			for (int i = 0; i < 2; i++)
			{
				Vector2 value = Main.MouseWorld - projectile.position;
				value.Normalize();
				Vector2 value2 = Utils.RotatedByRandom(value, (double)MathHelper.ToRadians(7.5f));
				float scaleFactor = 1f - Utils.NextFloat(Main.rand) * 0.18f;
				value2 *= scaleFactor;
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, value2.X * 19.5f, value2.Y * 19.5f, mod.ProjectileType("ApparitionVolumeShatterProj"), projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
			}
		}
	}
	
	public class ApparitionVolumeShatterProj : ModProjectile
	{
		public override string Texture
		{
			get
			{
				return "Archeon/Projectiles/BlankProj";
			}
		}
		
		public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 8;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.magic = true;
			projectile.ignoreWater = true;
			projectile.timeLeft = 240;
		}

		public override void AI()
		{
			if(Main.rand.Next(1) == 0)
			{
				int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, 234, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1.2f);
				Main.dust[num].noGravity = true;
				Main.dust[num].velocity /= 3.5f;
				Main.dust[num].scale = 1.25f;
				if(Main.dust[num].scale <= 0.85f)
				{
					Main.dust[num].scale = 0;
				}
				else Main.dust[num].scale -= 0.04f;
			}
			
			if(Main.rand.Next(9) == 0)
			{
				int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 134, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1.8f);
				Main.dust[num1].noGravity = true;
				Main.dust[num1].velocity /= 1.25f;
				Main.dust[num1].scale = 1.05f;
			}
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 3; i++)
			{
				int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 134, 0f, 0f, 0, default(Color), 1f);
				Main.dust[num].velocity *= 1.5f;
				Main.dust[num].noGravity = true;
				if (Main.rand.Next(2) == 0)
				{
					Main.dust[num].scale = 0.5f;
					Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(6) * 0.1f;
				}
			}
			Main.PlaySound(SoundID.Item10, projectile.position);
		}
	}
}
