using Aki.Reflection.Patching;
using EFT.InventoryLogic;
using System.Reflection;

#nullable enable
namespace UntitledMod
{
    // Profile.Examined
    [Patch(typeof(Profile), nameof(Profile.Examined), new[] {typeof(string) })]
    public class AllExaminedPatch1 : Patch
    {
        [PatchPrefix]
        private static bool Patch(ref bool __result)
        {
            if (Core.AllExamined.Value)
            {
                __result = true;
                return false;
            }
            return true;
        }
    }

    [Patch(typeof(Profile), nameof(Profile.Examined), new[] {typeof(Item) })]
    public class AllExaminedPatch2 : Patch
    {
        [PatchPrefix]
        private static bool Patch(ref bool __result)
        {
            if (Core.AllExamined.Value)
            {
                __result = true;
                return false;
            }
            return true;
        }
    }
}