#nullable enable
namespace UntitledMod
{

    public static class InstantSearch
    {
        private static float? AttentionEliteLuckySearch = null;

        private static int? AttentionLevel = null;
        public static void Change(bool tf)
        {
            if (AttentionLevel is null)
            {
                AttentionLevel = Core.Profile.Skills.Attention.Level;
            }
            if (AttentionEliteLuckySearch is null)
            {
                AttentionEliteLuckySearch = Core.Profile.Skills.AttentionEliteLuckySearch.Value;
            }

            if (tf)
            {
                Core.Profile.Skills.Attention.SetLevel(51);
                Core.Profile.Skills.AttentionEliteLuckySearch.Value = 1f;
            }
            else
            {
                if (Core.Profile.Skills.AttentionEliteLuckySearch.Value == 1f)
                {
                    Core.Profile.Skills.AttentionEliteLuckySearch.Value = (float)AttentionEliteLuckySearch;
                    Core.Profile.Skills.Attention.SetLevel((int)AttentionLevel);
                }
            }
        }
    }
}