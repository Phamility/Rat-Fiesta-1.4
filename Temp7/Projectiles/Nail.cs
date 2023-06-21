using System; using TenShadows.Buffs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria.Audio;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExampleMod.Content.DamageClasses;
using TenShadows.Items.Shadows;
using TenShadows.Items.Techniques;

namespace TenShadows.Projectiles
{
    public class Nail : ModProjectile
    {
        int rspeed;
        int yspeed;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nail");
            Main.projFrames[Projectile.type] = 1;
            Main.projPet[Projectile.type] = false;




        }
        private int lockedin;
        public sealed override void SetDefaults()
        {
            xspeed = 6.5f * CountryHammer.positive;
            Projectile.spriteDirection = CountryHammer.positive;
            lockedin = CountryHammer.positive;
            Projectile.width = 14;
            //projectile.aiStyle = 54;
            //aiType = NPCID.Raven;

            //projectile.velocity.X = -rspeed;
            //   Projectile.velocity.X = yspeed;
            Projectile.DamageType = ModContent.GetInstance<CursedDamage>();

            Projectile.height = 16;
            // Makes the minion go through tiles freely
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            // These below are needed for a minion weapon
            // Only controls if it deals damage to enemies on contact (more on that later)
            Projectile.friendly = true;
            // Only determines the damage type
            //	projectile.minion = true;
            // Amount of slots this minion occupies from the total minion slots available to the player (more on that later)
           Projectile.penetrate = 1;
            // Needed so the minion doesn't despawn on collision with enemies or tiles
          //  Projectile.timeLeft = 120; 
            Projectile.Opacity = 1;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            for (int i = 0; i < 5; i++)
            {
                int dustType = DustID.Silver;
                var dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, dustType);

                dust.velocity.X += Main.rand.NextFloat(-0.3f, 0.3f);
                dust.velocity.Y += Main.rand.NextFloat(-0.3f, 0.3f);

                dust.scale *= 1f + Main.rand.NextFloat(-0.03f, 0.03f);
            }
            return true;
                }
        public override bool? CanCutTiles()
        {
            return false;
        }
  
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

        }
        float xspeed;
       private int timer = 0;

        public override void AI()
        {
            timer++;
                if(timer > 120)
            {
                for (int i = 0; i < 4; i++)
                {
                    int dustType = DustID.Silver;
                    var dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, dustType);

                    dust.velocity.X += Main.rand.NextFloat(-0.3f, 0.3f);
                    dust.velocity.Y += Main.rand.NextFloat(-0.3f, 0.3f);

                    dust.scale *= 1f + Main.rand.NextFloat(-0.03f, 0.03f);
                }
                Projectile.active = false;
            }
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            Player player = Main.player[Projectile.owner];

            //projectile.velocity.X = -rspeed;
            Projectile.velocity.X = xspeed;
          //  Projectile.rotation += (Projectile.velocity.Y * .02f);

            //projectile.velocity.X = ((rspeed - 10) / 4.5f);
            //projectile.rotation = (rspeed - 10) / (-13.5f);

            Vector2 idlePosition = (player.Center);
            Vector2 vectorToIdlePosition = idlePosition - Projectile.Center;
            float distanceToIdlePosition = vectorToIdlePosition.Length();

            if (Main.myPlayer == player.whoAmI && distanceToIdlePosition > 2100)
            {
                // Whenever you deal with non-regular events that change the behavior or position drastically, make sure to only run the code on the owner of the projectile,
                // and then set netUpdate to true
                //projectile.position = idlePosition + new Vector2(lecock2, -lecock);
                Projectile.active = false;
            }

        
        }

    }
}