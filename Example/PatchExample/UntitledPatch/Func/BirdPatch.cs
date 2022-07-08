using Aki.Reflection.Patching;
using EFT.Animals;
using System.Linq;
using System.Reflection;
using System.Text;


#nullable enable
namespace UntitledMod
{
    [Patch(typeof(BirdsSpawner), nameof(BirdsSpawner.Spawn), new[] { typeof(int) })]
    public class BirdPatch : Patch
    {
        [PatchPrefix]
        private static bool Patch(int count)
        {
            return false;
        }
    }
}