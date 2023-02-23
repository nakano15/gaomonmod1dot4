using Terraria;
using terraguardians;
using System.Collections.Generic;

namespace gaomonmod1dot4.Companions.Gaomon
{
    //Contains the dialogues of the companion. Must extend CompanionDialogueContainer.
    public class GaomonDialogues : CompanionDialogueContainer //Must be assigned on the companion base file, setting it as the value of "GetDialogueContainer" overrideable method.
    {
        public override string GreetMessages(Companion companion) //Messages for when you just met the companion.
        {
            return "Woah! Are you my new master?";
        }

        public override string NormalMessages(Companion companion) //Normal chitchat. If you want to get player reference, use MainMod.GetLocalPlayer.
        {
            List<string> Mes = new List<string>();
            Mes.Add("Why I have to use weapons? I can use my fists!");
            Mes.Add("It kind of feels like I'm in a completelly different universe.");
            Mes.Add("I don't think I'm ready for digivolution, but I will keep doing my best either way.");
            Mes.Add("So, you will fight too? Good, I would love fighting alongside you.");
            Mes.Add("In the world I came from, we fight while our masters gives us orders. It is quite nice that he I'm fighting alongside my master.");
            Mes.Add("If you get hurt, pull back for a while until you recover. I can handle them.");
            if (!Main.dayTime)
            {
                if (Main.bloodMoon)
                {
                    Mes.Add("Look at all those punching bags!");
                    Mes.Add("I can't wait to punch something.");
                    Mes.Add("I think that even If I tell you to stay behind me, you wont. Right?");
                }
                else
                {
                    Mes.Add("I don't think there are zombies in the world I came from. Not talking about zombie digimons, I mean.");
                    Mes.Add("Do you think we could go outside, to get some extra exp?");
                }
            }
            else
            {
                if (Main.eclipse)
                {
                    Mes.Add("Aack! What are those things?!");
                    Mes.Add("They will feel the power of my upper cut!");
                }
                else
                {
                    Mes.Add("Hey, boss!");
                    Mes.Add("It's weird being the only digimon in this world.");
                }
            }
            if (Main.raining && !Main.eclipse && !Main.bloodMoon)
            {
                Mes.Add("This... This isn't great... I preffer dry places.");
                Mes.Add("I think my gloves are filled with water.");
                Mes.Add("The rain sound is great. But only the sound.");
            }
            if (Main.hardMode)
            {
                Mes.Add("That giant flesh creature we fought was so scary! We aren't going to face It again, right?");
            }
            if (NPC.AnyNPCs(Terraria.ID.NPCID.Guide)) //[nn:number] gets the name of the npc of the id you set at the number.
            {
                Mes.Add("I have been talking with [nn:" + Terraria.ID.NPCID.Guide + "], and he said that the reason I'm here, is because of third party intervention. What does that mean?");
            }
            if (NPC.AnyNPCs(Terraria.ID.NPCID.Merchant))
            {
                Mes.Add("Absurd that [nn:" + Terraria.ID.NPCID.Merchant + "] doesn't have any disks to sell. But It seems like potions works too.");
            }
            if (NPC.AnyNPCs(Terraria.ID.NPCID.Nurse))
            {
                Mes.Add("You have been talking with [nn:" + Terraria.ID.NPCID.Nurse+ "]? She probably complained that I visit her too frequently, right?");
            }

            if (WorldMod.GetTerraGuardiansCount > 0)
            {
                Mes.Add("What are those creatures? They look like you, but taller, with fur, snout, ears, tail, and more wild.");
                Mes.Add("I was a bit scared of those creatures, until one of them talked to me. They are really nice guys.");
                Mes.Add("How I can speak with the TerraGuardians? I don't know. I just can hear them on my head.");
            }

            if (WorldMod.HasCompanionNPCSpawned(terraguardians.CompanionDB.Rococo)) //Checks if there's a npc of this companion ID spawned in the world. Add ModName as an argument after the ID to get another mod companion instead.
            {
                //[gn:id:modid] gets the name of the companion whose ID and ModID are supplied. Leaving without mod id will make the mod automatically get a TerraGuardian mod companion.
                Mes.Add("[gn:" + 0 + "] asked me earlier If I'm like him. It didn't looked like he liked to know that I'm not.");
            }
            if (WorldMod.HasCompanionNPCSpawned(terraguardians.CompanionDB.Blue))
            {
                if (WorldMod.HasCompanionNPCSpawned(terraguardians.CompanionDB.Zacks))
                {
                    Mes.Add("Whaaaaaaaat? [gn:" + terraguardians.CompanionDB.Blue + "] has a boyfriend? And her boyfriend is a zombie?! Whaaaaaaaaaaaat?");
                }
                else
                {
                    Mes.Add("Say... Do you think I would have a chance with [gn:" + terraguardians.CompanionDB.Blue + "]?");
                }
            }
            if (WorldMod.HasCompanionNPCSpawned(terraguardians.CompanionDB.Sardine) || WorldMod.HasCompanionNPCSpawned(terraguardians.CompanionDB.Bree))
            {
                Mes.Add("It's good to see someone of my size in this world.");
            }
            if (WorldMod.HasCompanionNPCSpawned(terraguardians.CompanionDB.Zacks))
            {
                Mes.Add("Uh... I guess It's all fine, having [gn:" + terraguardians.CompanionDB.Zacks + "] around. Right? Right??");
            }
            if (WorldMod.HasCompanionNPCSpawned(terraguardians.CompanionDB.Brutus))
            {
                Mes.Add("You don't need a bodyguard, you has me.");
            }
            return Mes[Terraria.Main.rand.Next(Mes.Count)];
        }

        public override string TalkMessages(Companion companion) //This message only appears if you speak with a companion whose friendship exp increases.
        {
            List<string> Mes = new List<string>();
            Mes.Add("This place is kind of great! Adventure everywhere!");
            Mes.Add("Do you think we could go to my world?");
            Mes.Add("I think you're the best tamer ever.");
            Mes.Add("I kind of find the " + (WorldGen.crimson ? "Crimson" : "Corruption") + " creepy.");
            if (companion.Male && WorldMod.HasCompanionNPCSpawned(terraguardians.CompanionDB.Blue))
            {
                Mes.Add("Why does [gn:" + terraguardians.CompanionDB.Blue + "] rejects me? Is It because I'm small?");
            }
            return Mes[Terraria.Main.rand.Next(Mes.Count)];
        }

        public override string RequestMessages(Companion companion, RequestContext context) //Messages regarding requests. The contexts are used to let you know which cases the message will use.
        {
            switch(context)
            {
                case RequestContext.NoRequest:
                    {
                        List<string> Mes = new List<string>();
                        Mes.Add("I don't need anything right now.");
                        Mes.Add("The only thing I need, is to practice my punches.");
                        return Mes[Terraria.Main.rand.Next(Mes.Count)];
                    }
                case RequestContext.HasRequest:
                    {
                        List<string> Mes = new List<string>();
                        Mes.Add("It is really weird for me to ask, but I need your help for something. I need you to [objective], can you do it?");
                        Mes.Add("Hey boss! Can you help me with something? I need you to [objective]. I'm not really used to ask for help but.. Can you help me with this?");
                        return Mes[Main.rand.Next(Mes.Count)];
                    }
                case RequestContext.Completed:
                    {
                        List<string> Mes = new List<string>();
                        Mes.Add("You're the best, boss!");
                        Mes.Add("Amazing! You really did It!");
                        return Mes[Terraria.Main.rand.Next(Mes.Count)];
                    }
                case RequestContext.Accepted:
                    return "You'll do? Thanks! Come tell me when you finish my request.";
                case RequestContext.TooManyRequests:
                    return "You look way too overloaded right now. Try doing your other requests, first.";
                case RequestContext.Rejected:
                    return "Aww...";
                case RequestContext.PostponeRequest:
                    return "Oh, later then?";
                case RequestContext.Failed:
                    return "Well, at least you gave it a try.";
                case RequestContext.AskIfRequestIsCompleted:
                    return "Have you completed my request?";
                case RequestContext.RemindObjective:
                    return "You forgot what I asked for? I need you to [objective].";
            }
            return base.RequestMessages(companion, context);
        }

        public override string AskCompanionToMoveInMessage(Companion companion, MoveInContext context)
        {
            switch(context)
            {
                case MoveInContext.Success:
                    return "Yes, I can live here, Master.";
                case MoveInContext.Fail:
                    return "I don't actually want to.";
                case MoveInContext.NotFriendsEnough:
                    return "I don't know...";
            }
            return base.AskCompanionToMoveInMessage(companion, context);
        }

        public override string AskCompanionToMoveOutMessage(Companion companion, MoveOutContext context)
        {
            switch(context)
            {
                case MoveOutContext.Success:
                    return "Yes, Master...";
                case MoveOutContext.Fail:
                    return "Not a good moment for that.";
                case MoveOutContext.NoAuthorityTo:
                    return "No.";
            }
            return base.AskCompanionToMoveOutMessage(companion, context);
        }

        public override string JoinGroupMessages(Companion companion, JoinMessageContext context)
        {
            switch(context)
            {
                case JoinMessageContext.Success:
                    return "Yes, [nickname]!";
                case JoinMessageContext.FullParty:
                    return "But [nickname], there's too many people with you.";
                case JoinMessageContext.Fail:
                    return "Sorry [nickname], but not right now.";
            }
            return base.JoinGroupMessages(companion, context);
        }

        public override string LeaveGroupMessages(Companion companion, LeaveMessageContext context)
        {
            switch(context)
            {
                case LeaveMessageContext.Success:
                    return "Okay [nickname], If you need me, just call me.";
                case LeaveMessageContext.Fail:
                    return "Not right now.";
                case LeaveMessageContext.AskIfSure:
                    return "But [nickname], I want to explore the world with you some more.";
                case LeaveMessageContext.DangerousPlaceYesAnswer:
                    return "[nickname]! Are you sure you want to leave me here? I will have to fight my way back home.";
                case LeaveMessageContext.DangerousPlaceNoAnswer:
                    return "Thanks [nickname], I wasn't really wanting to leave the group.";
            }
            return base.LeaveGroupMessages(companion, context);
        }

        public override string MountCompanionMessage(Companion companion, MountCompanionContext context)
        {
            switch(context)
            {
                case MountCompanionContext.Success: //If the player will mount on companion.
                    return "I don't think I can digivolve right now, but I can try.";
                case MountCompanionContext.SuccessMountedOnPlayer: //If companion will mount on the player.
                    return "Yes, [nickname]. But how I will attack the monsters?";
                case MountCompanionContext.Fail:
                    return "This isn't a good moment for that.";
                case MountCompanionContext.NotFriendsEnough:
                    return "I don't like that idea.";
            }
            return base.MountCompanionMessage(companion, context);
        }

        public override string DismountCompanionMessage(Companion companion, DismountCompanionContext context)
        {
            switch(context)
            {
                case DismountCompanionContext.SuccessMount: //If the player will mount on companion.
                    return "I think I might have got my shoulders stronger.";
                case DismountCompanionContext.SuccessMountOnPlayer: //If companion will mount on the player.
                    return "I might fight better like this.";
                case DismountCompanionContext.Fail:
                    return "Not a good moment for that.";
            }
            return base.DismountCompanionMessage(companion, context);
        }

        //Messages for when speaking with a companion that is sleeping.
        public override string SleepingMessage(Companion companion, SleepingMessageContext context)
        {
            switch(context)
            {
                case SleepingMessageContext.WhenSleeping:
                    switch(Main.rand.Next(3))
                    {
                        default:
                            return "(They're snoring really loud when sleeping. Must be depleted.)";
                        case 1:
                            return "(It seems to be having dreams of the world they came from.)";
                        case 2:
                            return "(Must be dreaming about fighting monsters alongside you.)";
                    }
                case SleepingMessageContext.OnWokeUp:
                    return "[nickname], It's too early... Let me sleep some more.";
                case SleepingMessageContext.OnWokeUpWithRequestActive:
                    return "[nickname], you woke me up. Did you do my request?";
            }
            return base.SleepingMessage(companion, context);
        }

        public override string OnToggleShareBedsMessage(Companion companion, bool Share)
        {
            if (Share) return "Fine. Try not being greedy and take my share of the bed.";
            return "I hope there's another bed for me.";
        }

        public override string OnToggleShareChairMessage(Companion companion, bool Share)
        {
            if (Share) return "Okay, just don't let me fall.";
            return "I'll take another chair then.";
        }

        public override string TacticChangeMessage(Companion companion, TacticsChangeContext context) //For when talking about changing their combat behavior.
        {
            switch(context)
            {
                case TacticsChangeContext.OnAskToChangeTactic:
                    return "[nickname], you want me to change how I fight?";
                case TacticsChangeContext.ChangeToCloseRange:
                    return "Yes! That's what I've been made for.";
                case TacticsChangeContext.ChangeToMidRanged:
                    return "Alright, if you say so.";
                case TacticsChangeContext.ChangeToLongRanged:
                    return "I don't actually like that idea, but I will do as you say.";
                case TacticsChangeContext.Nevermind:
                    return "How I take on combat is fine then?";
            }
            return base.TacticChangeMessage(companion, context);
        }

        public override string TalkAboutOtherTopicsMessage(Companion companion, TalkAboutOtherTopicsContext context) //FOr when going to speak about other things.
        {
            switch(context)
            {
                case TalkAboutOtherTopicsContext.FirstTimeInThisDialogue:
                    return "Do you want to speak about something else?";
                case TalkAboutOtherTopicsContext.AfterFirstTime:
                    return "Is there something else you want to talk about?";
                case TalkAboutOtherTopicsContext.Nevermind:
                    return "Alright.";
            }
            return base.TalkAboutOtherTopicsMessage(companion, context);
        }

        public override void ManageOtherTopicsDialogue(Companion companion, MessageDialogue dialogue) //Allow you to add new dialogues to the other topics dialogue. There's one for lobby dialogues too.
        {
            dialogue.AddOptionAtTop("How are you feeling today?", PersonalChat); //Adds option at the top of the dialogue.
        }

        private void PersonalChat()
        {
            MultiStepDialogue m = new MultiStepDialogue(new string[]{"Me? I'm feeling fine.", "What about you, [nickname]?"}); //For dialogues with multiple steps before offering a choice.
            m.AddOption("I'm feeling fine.", OnAnswerFeelingFine); //One of the dialogue options. The options must be linked to a void method without arguments.
            m.AddOption("I'm not feeling really well.", OnAnswerNotFeelingFine);
            m.RunDialogue(); //Always use RunDialogue() method after setting up the dialogue, or else the dialogue will not appear, and you will have wasted your time.
        }

        private void OnAnswerFeelingFine()
        {
            MessageDialogue m = new MessageDialogue("I'm glad that you're feeling fine, [nickname].");
            m.AddOption("Thanks.", OnEndDialogue);
            m.RunDialogue();
        }

        private void OnAnswerNotFeelingFine()
        {
            MessageDialogue m = new MessageDialogue("Don't worry [nickname], I'm here, hoping you'll feel fine soon.");
            m.AddOption("Thanks.", OnEndDialogue);
            m.RunDialogue();
        }

        private void OnEndDialogue()
        {
            Dialogue.TalkAboutOtherTopicsDialogue("Let's chat again some time soon."); //This takes you back to the Talking about other things topic, but will also change the message displayed when it does so.
        }
    }
}