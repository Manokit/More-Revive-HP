using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using More_Revive_HP.Patches;
using BepInEx.Configuration;

[BepInPlugin(modGUID, modName, modVersion)]
public class Plugin : BaseUnityPlugin
{

    public const string modGUID = "Tidaleus.MoreReviveHP";
    public const string modName = "More Revive HP";
    public const string modVersion = "1.0.0";

    private readonly Harmony harmony = new Harmony(modGUID);

    private static Plugin Instance;

    // Configuration fields
    private ConfigEntry<int> ExtraHealth;


    void Awake()
    {

        Logger.LogInfo($"{modGUID} has loaded");

        if (Instance == null)
        {
            Instance = this;
        }

        ExtraHealth = Config.Bind("General", "DuplicationAmount", 19, "Extra Health to add to the 1 you spawn with, therefore make this something 1 through 99.");


        harmony.PatchAll(typeof(Plugin));
        harmony.PatchAll(typeof(PlayerAvatarPatch));
    }

    public static int GetExtraHealth() => Instance.ExtraHealth.Value;

}

