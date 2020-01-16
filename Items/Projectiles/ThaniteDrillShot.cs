using System;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x0200006D RID: 109
	public class ThaniteDrillShot : ModProjectile
	{
		// Token: 0x060001D5 RID: 469 RVA: 0x00010390 File Offset: 0x0000E590
		public override void SetDefaults()
		{
			base.projectile.width = 22;
			base.projectile.height = 22;
			base.projectile.aiStyle = 20;
			base.projectile.friendly = true;
			base.projectile.penetrate = -1;
			base.projectile.tileCollide = false;
			base.projectile.hide = true;
			base.projectile.ownerHitCheck = true;
			base.projectile.melee = true;
		}
	}
}
