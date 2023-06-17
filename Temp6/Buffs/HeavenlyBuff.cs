using System; using TenShadows.Buffs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Terraria.ID;
using TenShadows.Projectiles;
using TenShadows.Items.Materials;

namespace TenShadows.Buffs
{
    public class HeavenlyBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heavenly Restriction");
            Description.SetDefault("Melee and ranged damage increased by 10%\nMovement speed increased by 10%\nDefense increased by 3\nCan't use mana"); Main.debuff[Type] = true;

            // Main.buffNoSave[Type] = true; // This buff won't save when you exit the world
            Main.buffNoTimeDisplay[Type] = true; // The time remaining won't display on this buff
        }
        public override void Update(Player player, ref int buffIndex)
        {

            player.GetDamage(DamageClass.Melee) += 0.10f;
            player.GetDamage(DamageClass.Ranged) += 0.10f;
            player.moveSpeed += .1f;
            player.statDefense += 3;
            player.statMana = 0;
            player.statManaMax2 = 0;
            player.maxMinions = 0;



        }
    }
}
