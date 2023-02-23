using Terraria.ModLoader;
using terraguardians;
using Terraria;

namespace gaomonmod1dot4
{
	public class NpcMod : GlobalNPC
	{
        public override bool PreAI(NPC npc)
        {
            if (npc.type == Terraria.ID.NPCID.BlueSlime && npc.ai[1] == 0)
            {
                int NearestPlayer = npc.FindClosestPlayer();
                //Makes so if Gaomon haven't been met, and neither there's its companion npc in the world, the Digivice can spawn in a slime.
                if (NearestPlayer > -1 && !terraguardians.WorldMod.HasMetCompanion(DigimonContainer.Gaomon, Mod.Name) && !terraguardians.WorldMod.HasCompanionNPCSpawned(DigimonContainer.Gaomon, Mod.Name) && Main.rand.Next(10) == 0)
                {
                    npc.ai[1] = ModContent.ItemType<Items.BlueDigivice>();
                    npc.netUpdate = true;
                }
            }
            return base.PreAI(npc);
        }
    }
}