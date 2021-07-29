using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Projectiles.Magic
{
	public class RubyBeam : ModProjectile
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
			projectile.width = 16;
			projectile.height = 0;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.extraUpdates = 20;
			projectile.timeLeft = 30;
			projectile.hide = true;
		}

		public override void AI()
		{
			projectile.localAI[0] += 1f;
			if (projectile.localAI[0] > 3f)
			{
				for (int i = 0; i < 4; i++)
				{
					Vector2 vector = projectile.position;
					vector -= projectile.velocity * ((float)i * 0.25f);
					projectile.alpha = 255;
					int num = Dust.NewDust(vector, 1, 1, 60, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num].noGravity = true;
					Main.dust[num].position = vector;
					Main.dust[num].scale = 1.1f;
					Main.dust[num].velocity *= 0.4f;
				}
				return;
			}
		}
	}
	
	public class DiamondBeam : ModProjectile
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
			projectile.width = 16;
			projectile.height = 0;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.extraUpdates = 20;
			projectile.timeLeft = 30;
			projectile.hide = true;
		}

		public override void AI()
		{
			projectile.localAI[0] += 1f;
			if (projectile.localAI[0] > 3f)
			{
				for (int i = 0; i < 4; i++)
				{
					Vector2 vector = projectile.position;
					vector -= projectile.velocity * ((float)i * 0.25f);
					projectile.alpha = 255;
					int num = Dust.NewDust(vector, 1, 1, 63, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num].noGravity = true;
					Main.dust[num].position = vector;
					Main.dust[num].scale = 1.1f;
					Main.dust[num].velocity *= 0.4f;
				}
				return;
			}
		}
	}
	
	public class EmeraldBeam : ModProjectile
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
			projectile.width = 16;
			projectile.height = 0;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.extraUpdates = 20;
			projectile.timeLeft = 30;
			projectile.hide = true;
		}

		public override void AI()
		{
			projectile.localAI[0] += 1f;
			if (projectile.localAI[0] > 3f)
			{
				for (int i = 0; i < 4; i++)
				{
					Vector2 vector = projectile.position;
					vector -= projectile.velocity * ((float)i * 0.25f);
					projectile.alpha = 255;
					int num = Dust.NewDust(vector, 1, 1, 61, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num].noGravity = true;
					Main.dust[num].position = vector;
					Main.dust[num].scale = 1.1f;
					Main.dust[num].velocity *= 0.4f;
				}
				return;
			}
		}
	}
	
	public class SapphireBeam : ModProjectile
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
			projectile.width = 16;
			projectile.height = 0;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.extraUpdates = 20;
			projectile.timeLeft = 30;
			projectile.hide = true;
		}

		public override void AI()
		{
			projectile.localAI[0] += 1f;
			if (projectile.localAI[0] > 3f)
			{
				for (int i = 0; i < 4; i++)
				{
					Vector2 vector = projectile.position;
					vector -= projectile.velocity * ((float)i * 0.25f);
					projectile.alpha = 255;
					int num = Dust.NewDust(vector, 1, 1, 59, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num].noGravity = true;
					Main.dust[num].position = vector;
					Main.dust[num].scale = 1.1f;
					Main.dust[num].velocity *= 0.4f;
				}
				return;
			}
		}
	}
	
	public class AmethystBeam : ModProjectile
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
			projectile.width = 16;
			projectile.height = 0;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.extraUpdates = 20;
			projectile.timeLeft = 30;
			projectile.hide = true;
		}

		public override void AI()
		{
			projectile.localAI[0] += 1f;
			if (projectile.localAI[0] > 3f)
			{
				for (int i = 0; i < 4; i++)
				{
					Vector2 vector = projectile.position;
					vector -= projectile.velocity * ((float)i * 0.25f);
					projectile.alpha = 255;
					int num = Dust.NewDust(vector, 1, 1, 62, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num].noGravity = true;
					Main.dust[num].position = vector;
					Main.dust[num].scale = 1.1f;
					Main.dust[num].velocity *= 0.4f;
				}
				return;
			}
		}
	}
}
