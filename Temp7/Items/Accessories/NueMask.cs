using System; using TenShadows.Buffs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.Utilities;
using Terraria.Audio;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using IL.Terraria.GameContent.Personalities;
using On.Terraria.GameContent.Personalities;
using TenShadows.Projectiles;
using TenShadows.Items.Materials;

namespace TenShadows.Items.Accessories
{
    public class NueMask : ModItem
    {
        // To see how this config option was added, see ExampleModConfig.cs
 
        public override void SetStaticDefaults()
        {
            
            DisplayName.SetDefault("Nue's Mask");
            Tooltip.SetDefault("Periodically rain down lightning orbs that deal a burst of damage!");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 24;
            Item.value = 10000;
            Item.rare = ItemRarityID.Purple;
            Item.accessory = true;
            Item.expert = true;

        }
        private int timer;
        private int damage;
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            timer++;
            if(timer > 25)
            {
                Vector2 position = player.position - new Vector2(Main.rand.Next(-550, 550), 600);

                var entitySource = player.GetSource_FromAI();
                int type = ModContent.ProjectileType<NueLightningFriendly>();
                    if(Main.expertMode == true)
                {
                     damage = 60;

                }
                else
                {
                     damage = 30;

                }



                Projectile.NewProjectile(entitySource, position, -Vector2.UnitY, type, damage, 0f, player.whoAmI);

                timer = 0;
            }
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.

    }
}