using Terraria;
using Terraria.ModLoader;
using terraguardians;

namespace gaomonmod1dot4.Companions
{
    //Extending TerraGuardianBase will allow you to create custom companion ready companions.
    //Extending TerrarianBase, allows instead to create Terrarian companions. Check TerraGuardians 1.4 source for example.
    //Extend CompanionCase if you want to try something different for companions.
    public class GaomonBase : TerraGuardianBase
    {
        public override string Name => "Gaomon";
        public override string Description => "Came from another world by unknown ways.";
        public override int SpriteWidth => 64; //The dimensions of each sprite.
        public override int SpriteHeight => 64;
        public override int FramesInRow => 20; //How many frames there are in a row. Please make the spritesheet normal orientation horizontal.
        public override int Width => 18; //Collision dimension
        public override int Height => 32;
        public override CompanionGroup GetCompanionGroup => MainMod.digimonGroup; //Assigning the Digimon group to the companion. You can take TerraGuardian groups from the MainMod script of TerraGuardian.
        public override Sizes Size => Sizes.Medium;
        public override int Age => 0;
        //public override Genders Gender => Genders.Male; //Allow you to setup the gender. Can be Male, Female, or Genderless.
        public override bool CanChangeGenders => true; //If can change gender. Doesn't change much right now, other than text color. Might be handy in the future.
        public override int InitialMaxHealth => 140; //To setup max health value, use this formula on your calculator: (InitialMaxHealth + (HealthPerLifeCrystal * 15) + (HealthPerLifeFruit * 20)). That will let you know the final max health of companion;
        public override int HealthPerLifeCrystal => 16;
        public override int HealthPerLifeFruit => 6;
        //public override int InitialMaxMana => 20; //For setting up max mana. Use this formula on your calculator to calculate final max mana: (InitialMaxMana + (ManaPerManaCrystal * 9))
        //public override int ManaPerManaCrystal => 20;
        public override bool CanCrouch => false; //If companion can crouch. Also used for some animations.
        public override CombatTactics DefaultCombatTactic => CombatTactics.CloseRange; //Default combat tactic of companion.
        public override MountStyles MountStyle => MountStyles.CompanionRidesPlayer; //Sets which way the companion can mount/be mounted on, or if cannot.
        protected override FriendshipLevelUnlocks SetFriendshipUnlocks => new FriendshipLevelUnlocks(){ FollowerUnlock = 0 }; //Allow you to change what each friendship level unlocks.
        protected override CompanionDialogueContainer GetDialogueContainer => new Gaomon.GaomonDialogues(); //I have split the companion dialogues to another file. Here, you initialize the object containing companion dialogues.
        protected override SubAttackBase[] GetDefaultSubAttacks()
        {
            return new SubAttackBase[]
            {
                new Gaomon.SubAttack.GaoRushAttack()
            };
        }

        public override void UpdateAttributes(Companion companion) //This updates whenever the companion status are reset. If you want to change their status, or give them other benefits, here is the place.
        {
            companion.DodgeRate += 5f;
            companion.GetCritChance<MeleeDamageClass>() += 10;
            companion.DefenseRate += 0.05f;
            companion.lifeRegen++;
        }
        #region Animation
        protected override terraguardians.Animation SetStandingFrames => new terraguardians.Animation(0);
        protected override terraguardians.Animation SetWalkingFrames
        {
            get
            {
                terraguardians.Animation anim = new terraguardians.Animation();
                for (short i = 1; i <= 8; i++)
                {
                    anim.AddFrame(i, 24); //The default animation frame duration of companions walking animation is 24, if you want a 1.3 feel.
                }
                return anim;
            }
        }
        protected override terraguardians.Animation SetJumpingFrames => new terraguardians.Animation(9);
        protected override terraguardians.Animation SetItemUseFrames
        {
            get
            {
                terraguardians.Animation anim = new terraguardians.Animation();
                for (short i = 10; i <= 13; i++) //Normally, item use animations have 4 frames. Frames goes from upper left (arm preparing to slash from upwards) to lower right. Mind the frame times.
                {
                    anim.AddFrame(i);
                }
                return anim;
            }
        }
        protected override terraguardians.Animation SetSittingFrames => new terraguardians.Animation(14);
        protected override terraguardians.Animation SetChairSittingFrames => new terraguardians.Animation(14); //If a companion has animation for when sitting on a chair, instead.
        protected override terraguardians.Animation SetRevivingFrames => new terraguardians.Animation(15); //When KO system is implemented, this will be used when the companion is reviving.
        protected override terraguardians.Animation SetDownedFrames => new terraguardians.Animation(16); //KO animation
        protected override terraguardians.Animation SetBedSleepingFrames => new terraguardians.Animation(17);
        protected override terraguardians.Animation SetThroneSittingFrames => new terraguardians.Animation(18);
        protected override terraguardians.Animation SetPlayerMountedArmFrame => new terraguardians.Animation(14); //This is used to set the animation frame for when the player is mounted on the companion, or vice versa.
        protected override AnimationFrameReplacer SetBodyFrontFrameReplacers //To not clutter the mod with empty frames, this is used to assign which frames will have the body drawn in the foreground. Used in some cases, like when companion is mounted on player.
        {
            get
            {
                AnimationFrameReplacer anim = new AnimationFrameReplacer();
                anim.AddFrameToReplace(14, 0);
                return anim;
            }
        }
        #endregion
        #region Animation Position
        protected override AnimationPositionCollection SetSittingPosition => new terraguardians.AnimationPositionCollection(new Microsoft.Xna.Framework.Vector2(16, 27), true); //The position where the companion ass is touching the chair seat. Add a frame for when its using the throne too, if necessary.
        protected override AnimationPositionCollection[] SetHandPositions //Assigns the holding position of each hand (like, item position, and others). Hand 0 is generally the main hand, which is the left (foreground one). Hand 1 is generally offhand.
        {
            get
            {
                AnimationPositionCollection left = new AnimationPositionCollection(), right = new AnimationPositionCollection();
                left.AddFramePoint2X(10, 12, 15);
                left.AddFramePoint2X(11, 20, 21);
                left.AddFramePoint2X(12, 21, 24);
                left.AddFramePoint2X(13, 18, 27);
                
                left.AddFramePoint2X(14, 16, 25);
                
                left.AddFramePoint2X(15, 18, 28);

                right.AddFramePoint2X(10, 17, 15);
                right.AddFramePoint2X(11, 22, 21);
                right.AddFramePoint2X(12, 23, 24);
                right.AddFramePoint2X(13, 20, 27);
                
                right.AddFramePoint2X(14, 22, 25);
                
                right.AddFramePoint2X(15, 21, 28);
                return new AnimationPositionCollection[]{ left, right };
            }
        }
        protected override AnimationPositionCollection SetHeadVanityPosition //Hat position. Might need checking if it shows up on the right place, when I get the system working.
        {
            get
            {
                AnimationPositionCollection anim = new AnimationPositionCollection(new Microsoft.Xna.Framework.Vector2(16, 21), true);
                anim.AddFramePoint2X(15, 18, 23);
                return anim;
            }
        }
        protected override AnimationPositionCollection SetMountShoulderPosition => new AnimationPositionCollection(new Microsoft.Xna.Framework.Vector2(16, 27), true); //When player is mounted on companion, where they will be sitting at.
        protected override AnimationPositionCollection SetPlayerSittingOffset //Changes the player or companion position offset when sharing a chair. It is affected by mount style.
        {
            get
            {
                AnimationPositionCollection anim = new AnimationPositionCollection();
                anim.AddFramePoint2X(14, 0, -1);
                return anim;
            }
        }
        public override bool DrawBehindWhenSharingBed => true;
        #endregion
    }
}