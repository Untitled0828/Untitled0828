/**
 * Made By Untitled
 * 
 * info: FirearmController.GetMalfunctionState 의 함수의 결과값(return [type:Weapon.EMalfunctionState] 을 Weapon.EMalfunctionState.None으로 반환 하게 하는 패치입니다.
 *
 * 해당 함수는 총기의 고장이유를 반환하는 함수입니다. 이유를 None로 반환해 고장이 안나게 하는 패치입니다.
 *
 * 해당 패치방식은 Aki.Reflection (SPT.AKI 기본 모듈)을 통한 예시입니다.
**/

using Aki.Reflection.Patching;
using EFT.InventoryLogic;
using Untitled.Reflection;

namespace WeaponMalfunction
{
    // FirearmController.GetMalfunctionState
    [Patch("FirearmController", "GetMalfunctionState")]
    public class WeaponMalfunctionPatch : Patch 
    {
        [PatchPostfix]
        private static void Patch(ref Weapon.EMalfunctionState __result)
        {
            if (WeaponPatchPlugin.Enabled.Value)
                __result = Weapon.EMalfunctionState.None;
        }
    }
}
