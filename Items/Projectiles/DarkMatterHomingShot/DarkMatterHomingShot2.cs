using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles.DarkMatterHomingShot
{
	// Token: 0x02000054 RID: 84
	public class DarkMatterHomingShot2 : ModProjectile
	{
		// Token: 0x0600016E RID: 366 RVA: 0x0000AEBC File Offset: 0x000090BC
		public override void SetDefaults()
		{
			base.projectile.scale = 1.5f;
			base.projectile.extraUpdates = 0;
			base.projectile.width = 20;
			base.projectile.height = 20;
			base.projectile.aiStyle = 27;
			base.projectile.friendly = true;
			base.projectile.penetrate = 4;
			base.projectile.melee = true;
			Main.PlaySound(SoundID.Item15, base.projectile.position);
			base.projectile.hide = true;
			base.projectile.timeLeft = 951;
		}

		// Token: 0x0600016F RID: 367 RVA: 0x0000AF54 File Offset: 0x00009154
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.49f, 0.87f, 1.22f);
			int num21 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("DarkMatterDust2"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num21].velocity /= 160f;
			Main.dust[num21].scale = 1.25f;
			int num22 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("DarkMatterDust2"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num22].velocity /= 160f;
			Main.dust[num22].scale = 1.25f;
			int num23 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("DarkMatterDust2"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num23].velocity /= 160f;
			Main.dust[num23].scale = 1.25f;
			
		}
		
		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			projectile.netUpdate = true; // netUpdate this javelin
			target.AddBuff(BuffType<Buffs.DarkMatterDebuff>(), 240); // Adds the ExampleJavelin debuff for a very small DoT
			
			if (target.type == mod.NPCType("AirElementEye"))
			{
				damage *= 3;
				
				return;
			}
			
			if (target.type == mod.NPCType("FireElementHover"))
			{
				damage *= 3;
				
				return;
			}
			
			if (target.type == mod.NPCType("EarthElementBody"))
			{
				damage *= 3;
				
				return;
			}
			
			if (target.type == mod.NPCType("FrostElementDragon"))
			{
				damage *= 3;
				
				return;
			}
		}
		
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(SoundID.Item8, base.projectile.position);
			
			for (int i = 0; i < 10; i++)
			{
				Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("DarkMatterDust1"), base.projectile.oldVelocity.X * 2.5f, base.projectile.oldVelocity.Y * 2.5f, 0, default(Color), 1f);
			}
			
			
			Projectile.NewProjectile(base.projectile.Center.X + 6.5f, base.projectile.Center.Y + 6.5f, projectile.velocity.X, projectile.velocity.Y - 26.2f, base.mod.ProjectileType("DarkMatterRealHoming1"), base.projectile.damage, base.projectile.knockBack, Main.myPlayer, 0f, 0f);

		}
	}
}
