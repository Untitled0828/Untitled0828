namespace UntitledMod
{
    [BepInPlugin("com.Untitled." + Core.ModName, Core.ModName, Core.ModVersion)]
    public class ConfigPlugin : PatchUnityPlugin
    {
        private void Awake()
        {
            string SectionName = Core.PatchSectionName;
            Core.InstantSearch = Config.Bind(SectionName, "InstantSearch", false, new ConfigDescription("컨테이너속 서치이벤트를 즉시 완료 합니다."));
            Core.AllExamined = Config.Bind(SectionName, "AllExamined", false, new ConfigDescription("All Examined"));
            Core.SprintPatch = Config.Bind(SectionName, "SprintPatch", false, new ConfigDescription("철조망에서 달릴 수 있습니다. (철조망 데미지제거)"));
            Core.RemoveFallDamage = Config.Bind(SectionName, "RemoveFallDamage", false, new ConfigDescription("낙하 데미지 활성화/비활성화"));
            Core.RemoveMineDamage = Config.Bind(SectionName, "RemoveMineDamage", false, new ConfigDescription("지뢰 데미지 활성화/비활성화"));
            Core.MasterKey = Config.Bind(SectionName, "MasterKey", false, new ConfigDescription("마스터 키 활성화/비활성화"));

            Config.SettingChanged += Config_SettingChanged;
        }

        private void Config_SettingChanged(object sender, SettingChangedEventArgs e)
        {
            string key = e.ChangedSetting.Definition.Key;
            object value = e.ChangedSetting.BoxedValue;
            if (key is "InstantSearch")
            {
                InstantSearch.Change((bool)value);
            }
        }
    }

    public static class Core
    {
        internal static Profile Profile;

        internal static ManualLogSource LogSource = BepInEx.Logging.Logger.CreateLogSource(ModName);
        internal const string ModName = "UntitledPatch";
        internal const string ModVersion = "3.0.0";
        internal const string PatchSectionName = "Patch";
        internal static ConfigEntry<bool> InstantSearch;
        internal static ConfigEntry<bool> AllExamined;
        internal static ConfigEntry<bool> SprintPatch;
        internal static ConfigEntry<bool> RemoveFallDamage;
        internal static ConfigEntry<bool> RemoveMineDamage;
        internal static ConfigEntry<bool> MasterKey;
    }
}
