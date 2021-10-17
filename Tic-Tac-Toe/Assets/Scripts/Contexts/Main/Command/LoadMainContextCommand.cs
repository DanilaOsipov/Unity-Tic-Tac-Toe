using Common;
using Contexts.Base.Command;
using Contexts.UI;

namespace Contexts.Main.Command
{
    public class LoadMainContextCommand : LoadContextCommand
    {
        protected override string GetContextSceneName() => ContextSceneNames.MAIN_SCENE;

        protected override void ContextLoadedHandler()
        {
            base.ContextLoadedHandler();
            injectionBinder.GetInstance<LoadUIPanelSignal>().Dispatch(UIPanelPaths.MAIN_MENU_PATH);
        }
    }
}