using Aki.Reflection.Patching;
using System.Reflection;

#nullable enable
namespace UntitledMod
{
    // EBodyPart bodyPart, float damage, DamageInfo damageInfo
    [Patch(true, "bodyPart", "damage", "damageInfo")]
    public class DamagePatch : Patch
    {
        [PatchPrefix]
        private static bool Patch(DamageInfo damageInfo)
        {
            if (Core.RemoveFallDamage.Value && damageInfo.DamageType is EDamageType.Fall)
            {
                return false;
            }
            return true;
        }
    }
}