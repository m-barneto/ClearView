using BepInEx;
using BepInEx.Configuration;
using SPT.Reflection.Patching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanVisor {
    [BepInPlugin("Mattdokn.CleanVisor", "CleanVisor", "1.0.0")]
    public class CleanVisor : BaseUnityPlugin {
        public static ConfigEntry<bool> hideVisorOverlay;


        private void Awake() {
            hideVisorOverlay = Config.Bind("General", "Hide Visor Overlay", false, "If true, will hide the overlay.");

            new VisorEffectPatch().Enable();
            new VisorEffectPatch2().Enable();
        }
    }

    internal class VisorEffectPatch : ModulePatch {
        protected override MethodBase GetTargetMethod() => typeof(VisorEffect).GetMethod("OnEnable");

        [PatchPrefix]
        public static void OnEnable(VisorEffect __instance) {
            Console.WriteLine("IDK man cmon");
            __instance.Visible = !CleanVisor.hideVisorOverlay.Value;
        }
    }

    internal class VisorEffectPatch2 : ModulePatch {
        protected override MethodBase GetTargetMethod() => typeof(VisorEffect).GetMethod("SetIntensity");

        [PatchPrefix]
        public static void SetIntensity(VisorEffect __instance, ref float intensity) {
            Console.WriteLine($"RAAAA {intensity}");
            intensity = 0.5f;
            //__instance.Visible = false;
        }
    }

    internal class VisorEffectPatch3 : ModulePatch {
        
        protected override MethodBase GetTargetMethod() => typeof(VisorEffect).GetMethod("method_2");

        [PatchPrefix]
        public static void method_2(VisorEffect __instance) {
            Console.WriteLine($"gyuhg");
            __instance.
            //__instance.Visible = false;
        }
    }
}
