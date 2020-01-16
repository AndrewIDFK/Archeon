using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.NPCs.Enemies.FrostElementDragon
{
	// Token: 0x02000054 RID: 84
	public class FrostElementDragonShot : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Frost Flaker");
		}
		
		// Token: 0x0600016E RID: 366 RVA: 0x0000AEBC File Offset: 0x000090BC
		public override void SetDefaults()
		{
			base.projectile.scale = 1.34f;
			base.projectile.extraUpdates = 1;
			base.projectile.width = 32;
			base.projectile.height = 32;
			base.projectile.aiStyle = 27;
			base.projectile.hostile = true;
			base.projectile.penetrate = -1;
			base.projectile.melee = true;
			Main.PlaySound(SoundID.Item15, base.projectile.position);
			base.projectile.hide = true;
			base.projectile.tileCollide = false;
			base.projectile.ignoreWater = true;
			base.projectile.timeLeft = 68;
		}

		// Token: 0x0600016F RID: 367 RVA: 0x0000AF54 File Offset: 0x00009154
		public override void AI()
		{
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("FrostElementDust2"), base.projectile.velocity.X * 2f, base.projectile.velocity.Y * 2f, 100, default(Color), 1.4f);
			Main.dust[num].velocity /= 60f;
			Main.dust[num].scale = 0.85f;
			Main.dust[num].noGravity = true;
			Main.dust[num].fadeIn = 3.6f;
			
			//int num2 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("FrostElementDust2"), base.projectile.velocity.X * 2f, base.projectile.velocity.Y * 2f, 100, default(Color), 1.4f);
			//Main.dust[num2].velocity /= 60f;
			//Main.dust[num2].scale = 1.2f;
			//Main.dust[num2].noGravity = true;
		}
		
		public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 220);
        }

		// Token: 0x06000170 RID: 368 RVA: 0x0000B190 File Offset: 0x00009390
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 4; i++)
			{
				Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, base.mod.DustType("FrostElementDust2"), 0f, 0f, 0, default(Color), 1f);
			}
		}
	}
}
