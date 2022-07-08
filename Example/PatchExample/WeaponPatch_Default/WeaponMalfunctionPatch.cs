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
using Aki.Reflection.Utils;
using System.Reflection;

using EFT.InventoryLogic;
using static EFT.Player;

namespace WeaponMalfunction
{
    public class WeaponMalfunctionPatch : ModulePatch
    {
         // FirearmController.GetMalfunctionState
        protected override MethodBase GetTargetMethod()
        {
            return typeof(FirearmController).GetMethod(nameof(FirearmController.GetMalfunctionState), PatchConstants.PrivateFlags);
        }

        [PatchPostfix]  // 오리지널 함수 실행후 마지막에 실행.
        private static void Patch(ref Weapon.EMalfunctionState __result)
        {
            if (WeaponPatchPlugin.Enabled.Value)
                __result = Weapon.EMalfunctionState.None;
        }
    }
}
