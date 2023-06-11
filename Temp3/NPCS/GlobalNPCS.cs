using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using TenShadows.Items.Materials;
using TenShadows.Items.Techniques;
using TenShadows.Items.Accessories;
using TenShadows.Projectiles;

namespace TenShadows.NPCS
{
    public class GlobalNPCS : GlobalNPC
    {
        public override void OnKill(NPC npc)
        {
            if ( npc.boss== true )
            {
                DogSummon.KYS = true;
                DogSummon2.KYS = true;

            }




        }
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.BlueSlime || npc.type == NPCID.GreenSlime)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CursedEnergy>(), 50, 1, 4));

            }
            if (npc.type == NPCID.Zombie || npc.type == NPCID.DemonEye)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CursedEnergy>(), 25, 4, 9));

            }
            if (npc.type == NPCID.BloodZombie || npc.type == NPCID.Drippler)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CursedEnergy>(), 15, 4, 9));

            }
            if (npc.type == NPCID.PossessedArmor || npc.type == NPCID.WanderingEye || npc.type == NPCID.Demon)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CursedEnergy>(), 20, 9, 15));

            }
            if (npc.type == NPCID.Demon || npc.type == NPCID.VoodooDemon)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Horn>(), 5));

            }
            if (npc.type == NPCID.WallofFlesh)
            {
                LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());

                notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<RestlessGambler>(), 6));

                npcLoot.Add(notExpertRule);
            }

        }
    }
    public class GlobalItems : GlobalItem
    {
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            // In addition to this code, we also do similar code in Common/GlobalNPCs/ExampleNPCLoot.cs to edit the boss loot for non-expert drops. Remember to do both if your edits should affect non-expert drops as well.
            if (item.type == ItemID.WallOfFleshBossBag)
            {
                foreach (var rule in itemLoot.Get())
                {
                    if (rule is OneFromOptionsNotScaledWithLuckDropRule oneFromOptionsDrop && (oneFromOptionsDrop.dropIds.Contains(ItemID.WarriorEmblem)))
                    {
                        var original = oneFromOptionsDrop.dropIds.ToList();
                        original.Add(ModContent.ItemType<RestlessGambler>());
                        oneFromOptionsDrop.dropIds = original.ToArray();
                    }
                }
            }
        }
    }
    
}

