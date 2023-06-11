using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenShadows.GamblingBuffs;
using TenShadows.Items.Shadows;
using TenShadows.Projectiles;
using Terraria.GameContent;
using Terraria.Localization;
using Terraria.Enums;

using Terraria;
using Terraria.ModLoader;


namespace TenShadows.Misc
{
    public class MP : ModPlayer
    {
        public override void PostUpdateEquips()
        {
       
             //   Player.wingTimeMax += 30 * FlightBuff.Wearing;
            if (Player.HasBuff<FlightBuff>())
                {
                Player.wingTimeMax += 30;
            }
            if (Player.HasBuff<WingDebuff>())
            {
                Player.wingTimeMax -= 240;
            }
        }
        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {
        

            return new[] {
                new Item(ModContent.ItemType<DivineDog>()),
             
            };
        }
        public override void ResetEffects()
        {
            if (NPC.downedMoonlord)
            {
                DivineDog.MYDAMAGE = 42;
          

            }
            else if (NPC.downedAncientCultist)
            {
                DivineDog.MYDAMAGE = 38;


            }
            else if (NPC.downedEmpressOfLight)
            {
                DivineDog.MYDAMAGE = 36;


            }
            else if (NPC.downedFishron)
            {
                DivineDog.MYDAMAGE = 34;


            }
            else if (NPC.downedGolemBoss)
            {
                DivineDog.MYDAMAGE = 32;


            }

            else if (NPC.downedPlantBoss)
            {
                DivineDog.MYDAMAGE = 30;


            }
            else if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
            {
                DivineDog.MYDAMAGE = 28;


            }
            else if ((NPC.downedMechBoss1 && NPC.downedMechBoss2) || (NPC.downedMechBoss1 && NPC.downedMechBoss3) || (NPC.downedMechBoss2 && NPC.downedMechBoss3))
            {
                DivineDog.MYDAMAGE = 26;


            }
            else if (NPC.downedMechBossAny)
            {
                DivineDog.MYDAMAGE = 24;


            }
            else if (NPC.downedQueenSlime)
            {
                DivineDog.MYDAMAGE = 22;



            }

            else if (Main.hardMode)
            {
                DivineDog.MYDAMAGE = 20;
            


            }
            else if (NPC.downedDeerclops)
            {
                DivineDog.MYDAMAGE = 17;


            }
            else if (NPC.downedBoss3)
            {
                DivineDog.MYDAMAGE = 15;


            }
            else if (NPC.downedQueenBee)
            {
                DivineDog.MYDAMAGE = 13;


            }
            else if (NPC.downedBoss2)
            {
                DivineDog.MYDAMAGE = 11;


            }

            else if (NPC.downedBoss1)
            {

                DivineDog.MYDAMAGE = 9;
          
            }
            else if (NPC.downedSlimeKing)
            {
                DivineDog.MYDAMAGE = 7;


            }
            else if (DownedBossSystem.downedNue)
            {
                DivineDog.MYDAMAGE = 5;


            }
            else {
                DivineDog.MYDAMAGE = 2;
            

            }


        }
    }
    
}
