using Aki.Reflection.Patching;
using EFT.Animals;


#nullable enable
namespace UntitledMod
{
    [Patch("Item", "get_DiscardLimit")]
    public class DiscardLimitPatch : Patch
    {
        [PatchPostfix]
        private static void Patch(int? __result)
        {
            ConsoleScreen.Log(__result.ToString());
            __result = null;
        }
    }
}