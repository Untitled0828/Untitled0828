using Aki.Reflection.Patching;
using System.Linq;
using System.Reflection;
using System.Text;

#nullable enable
namespace UntitledMod
{
    // MainApplication.method_40
    [Patch("MainApplication", "method_40")] //Local game starting... 해당 클래스에서 검색
    public class GetProfilePatch : Patch
    {
        [PatchPrefix]
        private static void Patch(ref GInterface29 ____backEnd)
        {
            Core.Profile = ____backEnd.Session.Profile;
            InstantSearch.Change(Core.InstantSearch.Value);
        }
    }

}
