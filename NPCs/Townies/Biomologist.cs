using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.NPCs.Townies
{
	// Token: 0x020000D1 RID: 209
	[AutoloadHead]
	public class Biomologist : ModNPC
	{
		// Token: 0x060003DE RID: 990 RVA: 0x00023AA2 File Offset: 0x00021CA2
		public bool Autoload(ref string name, ref string texture, ref string[] altTextures)
		{
			name = "Biomologist";
			return base.mod.Properties.Autoload;
		}

		// Token: 0x060003DF RID: 991 RVA: 0x00023ABC File Offset: 0x00021CBC
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[base.npc.type] = 26;
			NPCID.Sets.ExtraFramesCount[base.npc.type] = 9;
			NPCID.Sets.AttackFrameCount[base.npc.type] = 4;
			NPCID.Sets.DangerDetectRange[base.npc.type] = 700;
			NPCID.Sets.AttackType[base.npc.type] = 0;
			NPCID.Sets.AttackTime[base.npc.type] = 90;
			NPCID.Sets.AttackAverageChance[base.npc.type] = 30;
			NPCID.Sets.HatOffsetY[base.npc.type] = 4;
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x00023B64 File Offset: 0x00021D64
		public override void SetDefaults()
		{
			base.npc.townNPC = true;
			base.npc.friendly = true;
			base.npc.width = 18;
			base.npc.height = 46;
			base.npc.aiStyle = 7;
			base.npc.defense = 65;
			base.npc.lifeMax = 250;
			base.npc.HitSound = SoundID.NPCHit1;
			base.npc.DeathSound = SoundID.NPCDeath1;
			base.npc.knockBackResist = 0.5f;
			this.animationType = 22;
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x00023C04 File Offset: 0x00021E04
		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			return ArcheonWorld.downedHallowedOne;
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x00023C10 File Offset: 0x00021E10
		public override bool CheckConditions(int left, int right, int top, int bottom)
		{
			return true;
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x00023C14 File Offset: 0x00021E14
		public override string TownNPCName()
		{
			int num = WorldGen.genRand.Next(2);
			if (num == 0)
			{
				return "Siggator";
			}
			return "Andrew";
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x00023C3C File Offset: 0x00021E3C
		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = "Shop";
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x00023C45 File Offset: 0x00021E45
		public override void OnChatButtonClicked(bool firstButton, ref bool openShop)
		{
			if (firstButton)
			{
				openShop = true;
			}
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x00023C50 File Offset: 0x00021E50
		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			shop.item[nextSlot].SetDefaults(501, false);
			shop.item[nextSlot].shopCustomPrice = new int?(2500);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(526, false);
			shop.item[nextSlot].shopCustomPrice = new int?(10000);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(521, false);
			shop.item[nextSlot].shopCustomPrice = new int?(9000);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(3091, false);
			shop.item[nextSlot].shopCustomPrice = new int?(35000);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(520, false);
			shop.item[nextSlot].shopCustomPrice = new int?(9000);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(3092, false);
			shop.item[nextSlot].shopCustomPrice = new int?(35000);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(502, false);
			shop.item[nextSlot].shopCustomPrice = new int?(2500);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(522, false);
			shop.item[nextSlot].shopCustomPrice = new int?(4500);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(1332, false);
			shop.item[nextSlot].shopCustomPrice = new int?(4500);
			nextSlot++;
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x00023E20 File Offset: 0x00022020
		public override string GetChat()
		{
			int num = NPC.FindFirstNPC(22);
			if (num >= 0 && Utils.NextBool(Main.rand, 8))
			{
				return "That " + Main.npc[num].GivenName + " guy told me he saw a new Slime in the Hallowed. He must be crazy.";
			}
			int num2 = NPC.FindFirstNPC(18);
			if (num2 >= 0 && Utils.NextBool(Main.rand, 9))
			{
				return "I don't understand why " + Main.npc[num2].GivenName + " is here. I'm not a scaredy cat who has to be healed during boss fights.";
			}
			switch (Main.rand.Next(7))
			{
			case 0:
				return "I sell things from a variety of biomes. By that I mean 2.";
			case 1:
				return "I won't sell you loot, I'll sell you the ingredients to get loot. Understand?";
			case 2:
				return "Are you aware that a meteor has crash landed in this land somewhere? You should go grab some before I mine it all myself.";
			case 3:
				return "Ya know, it's kinda strange how the boys didn't make a mechanical brain. Perhaps it required more Brainpower.";
			case 4:
				return "I was studying up on biomes yesterday. I learned that I'm never going to the Jungle ever.";
			case 5:
				return "Someone told me I was gonna have a bad time in the font of comic sans. I don't get it, can you explain?";
			case 6:
				return "People are often confused about me being a Biomologist who sells stuff. Actually, yeah doesn't make much sense.";
			default:
				return "I've written 4 books on Biomes. But I still don't understand the ocean. There's just this invisble barrier when I try to go into the ocean, I don't get it.";
			}
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x00023EF7 File Offset: 0x000220F7
		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 85;
			knockback = 8f;
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x00023F04 File Offset: 0x00022104
		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 15;
			randExtraCooldown = 10;
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00023F0E File Offset: 0x0002210E
		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = base.mod.ProjectileType("StroidWarHatchetShot");
			attackDelay = 1;
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x00023F25 File Offset: 0x00022125
		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 6f;
			randomOffset = 3f;
		}
	}
}
