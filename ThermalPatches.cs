
using SPT.Reflection.Patching;
using System;
using System.Reflection;

namespace ClearView {
    internal class ThermalPatches {
        //method_1
        internal class ThermalOnEnable : ModulePatch {
            protected override MethodBase GetTargetMethod() => typeof(ThermalVision).GetMethod("method_1");

            [PatchPrefix]
            public static void OnEnable(ThermalVision __instance) {
                Console.WriteLine("Thermal enabled/disabled?");
                Console.WriteLine(__instance.On);
            }
        }
    }
}
