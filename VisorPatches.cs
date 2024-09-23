using SPT.Reflection.Patching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClearView {
    internal class VisorPatches {
        internal class VisorOnEnable : ModulePatch {
            protected override MethodBase GetTargetMethod() => typeof(VisorEffect).GetMethod("OnEnable");

            [PatchPrefix]
            public static void OnEnable(VisorEffect __instance) {
                __instance.Visible = !ClearView.HideVisorOverlay.Value;
                __instance.Intensity = ClearView.VisorEffectIntensity.Value;
            }
        }

        internal class VisorApplySettings : ModulePatch {

            protected override MethodBase GetTargetMethod() => typeof(VisorEffect).GetMethod("method_2");

            [PatchPrefix]
            public static void method_2(VisorEffect __instance) {
                __instance.DistortIntensity = ClearView.DistortIntensity.Value;
                __instance.ScratcesIntensity = ClearView.ScratchesIntensity.Value;
                __instance.blurIterations = ClearView.BlurIterations.Value;
                __instance.blurSize = ClearView.BlurSize.Value;
            }
        }
    }
}
