﻿using System;
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
namespace TenShadows.Misc
{
    public class ConDebuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Constructor's Limit");
            Description.SetDefault("Unable to cast 'Construction'");
            Main.debuff[Type] = true;
            // Main.buffNoSave[Type] = true; // This buff won't save when you exit the world
            Main.buffNoTimeDisplay[Type] = false; // The time remaining won't display on this buff
        }
    

    }
}
