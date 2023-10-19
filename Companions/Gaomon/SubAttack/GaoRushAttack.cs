using Terraria;
using terraguardians;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace gaomonmod1dot4.Companions.Gaomon.SubAttack
{
    //Sub attacks are like "skills" companions can use.
    //They must be assigned to the companion so they can be used.
    //Sub Attacks can have an icon. The namespace path should be the same of the icon, and icon should have same name as the class.
    public class GaoRushAttack : SubAttackBase
    {
        public override string Name => "Gao Rush";
        public override string Description => "Punches in aimed direction repeatedly.";
        public override bool AllowItemUsage => false; //If sub attack can be used while a skill is active.
        public override float Cooldown => 16; //Cooldown in seconds before you can use again.

        public override void Update(Companion User, SubAttackData Data)
        {
            if (Data.GetTime % 4 == 0) //For this sub attack, Gaomon should deliver a punch every 4 frames.
            {
                Vector2 FiringDirection = User.AimDirection;
                if (FiringDirection.Length() > 0)
                    FiringDirection.Normalize();
                Vector2 SpawnPosition = User.Center;
                SpawnPosition.X += Main.rand.Next(-12, 13);
                SpawnPosition.Y += Main.rand.Next(-12, 13);
                Projectile.NewProjectile(Player.GetSource_None(), SpawnPosition, FiringDirection * 12, ModContent.ProjectileType<Projectiles.GaoPunch>(), (int)(User.GetDamage<MeleeDamageClass>().Multiplicative * 8), 1.2f, User.whoAmI);
            }
            if (Data.GetTime >= 80) //Ends when 20 punches are delivered.
                Data.EndUse();
        }

        //This is a condition on wether the sub attack should be used at the frame this is called.
        //If it returns true, the companion might try using this sub attack at the moment this condition is checked.
        public override bool AutoUseCondition(Companion User, SubAttackData Data)
        {
            if (User.TargettingSomething && User.itemAnimation == 0)
            {
                float Distance = (User.Center - User.Target.Center).Length();
                if (Distance < 5 * 16 + User.Target.width * 0.5f)
                {
                    return true;
                }
            }
            return false;
        }

        public override void UpdateAnimation(Companion User, SubAttackData Data)
        {
            if (Data.GetTime % 8 < 4) //Makes so Gaomon alternates which arm they extends when punching.
            {
                User.ArmFramesID[0] = 0;
                User.ArmFramesID[1] = 12;
            }
            else
            {
                User.ArmFramesID[1] = 0;
                User.ArmFramesID[0] = 12;
            }
        }
    }
}