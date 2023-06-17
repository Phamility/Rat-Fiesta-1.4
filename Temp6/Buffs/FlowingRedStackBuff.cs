using System; using TenShadows.Buffs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.Audio;

using Terraria.DataStructures;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using TenShadows.Projectiles;
using TenShadows.Items.Materials;

namespace TenShadows.Buffs
{
    public class FlowingRedStackBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flowing Red Scale: Stack");
            Description.SetDefault("Substantially increased damage and critical chance in exchange for a substantial decrease life regen");
            //  Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true; // This buff won't save when you exit the world
            Main.buffNoTimeDisplay[Type] = false; // The time remaining won't display on this buff
        }
        public override void Update(Player player, ref int buffIndex)
        {

            player.GetDamage(DamageClass.Generic) += 0.15f;
            player.GetCritChance(DamageClass.Generic) += 10f;
            player.lifeRegen -= 18;


        }

    }
}
