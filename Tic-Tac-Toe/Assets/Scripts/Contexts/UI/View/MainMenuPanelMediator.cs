namespace Contexts.UI.View
{
    public class MainMenuPanelMediator : UIPanelMediator<MainMenuPanelView, MainMenuPanelData>
    {
        // [Inject]
        
        public override void OnRegister()
        {
            base.OnRegister();
            View.OnStartButtonClick += OnStartButtonClickHandler;
        }

        private void OnStartButtonClickHandler()
        {
            throw new System.NotImplementedException();
        }
    }
}