using Terraria.ModLoader;
using terraguardians;

namespace gaomonmod1dot4
{
	public class MainMod : Mod
	{
		public static Groups.DigimonGroup digimonGroup; //Custom companion group, so you can distinguish companions of a certain type by their group.

		public override void Load()
		{
			digimonGroup = new Groups.DigimonGroup(); //Creating the companion group, so I can assign it to companions.
		}

		public override void Unload()
		{
			digimonGroup = null;
		}

		public override void PostSetupContent()
		{
			terraguardians.MainMod.AddCompanionDB(new DigimonContainer(), this); //Adding the companion container I made to the companion database. That will control the companions list of the mod. Check DigimonContainer.cs.
		}
	}
}