using terraguardians;
using Terraria;
using Terraria.ModLoader;

namespace gaomonmod1dot4
{
    public class CustomModHooks : CompanionHookContainer
    {
        //This is like a folder for hooks useable by the mod.
        //This one allows getting skins and outfits containers for specific companions. 
        //Use mod id and companion id to find out who this is called for.
        public override CompanionSkinContainer OnLoadSkinsAndOutfitsContainer(uint CompanionID, string CompanionModID)
        {
            if (CompanionModID == "terraguardians")
            {
                switch (CompanionID)
                {
                    case CompanionDB.Blue:
                        return new CustomSkins.BlueCustomSkins();
                }
            }
            return base.OnLoadSkinsAndOutfitsContainer(CompanionID, CompanionModID);
        }
    }
}