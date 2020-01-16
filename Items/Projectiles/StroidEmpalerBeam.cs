using System;
using Archeon.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x02000067 RID: 103
	public class StroidEmpalerBeam : ModProjectile
	{
		// Token: 0x060001BD RID: 445 RVA: 0x0000F630 File Offset: 0x0000D830
		public override void SetDefaults()
		{
			base.projectile.width = 16;
			base.projectile.height = 16;
			base.projectile.aiStyle = 27;
			base.projectile.friendly = true;
			base.projectile.penetrate = 1;
			base.projectile.melee = true;
			Main.PlaySound(SoundID.Item15, base.projectile.position);
		}

		// Token: 0x060001BE RID: 446 RVA: 0x0000F69E File Offset: 0x0000D89E
		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			target.AddBuff(BuffType<CosmicalPoisoning>(), 660, false);
		}

		// Token: 0x060001BF RID: 447 RVA: 0x0000F6B8 File Offset: 0x0000D8B8
		public override bool PreAI()
		{
			Lighting.AddLight(base.projectile.Center, 0.26f, 0.284f, 0.455f);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("StroidWormDeathDust"), base.projectile.velocity.X * -0.5f, base.projectile.velocity.Y * -0.5f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 90f;
			Main.dust[num].scale = 0.8f;
			return true;
		}
	}
}
