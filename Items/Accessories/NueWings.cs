using System;
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
using static Terraria.ModLoader.PlayerDrawLayer;
using TenShadows.Projectiles;
using TenShadows.Items.Materials;

namespace TenShadows.Items.Accessories
{
    [AutoloadEquip(EquipType.Wings)]
    public class NueWings : ModItem
    {
        // To see how this config option was added, see ExampleModConfig.cs
 
        public override void SetStaticDefaults()
        {
            // These wings use the same values as the solar wings
            // Fly time: 180 ticks = 3 seconds
            // Fly speed: 9
            // Acceleration multiplier: 2.5
            DisplayName.SetDefault("Nue's Wings");
            Tooltip.SetDefault("Take flight!\nThey're weak but they'll work.");
            ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(20, 2f, 1f);
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 20;
            Item.value = 10000;
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.35f; // Falling glide speed
            ascentWhenRising = 0.05f; // Rising speed
            maxCanAscendMultiplier = .5f;
            maxAscentMultiplier = 1f;
            constantAscend = 0.105f;
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<NueFeather>(15)
                .AddTile(TileID.WorkBenches)
                .SortBefore(Main.recipe.First(recipe => recipe.createItem.wingSlot != -1)) // Places this recipe before any wing so every wing stays together in the crafting menu.
                .Register();
        }
    }
}