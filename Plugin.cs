using BepInEx;
using BepInEx.Configuration;
using static ClearView.VisorPatches;

namespace ClearView {
    [BepInPlugin("Mattdokn.ClearView", "ClearView", "0.0.1")]
    public class ClearView : BaseUnityPlugin {
        public static ConfigEntry<bool> HideVisorOverlay;

        public static ConfigEntry<float> VisorEffectIntensity;
        public static ConfigEntry<float> DistortIntensity;
        public static ConfigEntry<float> ScratchesIntensity;
        public static ConfigEntry<int> BlurIterations;
        public static ConfigEntry<float> BlurSize;


        private void Awake() {
            HideVisorOverlay = Config.Bind("Visor", "Hide Visor Overlay", false, "If true, will hide the overlay.");
            VisorEffectIntensity = Config.Bind("Visor", "Visor Effect Intensity", 1f, "How strong the overall visor effects are.");
            DistortIntensity = Config.Bind("Visor", "Distortion Intensity", 0f, "Distortion effect intensity. (Default 0.0075)");
            ScratchesIntensity = Config.Bind("Visor", "Scratches Intensity", 0f, "Scratches texture intensity. (Default 0.45)");
            BlurIterations = Config.Bind("Visor", "Blur Effect Iterations", 0, "How many passes the blur shader will be run. (Default 2)");
            BlurSize = Config.Bind("Visor", "Blur Size", 0f, "How blurry it'll be. (Default 1.5)");

            new VisorOnEnable().Enable();
            new VisorApplySettings().Enable();
        }
    }
}
