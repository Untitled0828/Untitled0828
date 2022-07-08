namespace UntitledMod
{
    [BepInPlugin("com.Untitled." + Core.ModName, Core.ModName, Core.ModVersion)]
    public class ConfigPlugin : PatchUnityPlugin
    {
        private void Awake()
        {
            string SectionName = Core.PatchSectionName;
            Core.InstantSearch = Config.Bind(SectionName, "InstantSearch", false, new ConfigDescription("�����̳ʼ� ��ġ�̺�Ʈ�� ��� �Ϸ� �մϴ�."));
            Core.AllExamined = Config.Bind(SectionName, "AllExamined", false, new ConfigDescription("All Examined"));
            Core.SprintPatch = Config.Bind(SectionName, "SprintPatch", false, new ConfigDescription("ö�������� �޸� �� �ֽ��ϴ�. (ö���� ����������)"));
            Core.RemoveFallDamage = Config.Bind(SectionName, "RemoveFallDamage", false, new ConfigDescription("���� ������ Ȱ��ȭ/��Ȱ��ȭ"));
            Core.RemoveMineDamage = Config.Bind(SectionName, "RemoveMineDamage", false, new ConfigDescription("���� ������ Ȱ��ȭ/��Ȱ��ȭ"));
            Core.MasterKey = Config.Bind(SectionName, "MasterKey", false, new ConfigDescription("������ Ű Ȱ��ȭ/��Ȱ��ȭ"));

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
