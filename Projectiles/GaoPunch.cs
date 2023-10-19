using Terraria;
using Terraria.ModLoader;
using System;

namespace gaomonmod1dot4.Projectiles
{
    public class GaoPunch : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 18;
            Projectile.height = 10;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            if (Projectile.ai[0] == 0)
            {
                Projectile.rotation = MathF.Atan2(Projectile.velocity.Y, Projectile.velocity.X);
            }
            Projectile.ai[0]++;
            if (Projectile.ai[0] >= 8)
                Projectile.Kill();
        }
    }
}