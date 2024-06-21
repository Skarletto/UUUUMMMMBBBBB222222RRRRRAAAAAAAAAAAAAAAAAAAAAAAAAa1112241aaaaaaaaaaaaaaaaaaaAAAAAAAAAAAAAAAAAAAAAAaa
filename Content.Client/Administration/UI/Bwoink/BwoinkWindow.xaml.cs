using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.CustomControls;
using Robust.Client.UserInterface.XAML;

namespace Content.Client.Administration.UI.Bwoink
{
    /// <summary>
    /// This window connects to a BwoinkSystem channel. BwoinkSystem manages the rest.
    /// </summary>
    [GenerateTypedNameReferences]
    public sealed partial class BwoinkWindow : DefaultWindow
    {
        public BwoinkWindow()
        {
            RobustXamlLoader.Load(this);

            Bwoink.ChannelSelector.OnSelectionChanged += sel =>
            {
                if (sel is null)
                {
                    Title = Loc.GetString("bwoink-title-none-selected");
                    return;
                }

                Title = $"{sel.CharacterName} / {sel.Username}";

                if (sel.OverallPlaytime != null)
                {
                    Title += $" | {Loc.GetString("generic-playtime-title")}: {sel.PlaytimeString}";
                }
            };

            OnOpen += () => Bwoink.PopulateList();
        }
    }
}
