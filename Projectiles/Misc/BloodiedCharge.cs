using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Projectiles.Misc
{
	public class BloodiedCharge : ModProjectile
	{	
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 4;
		}
		
		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.timeLeft = 2700;
			projectile.scale = 0.95f;
			projectile.alpha = 255;
		}
		int scaleTimer;
		public override void AI()
		{
			if(projectile.alpha > 10)
			{
				projectile.alpha -= 10;
			}
			else projectile.alpha = 10;
			Player player = Main.player[projectile.owner];
			MyPlayer mPlayer = player.GetModPlayer<MyPlayer>();
			Vector2 idlePosition = player.Center;
			idlePosition.X = player.Center.X - 49;
			idlePosition.Y = player.Center.Y - 30;
			float dtIdle = (idlePosition - projectile.Center).Length();
			if (Main.myPlayer == player.whoAmI && dtIdle > 2000f)
			{
				projectile.position = idlePosition;
				projectile.velocity *= 0.1f;
				projectile.netUpdate = true;
			}
			projectile.position = idlePosition;
			if(Main.rand.Next(15) == 2)
			{
				int numDust = Dust.NewDust(projectile.Center, 0, 0, 235);
				Main.dust[numDust].noGravity = true;
				Main.dust[numDust].velocity *= 0.7f;
				Main.dust[numDust].scale = 0.9f;
			}
			if(!mPlayer.BloodiedCharge || mPlayer.BloodiedChargeCount <= 0)
			{
				projectile.Kill();
			}
			if(projectile.frame == 3)
			{
				scaleTimer++;
				if(scaleTimer <= 30)
				{
					projectile.scale += 0.0025f;
				}			
				if (scaleTimer > 30 && scaleTimer <= 61)
				{
					projectile.scale -= 0.0025f;
				}
				if(scaleTimer >= 62)
				{
					scaleTimer = 0;
				}	
			}
		}
		
		public override bool PreDraw(SpriteBatch sb, Color lightColor)
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 15)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
				if (projectile.frame > 3)
				{
					projectile.frame = 3;
				}
			}
			return true;
		}
		
		public override void Kill(int timeLeft) 
		{	
			for (int i = 0; i < 4; i++)
			{
				int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 125, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num].noLight = true;
				Main.dust[num].color = Color.Red;
				Main.dust[num].noGravity = true;
				Main.dust[num].scale = 0.9f;
			}
			for (int i = 0; i < Main.rand.Next(1, 3); i++)
			{
				float xStuff = Main.rand.Next(-5, 5);
				float yStuff = Main.rand.Next(-7, -5);
				Projectile.NewProjectile(projectile.Center.X, projectile.position.Y, xStuff, yStuff, mod.ProjectileType("BloodiedHealProj"), 0, 0, Main.myPlayer, 0f, 0f);
			}
		}
	}
	
	public class BloodiedCharge2 : ModProjectile
	{	
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 4;
		}
		
		public override string Texture
		{
			get
			{
				return "Archeon/Projectiles/Misc/BloodiedCharge";
			}
		}
		
		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.timeLeft = 2700;
			projectile.scale = 0.95f;
			projectile.alpha = 255;
		}
		int scaleTimer;
		public override void AI()
		{
			if(projectile.alpha > 10)
			{
				projectile.alpha -= 10;
			}
			else projectile.alpha = 10;
			Player player = Main.player[projectile.owner];
			MyPlayer mPlayer = player.GetModPlayer<MyPlayer>();
			Vector2 idlePosition = player.Center;
			idlePosition.X = player.Center.X - 29;
			idlePosition.Y = player.Center.Y - 38;
			float dtIdle = (idlePosition - projectile.Center).Length();
			if (Main.myPlayer == player.whoAmI && dtIdle > 2000f)
			{
				projectile.position = idlePosition;
				projectile.velocity *= 0.1f;
				projectile.netUpdate = true;
			}
			projectile.position = idlePosition;
			if(Main.rand.Next(15) == 2)
			{
				int numDust = Dust.NewDust(projectile.Center, 0, 0, 235);
				Main.dust[numDust].noGravity = true;
				Main.dust[numDust].velocity *= 0.7f;
				Main.dust[numDust].scale = 0.9f;
			}
			if(player.ownedProjectileCounts[mod.ProjectileType("BloodiedCharge")] == 0)
			{
				projectile.Kill();
			}
			if(projectile.frame == 3)
			{
				scaleTimer++;
				if(scaleTimer <= 30)
				{
					projectile.scale += 0.0025f;
				}			
				if (scaleTimer > 30 && scaleTimer <= 61)
				{
					projectile.scale -= 0.0025f;
				}
				if(scaleTimer >= 62)
				{
					scaleTimer = 0;
				}	
			}
		}
		
		public override bool PreDraw(SpriteBatch sb, Color lightColor)
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 15)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
				if (projectile.frame > 3)
				{
					projectile.frame = 3;
				}
			}
			return true;
		}
		
		public override void Kill(int timeLeft) 
		{	
			for (int i = 0; i < 4; i++)
			{
				int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 125, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num].noLight = true;
				Main.dust[num].color = Color.Red;
				Main.dust[num].noGravity = true;
				Main.dust[num].scale = 0.9f;
			}
			for (int i = 0; i < Main.rand.Next(1, 3); i++)
			{
				float xStuff = Main.rand.Next(-5, 5);
				float yStuff = Main.rand.Next(-7, -5);
				Projectile.NewProjectile(projectile.Center.X, projectile.position.Y, xStuff, yStuff, mod.ProjectileType("BloodiedHealProj"), 0, 0, Main.myPlayer, 0f, 0f);
			}
		}
	}
	
	public class BloodiedCharge3 : ModProjectile
	{	
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 4;
		}
		
		public override string Texture
		{
			get
			{
				return "Archeon/Projectiles/Misc/BloodiedCharge";
			}
		}
		
		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.timeLeft = 2700;
			projectile.scale = 0.95f;
			projectile.alpha = 255;
		}
		int scaleTimer;
		public override void AI()
		{
			if(projectile.alpha > 10)
			{
				projectile.alpha -= 10;
			}
			else projectile.alpha = 10;
			Player player = Main.player[projectile.owner];
			MyPlayer mPlayer = player.GetModPlayer<MyPlayer>();
			Vector2 idlePosition = player.Center;
			idlePosition.X = player.Center.X - 9;
			idlePosition.Y = player.Center.Y - 43;
			float dtIdle = (idlePosition - projectile.Center).Length();
			if (Main.myPlayer == player.whoAmI && dtIdle > 2000f)
			{
				projectile.position = idlePosition;
				projectile.velocity *= 0.1f;
				projectile.netUpdate = true;
			}
			projectile.position = idlePosition;

			if(Main.rand.Next(15) == 2)
			{
				int numDust = Dust.NewDust(projectile.Center, 0, 0, 235);
				Main.dust[numDust].noGravity = true;
				Main.dust[numDust].velocity *= 0.7f;
				Main.dust[numDust].scale = 0.9f;
			}
			if(player.ownedProjectileCounts[mod.ProjectileType("BloodiedCharge")] == 0)
			{
				projectile.Kill();
			}
			if(projectile.frame == 3)
			{
				scaleTimer++;
				if(scaleTimer <= 30)
				{
					projectile.scale += 0.0025f;
				}			
				if (scaleTimer > 30 && scaleTimer <= 61)
				{
					projectile.scale -= 0.0025f;
				}
				if(scaleTimer >= 62)
				{
					scaleTimer = 0;
				}	
			}	
		}
		
		public override bool PreDraw(SpriteBatch sb, Color lightColor)
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 15)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
				if (projectile.frame > 3)
				{
					projectile.frame = 3;
				}
			}
			return true;
		}
		
		public override void Kill(int timeLeft) 
		{	
			for (int i = 0; i < 4; i++)
			{
				int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 125, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num].noLight = true;
				Main.dust[num].color = Color.Red;
				Main.dust[num].noGravity = true;
				Main.dust[num].scale = 0.9f;
			}
			for (int i = 0; i < Main.rand.Next(1, 3); i++)
			{
				float xStuff = Main.rand.Next(-5, 5);
				float yStuff = Main.rand.Next(-7, -5);
				Projectile.NewProjectile(projectile.Center.X, projectile.position.Y, xStuff, yStuff, mod.ProjectileType("BloodiedHealProj"), 0, 0, Main.myPlayer, 0f, 0f);
			}
		}
	}
	
	public class BloodiedCharge4 : ModProjectile
	{	
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 4;
		}
		
		public override string Texture
		{
			get
			{
				return "Archeon/Projectiles/Misc/BloodiedCharge";
			}
		}
		
		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.timeLeft = 2700;
			projectile.scale = 0.95f;
			projectile.alpha = 255;
		}
		int scaleTimer;
		public override void AI()
		{
			if(projectile.alpha > 10)
			{
				projectile.alpha -= 10;
			}
			else projectile.alpha = 10;
			Player player = Main.player[projectile.owner];
			MyPlayer mPlayer = player.GetModPlayer<MyPlayer>();
			Vector2 idlePosition = player.Center;
			idlePosition.X = player.Center.X + 10;
			idlePosition.Y = player.Center.Y - 38;
			float dtIdle = (idlePosition - projectile.Center).Length();
			if (Main.myPlayer == player.whoAmI && dtIdle > 2000f)
			{
				projectile.position = idlePosition;
				projectile.velocity *= 0.1f;
				projectile.netUpdate = true;
			}
			projectile.position = idlePosition;		
			if(Main.rand.Next(15) == 2)
			{
				int numDust = Dust.NewDust(projectile.Center, 0, 0, 235);
				Main.dust[numDust].noGravity = true;
				Main.dust[numDust].velocity *= 0.7f;
				Main.dust[numDust].scale = 0.9f;
			}	
			if(player.ownedProjectileCounts[mod.ProjectileType("BloodiedCharge")] == 0)
			{
				projectile.Kill();
			}
			if(projectile.frame == 3)
			{
				scaleTimer++;
				if(scaleTimer <= 30)
				{
					projectile.scale += 0.0025f;
				}			
				if (scaleTimer > 30 && scaleTimer <= 61)
				{
					projectile.scale -= 0.0025f;
				}
				if(scaleTimer >= 62)
				{
					scaleTimer = 0;
				}	
			}
		}
		
		public override bool PreDraw(SpriteBatch sb, Color lightColor)
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 15)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
				if (projectile.frame > 3)
				{
					projectile.frame = 3;
				}
			}
			return true;
		}
		
		public override void Kill(int timeLeft) 
		{	
			for (int i = 0; i < 4; i++)
			{
				int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 125, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num].noLight = true;
				Main.dust[num].color = Color.Red;
				Main.dust[num].noGravity = true;
				Main.dust[num].scale = 0.9f;
			}
			for (int i = 0; i < Main.rand.Next(1, 3); i++)
			{
				float xStuff = Main.rand.Next(-5, 5);
				float yStuff = Main.rand.Next(-7, -5);
				Projectile.NewProjectile(projectile.Center.X, projectile.position.Y, xStuff, yStuff, mod.ProjectileType("BloodiedHealProj"), 0, 0, Main.myPlayer, 0f, 0f);
			}
		}
	}
	
	public class BloodiedCharge5 : ModProjectile
	{	
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 4;
		}
		public override string Texture
		{
			get
			{
				return "Archeon/Projectiles/Misc/BloodiedCharge";
			}
		}
		
		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.timeLeft = 2700;
			projectile.scale = 0.95f;
			projectile.alpha = 255;
		}
		int scaleTimer;
		public override void AI()
		{
			if(projectile.alpha > 10)
			{
				projectile.alpha -= 10;
			}
			else projectile.alpha = 10;
			Player player = Main.player[projectile.owner];
			MyPlayer mPlayer = player.GetModPlayer<MyPlayer>();
			Vector2 idlePosition = player.Center;
			idlePosition.X = player.Center.X + 29;
			idlePosition.Y = player.Center.Y - 30;
			float dtIdle = (idlePosition - projectile.Center).Length();
			if (Main.myPlayer == player.whoAmI && dtIdle > 2000f)
			{
				projectile.position = idlePosition;
				projectile.velocity *= 0.1f;
				projectile.netUpdate = true;
			}
			projectile.position = idlePosition;
			if(Main.rand.Next(15) == 2)
			{
				int numDust = Dust.NewDust(projectile.Center, 0, 0, 235);
				Main.dust[numDust].noGravity = true;
				Main.dust[numDust].velocity *= 0.7f;
				Main.dust[numDust].scale = 0.9f;
			}	
			if(player.ownedProjectileCounts[mod.ProjectileType("BloodiedCharge")] == 0)
			{
				projectile.Kill();
			}
			if(projectile.frame == 3)
			{
				scaleTimer++;
				if(scaleTimer <= 30)
				{
					projectile.scale += 0.0025f;
				}			
				if (scaleTimer > 30 && scaleTimer <= 61)
				{
					projectile.scale -= 0.0025f;
				}
				if(scaleTimer >= 62)
				{
					scaleTimer = 0;
				}	
			}
		}
		
		public override bool PreDraw(SpriteBatch sb, Color lightColor)
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 15)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
				if (projectile.frame > 3)
				{
					projectile.frame = 3;
				}
			}
			return true;
		}
		
		public override void Kill(int timeLeft) 
		{	
			for (int i = 0; i < 4; i++)
			{
				int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 125, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num].noLight = true;
				Main.dust[num].color = Color.Red;
				Main.dust[num].noGravity = true;
				Main.dust[num].scale = 0.9f;
			}
			for (int i = 0; i < Main.rand.Next(1, 3); i++)
			{
				float xStuff = Main.rand.Next(-5, 5);
				float yStuff = Main.rand.Next(-7, -5);
				Projectile.NewProjectile(projectile.Center.X, projectile.position.Y, xStuff, yStuff, mod.ProjectileType("BloodiedHealProj"), 0, 0, Main.myPlayer, 0f, 0f);
			}
		}
	}
}