using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
    public class DefenseOrbAccessoryHeal : ModProjectile
    {
		
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Healing Shard");
		}
		
        public override void SetDefaults()
        {
			base.projectile.width = 4;
			base.projectile.height = 4;
			//base.projectile.aiStyle = 1;
			base.projectile.friendly = true;
			base.projectile.hostile = false;
			projectile.magic = true;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 120;
			base.projectile.alpha = 140;
			base.projectile.light = 0.5f;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.extraUpdates = 6;
			//this.aiType = 14;
			projectile.scale = 1.25f;
			projectile.hide = true;  
        }
		
        public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.7f, 0.13f, 0.44f);
			
			/*int num21 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("DefenseOrbHealingDust"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num21].velocity /= 160f;
			Main.dust[num21].scale = 0.5f;*/
			
			for (int num163 = 0; num163 < 10; num163++)
			{
				float x2 = base.projectile.position.X - base.projectile.velocity.X / 10f * (float)num163;
				float y2 = base.projectile.position.Y - base.projectile.velocity.Y / 10f * (float)num163;
				int num164 = Dust.NewDust(new Vector2(x2, y2), 1, 1, mod.DustType("DefenseOrbHealingDust"));	
				Main.dust[num164].position.X = x2;
				Main.dust[num164].position.Y = y2;
				Main.dust[num164].velocity *= 0f;
				Main.dust[num164].noGravity = true;
				Main.dust[num164].scale = 1.4f;
			}
			
			base.projectile.ai[1] += 1f;
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + 1.57f;
			float numxd = 85f;
			float scaleFactor = 18f;
			float numxd2 = 55f;
			if (base.projectile.alpha > 0)
			{
				base.projectile.alpha -= 10;
			}
			if (base.projectile.alpha < 0)
			{
				base.projectile.alpha = 0;
			}
			
			int numxd3 = (int)base.projectile.ai[0];
			if (numxd3 >= 0 && Main.player[numxd3].active && !Main.player[numxd3].dead)
			{
				if (base.projectile.Distance(Main.player[numxd3].Center) > numxd2)
				{
					Vector2 vectorxd = base.projectile.DirectionTo(Main.player[numxd3].Center);
					if (vectorxd.HasNaNs())
					{
						vectorxd = Vector2.UnitY;
					}
					base.projectile.velocity = (base.projectile.velocity * (numxd - 1f) + vectorxd * scaleFactor) / numxd;
					return;
				}
			}
			else
			{
				if (base.projectile.timeLeft > 180)
				{
					base.projectile.timeLeft = 180;
				}
				if (base.projectile.ai[0] != -1f)
				{
					base.projectile.ai[0] = -1f;
					base.projectile.netUpdate = true;
					return;
				}
			}
			
			int num = (int)base.projectile.ai[0];
			Vector2 vector = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
			float num3 = Main.player[num].Center.X - vector.X;
			float num4 = Main.player[num].Center.Y - vector.Y;
			float num5 = (float)Math.Sqrt((double)(num3 * num3 + num4 * num4));
			if (num5 < 180f && base.projectile.position.X < Main.player[num].position.X + (float)Main.player[num].width && base.projectile.position.X + (float)base.projectile.width > Main.player[num].position.X && base.projectile.position.Y < Main.player[num].position.Y + (float)Main.player[num].height && base.projectile.position.Y + (float)base.projectile.height > Main.player[num].position.Y)
			{
				if (base.projectile.owner == Main.myPlayer && !Main.player[Main.myPlayer].moonLeech)
				{	
					int num6 = (int)base.projectile.ai[1];
					Main.player[num].HealEffect(num6, false);
					Main.player[num].statLife += num6;
					if (Main.player[num].statLife > Main.player[num].statLifeMax2)
					{
						Main.player[num].statLife = Main.player[num].statLifeMax2;
					}
					NetMessage.SendData(66, -1, -1, null, num, (float)num6, 0f, 0f, 0, 0, 0);
				}
				base.projectile.Kill();
			}
		}
		
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(SoundID.Item10, base.projectile.position);
			
		}
    }
}