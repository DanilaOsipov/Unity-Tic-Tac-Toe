using Common;
using Configs;
using Contexts.Main.Model;

namespace Contexts.Main.Command
{
    public class LoadUIPanelsConfigsCommand : LoadConfigsCommand<UIPanelsLibraryModel, UIPanelConfig>
    {
        protected override string GetPath() => ResourcesPaths.UI_PANELS_CONFIGS;
    }
}