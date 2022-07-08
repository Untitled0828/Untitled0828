/**
 * Made By Untitled
 * 
 * info: Weapon.GetDurabilityLossOnShot 의 함수의 결과값(return [type:float] 을 0f로 반환 하게 하는 패치입니다.
 *
 * 해당 함수는 총기의 내구도 감소값을 반환하는 함수입니다. 그러므로 0을 반환해 내구도 감소를 제거하는 방식입니다.
 *
 * 해당 패치방식은 Aki.Reflection (SPT.AKI 기본 모듈)을 통한 예시입니다.
**/

using Aki.Reflection.Patching;
using Aki.Reflection.Utils;
using System.Reflection;

using EFT.InventoryLogic;

namespace WeaponMalfunction
{
    public class RemoveDurabilityBurnPatch : ModulePatch
    {
        // Weapon.GetDurabilityLossOnShot
        protected override MethodBase GetTargetMethod()
        {
            return typeof(Weapon).GetMethod(nameof(Weapon.GetDurabilityLossOnShot), PatchConstants.PrivateFlags);
        }

        [PatchPostfix] // 오리지널 함수 실행후 마지막에 실행.
        private static void Patch(ref float __result)
        {
            if (WeaponPatchPlugin.Enabled.Value)
                __result = 0f;
        }
    }
}
