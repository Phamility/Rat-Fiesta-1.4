﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;

using ReLogic.Graphics;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.GameContent.UI.BigProgressBar;

namespace TenShadows.NPCS
{
    // Showcases a custom boss bar with basic logic for displaying the icon, life, and shields properly.
    // Has no custom texture, meaning it will use the default vanilla boss bar texture

    // Shows basic boss bar code using a custom colored texture. It only does visual things, so for a more practical boss bar, see the other example (MinionBossBossBar)
    // To use this, in an NPCs SetDefaults, write:
    //  NPC.BossBar = ModContent.GetInstance<ExampleBossBar>();

    // Keep in mind that if the NPC has a boss head icon, it will automatically have the common boss health bar from vanilla. A ModBossBar is not mandatory for a boss.

    // You can make it so your NPC never shows a boss bar, such as Dungeon Guardian or Lunatic Cultist Clone:
    //  NPC.BossBar = Main.BigBossProgressBar.NeverValid;
    public class ExampleBossBar : ModBossBar
    {

        public override Asset<Texture2D> GetIconTexture(ref Rectangle? iconFrame)
        {
             return TextureAssets.Item[0]; // Corgi head icon
        }

        public override bool PreDraw(SpriteBatch spriteBatch, NPC npc, ref BossBarDrawParams drawParams)
        {
            // Make the bar shake the less health the NPC has
            float lifePercent = drawParams.LifePercentToShow / drawParams.LifePercentToShow;
            float shakeIntensity = Utils.Clamp(1f - lifePercent - 0.2f, 0f, 1f);
            drawParams.BarCenter.Y -= 20f;
            drawParams.BarCenter += Main.rand.NextVector2Circular(0.5f, 0.5f) * shakeIntensity * 15f;

          //  drawParams.IconColor = Main.DiscoColor;

            return true;
        }
       
    }
}
