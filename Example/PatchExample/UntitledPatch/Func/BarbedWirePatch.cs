using Aki.Reflection.Patching;
using System.Reflection;

#nullable enable
namespace UntitledMod
{
    [Patch("BarbedWire", "ProceedDamage")]
    public class BarbedWirePatch : Patch
    {

        [PatchPrefix]
        private static bool Patch(Player player)
        {
            if (Core.SprintPatch.Value)
            {
                return !player.IsYourPlayer;
            }
            return true;
        }
    }
}