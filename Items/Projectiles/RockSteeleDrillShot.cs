using System;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x02000063 RID: 99
	public class RockSteeleDrillShot : ModProjectile
	{
		// Token: 0x060001B3 RID: 435 RVA: 0x0000F2DC File Offset: 0x0000D4DC
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
