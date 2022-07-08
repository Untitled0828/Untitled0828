using Aki.Reflection.Patching;
using EFT.Interactive;
using System.Reflection;

#nullable enable
namespace UntitledMod
{
    // Minefield.method_3
    [Patch(typeof(Minefield), "method_3")]
    public class RemoveMineDmgPatch : Patch
    {
        [PatchPrefix]
        private static bool Patch()
        {
            return !Core.RemoveMineDamage.Value;
        }

    }
}