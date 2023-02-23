using Terraria.ModLoader;
using terraguardians;
using gaomonmod1dot4.Companions;

namespace gaomonmod1dot4
{
    public class DigimonContainer : CompanionContainer //Must inherit CompanionContainer
    {
        public const uint Gaomon = 0;

        public override CompanionBase GetCompanionDB(uint ID) //This overrideable method will be used to get the companion base infos. Use each ID for different companions as you seem fit.
        {
            switch(ID)
            {
                case Gaomon: //Gaomon equals to 0. So calling a companion of ID 0, and set the ModID as the name of this mod, will be refering to Gaomon.
                    return new GaomonBase(); //The base infos of Gaomon. This will only be called once, and be stored internally into a database of the mod.
            }
            return base.GetCompanionDB(ID);
        }
    }
}