using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        }
    }
}
