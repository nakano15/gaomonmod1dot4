using Terraria;
using terraguardians;
using System.Collections.Generic;

namespace gaomonmod1dot4.Companions.Gaomon
{
    //Contains the dialogues of the companion. Must extend CompanionDialogueContainer.
    public class GaomonDialogues : CompanionDialogueContainer //Must be assigned on the companion base file, setting it as the value of "GetDialogueContainer" overrideable method.
    {
        //This flag makes certain dialogues only trigger the translation version of the code, when necessary.
        //This was added to keep part of the original code in.
        const bool UseTranslation = true;
        public override string GreetMessages(Companion companion) //Messages for when you just met the companion.
        {
            // You can return text with translation support or not.
            // Should you decide to add translation support, check "Localization/en-US_Mods.gaomonmod1dot4.hjson" for how to add the keys.
            // Do notice that the name of the companion on the translation file, is the same as the "Name" field of the companion.
            if (UseTranslation)
                //If you want to add custom translation support, use the method bellow to get this companion translation.
                return GetTranslation("greet1");
            else
                // You can still return untranslated text too.
                return "Woah! Are you my new master?";
        }

        public override string NormalMessages(Companion companion) //Normal chitchat. If you want to get player reference, use MainMod.GetLocalPlayer.
        {
            List<string> Mes = new List<string>();
            //Gets translated text from localization file, from "normal" entries from 1 to 6, and places the result on "Mes" string array.
            GetTranslationRange("normal", 1, 6, Mes);
            if (!Main.dayTime)
            {
                if (Main.bloodMoon)
                {
                    //You can also return the translation texts one by one too, but TranslationRange was made to avoid this kind of case.
                    Mes.Add(GetTranslation("normal7"));
                    Mes.Add(GetTranslation("normal8"));
                    Mes.Add(GetTranslation("normal9"));
                }
                else
                {
                    GetTranslationRange("normal", 10, 11, Mes);
                }
            }
            else
            {
                if (Main.eclipse)
                {
                    GetTranslationRange("normal", 12, 13, Mes);
                }
                else
                {
                    GetTranslationRange("normal", 14, 15, Mes);
                }
            }
            if (Main.raining && !Main.eclipse && !Main.bloodMoon)
            {
                GetTranslationRange("normal", 16, 18, Mes);
            }
            if (Main.hardMode)
            {
                Mes.Add(GetTranslation("normal19"));
            }
            if (NPC.AnyNPCs(Terraria.ID.NPCID.Guide)) //[nn:number] gets the name of the npc of the id you set at the number. ID 22 is the Guide.
            {
                if (!UseTranslation)
                    Mes.Add("I have been talking with [nn:22], and he said that the reason I'm here, is because of third party intervention. What does that mean?");
                else
                    Mes.Add(GetTranslation("normal20"));
            }
            if (NPC.AnyNPCs(Terraria.ID.NPCID.Merchant))
            {
                Mes.Add(GetTranslation("normal21"));
            }
            if (NPC.AnyNPCs(Terraria.ID.NPCID.Nurse))
            {
                Mes.Add(GetTranslation("normal22"));
            }

            if (WorldMod.GetTerraGuardiansCount > 0)
            {
                GetTranslationRange("normal", 23, 25, Mes);
            }

            if (WorldMod.HasCompanionNPCSpawned(terraguardians.CompanionDB.Rococo)) //Checks if there's a npc of this companion ID spawned in the world. Add ModName as an argument after the ID to get another mod companion instead.
            {
                if (!UseTranslation)
                    //[gn:id:modid] gets the name of the companion whose ID and ModID are supplied. Leaving without mod id will make the mod automatically get a TerraGuardian mod companion.
                    Mes.Add("[gn:0] asked me earlier If I'm like him. It didn't looked like he liked to know that I'm not.");
                else
                    Mes.Add(GetTranslation("normal26"));
            }
            if (WorldMod.HasCompanionNPCSpawned(terraguardians.CompanionDB.Blue))
            {
                if (WorldMod.HasCompanionNPCSpawned(terraguardians.CompanionDB.Zacks))
                {
                    Mes.Add(GetTranslation("normal27"));
                }
                else
                {
                    Mes.Add(GetTranslation("normal28"));
                }
            }
            if (WorldMod.HasCompanionNPCSpawned(terraguardians.CompanionDB.Sardine) || WorldMod.HasCompanionNPCSpawned(terraguardians.CompanionDB.Bree))
            {
                Mes.Add(GetTranslation("normal29"));
            }
            if (WorldMod.HasCompanionNPCSpawned(terraguardians.CompanionDB.Zacks))
            {
                Mes.Add(GetTranslation("normal30"));
            }
            if (WorldMod.HasCompanionNPCSpawned(terraguardians.CompanionDB.Brutus))
            {
                Mes.Add(GetTranslation("normal31"));
            }
            return Mes[Terraria.Main.rand.Next(Mes.Count)];
        }

        public override string TalkMessages(Companion companion) //This message only appears if you speak with a companion whose friendship exp increases.
        {
            List<string> Mes = new List<string>();
            GetTranslationRange("talk", 1, 3, Mes);
            //You can still be creative on how to make some dialogues work.
            //Here I created the [evil] tag, to replace for current world ailment.
            Mes.Add(GetTranslation("talk4").Replace("[evil]", WorldGen.crimson ? "Crimson" : "Corruption") + " creepy.");
            if (companion.Male && WorldMod.HasCompanionNPCSpawned(terraguardians.CompanionDB.Blue))
            {
                //You actually will need the help of CompanionDB to figure out who "gn:1" is. In this case, Gaomon is talking about Blue.
                if (!UseTranslation)
                    Mes.Add("Why does [gn:1] rejects me? Is It because I'm small?");
                else
                    Mes.Add(GetTranslation("talk5"));
            }
            return Mes[Terraria.Main.rand.Next(Mes.Count)];
        }

        public override string RequestMessages(Companion companion, RequestContext context) //Messages regarding requests. The contexts are used to let you know which cases the message will use.
        {
            switch(context)
            {
                case RequestContext.NoRequest:
                    {
                        //Gets one random "norequest" translation, from indexes 1 and 2.
                        return GetTranslationRandom("norequest", 1, 2);
                    }
                case RequestContext.HasRequest:
                    {
                        return GetTranslationRandom("hasrequest", 1, 2);
                    }
                case RequestContext.Completed:
                    {
                        return GetTranslationRandom("completedrequest", 1, 2);
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
            //Companion object also has a "GetTranslation" method. Use that to get companion specific translation with ease.
            dialogue.AddOptionAtTop(companion.GetTranslation("pcoption1"), PersonalChat); //Adds option at the top of the dialogue.
        }

        private void PersonalChat()
        {
            MultiStepDialogue m = new MultiStepDialogue( new string[]{ 
                //With the absence of Companion object on the dialogue, use "Dialogue.Speaker" to get the speaker of the dialogue, and call translation.
                Dialogue.Speaker.GetTranslation("pcanswer1"), 
                Dialogue.Speaker.GetTranslation("pcanswer2")
            }); //For dialogues with multiple steps before offering a choice.
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