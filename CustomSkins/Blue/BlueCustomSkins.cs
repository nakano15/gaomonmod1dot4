using terraguardians;
using Terraria;
using Terraria.ModLoader;
using gaomonmod1dot4.CustomSkins.Blue;

namespace gaomonmod1dot4.CustomSkins
{
    //This is a custom container made specifically for Blue custom Skins and Outfits.
    //Override OnLoad() method, and use AddSkin preceded by a id from 0~255 to add a new skin to the companion.
    //The same can also be done with outfits by using AddOutfit instead.
    public class BlueCustomSkins : CompanionSkinContainer
    {
        public override void OnLoad()
        {
            AddSkin(0, new GaomonSkinTest());
        }
    }
}