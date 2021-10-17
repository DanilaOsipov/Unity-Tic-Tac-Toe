using Common;

namespace Contexts.UI.View
{
    public class MainMenuPanelView : UIPanelView<MainMenuPanelData>
    {
        public override UIPanelType Type => UIPanelType.MainMenuPanel;
        
        protected override void UpdateView(MainMenuPanelData data)
        {
            throw new System.NotImplementedException();
        }
    }
    
    public class MainMenuPanelData : UIPanelData
    {
    }
}