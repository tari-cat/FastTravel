using BepInEx;
using System.IO;

namespace FastTravel
{
    [BepInPlugin(PluginMetadata.GUID, PluginMetadata.Name, PluginMetadata.Version)]
    [BepInDependency("dance.tari.bombrushcyberfunk.customappapi")]
    [BepInProcess("Bomb Rush Cyberfunk.exe")]
    public class FastTravelMod : BaseUnityPlugin
    {

        private static FastTravelMod _modInstance;
        public static FastTravelMod Instance => _modInstance;

        public string ModFolderPath => Path.GetDirectoryName(Info.Location);

        public static BepInEx.Logging.ManualLogSource Log => _modInstance.Logger;

        // Unity Functions

        private void Awake()
        {
            _modInstance = this;

            Logger.LogInfo($"Plugin {PluginMetadata.Name} loaded successfully.");
        }
    }
}
