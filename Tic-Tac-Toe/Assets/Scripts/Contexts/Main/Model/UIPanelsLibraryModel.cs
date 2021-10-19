using Common;
using Configs;
using Contexts.UI.View;

namespace Contexts.Main.Model
{
    public class UIPanelsLibraryModel : LibraryModel<UIPanelConfig>
    {
        public UIPanelConfig GetUIPanelConfig(UIPanelType type)
        {
            return _libraryData.Find(x => x.Type == type);
        }
    }
}