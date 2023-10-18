using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria.DataStructures;
using terraguardians;

namespace gaomonmod1dot4.CustomSkins.Blue
{
    public class GaomonSkinTest : CompanionSkinInfo 
    {
        //This test skin changes Blue body sprites for one that look closelly to Gaomon.
        //It's just one frame that changes, but seems more than enough to show it working.
        public override string Name => "Gaomon Test Skin";
        public override string Description => "It's just one frame.";

        protected override void OnLoad()
        {
            AddTexture("body", "gaomonmod1dot4/CustomSkins/Blue/gaomon/body_g"); //Textures have string as id, followed by their path, including mod name.
            AddTexture("left_arm", "gaomonmod1dot4/CustomSkins/Blue/gaomon/left_arm_g");
            AddTexture("right_arm", "gaomonmod1dot4/CustomSkins/Blue/gaomon/right_arm_g");
        }

        //Replaces the body part textures with the Skin texture.
        //This is handy because will let people making Outfits know which body part is which, when looking for the textures.
        public override void PreDrawCompanions(Companion c, ref PlayerDrawSet drawSet, ref TgDrawInfoHolder Holder)
        {
            Holder.BodyTexture = GetTexture("body");
            Holder.ArmTexture[0] = GetTexture("left_arm");
            Holder.ArmTexture[1] = GetTexture("right_arm");
        }

        /*public override void CompanionDrawLayerSetup(Companion c, bool IsDrawingFrontLayer, PlayerDrawSet drawSet, ref TgDrawInfoHolder Holder, ref List<DrawData> DrawDatas)
        {
            //Old method. Basically, find the body texture and replace it, but the new method is aimed towards avoiding conflict with outfits.
            CompanionSpritesContainer spr = c.Base.GetSpriteContainer;
            for(int i = 0; i < DrawDatas.Count; i++)
            {
                if (DrawDatas[i].texture == spr.BodyTexture)
                {
                    DrawData dd = DrawDatas[i];
                    ReplaceTexture(GetTexture("body"), ref dd);
                    DrawDatas[i] = dd;
                }
                else if (DrawDatas[i].texture == spr.ArmSpritesTexture[0])
                {
                    DrawData dd = DrawDatas[i];
                    ReplaceTexture(GetTexture("left_arm"), ref dd);
                    DrawDatas[i] = dd;
                }
                else if (DrawDatas[i].texture == spr.ArmSpritesTexture[1])
                {
                    DrawData dd = DrawDatas[i];
                    ReplaceTexture(GetTexture("right_arm"), ref dd);
                    DrawDatas[i] = dd;
                }
            }
        }

        void ReplaceTexture(Texture2D NewTexture, ref DrawData dd) //Method made to help replace texture.
        {
            DrawData ndd = new DrawData(NewTexture, dd.position, dd.sourceRect, dd.color, dd.rotation, dd.origin, dd.scale.Y, dd.effect, 0);
            dd = ndd;
        }*/
    }
}