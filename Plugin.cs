using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

namespace SpitterChicken;

[BepInPlugin("mathmoth.spitterchicken", "SpitterChicken", "1.0.0")]
public class Plugin : BasePlugin
{
    public override void Load()
    {
        Harmony.CreateAndPatchAll(typeof(InfectionSpitterPatch), "mathmoth");
        Log.LogInfo("SpitterChicken by Mathmoth is loaded!");

    }
}

internal static class InfectionSpitterPatch
{
    [HarmonyPatch(typeof(InfectionSpitter), "TryPlaySound")]
    [HarmonyPrefix]

    public static bool Prefix(ref uint id, bool dontPlayTooOften, float dontPlayTooOftenDelay, ref bool __result, object __instance) {

        //3124402583 corresponds to the soundId of INFECTION_SPITTER_SPIT
        if (id == 3124402583) {
            //1256202815 corresponds to the soundId of the chicken spitter in the soundbank
            id = 1256202815;
        }

        return true;
    }
}