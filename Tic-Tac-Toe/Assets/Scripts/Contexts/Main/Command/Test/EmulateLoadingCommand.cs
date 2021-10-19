using Common;
using Contexts.UI;

namespace Contexts.Main.Command.Test
{
    public class EmulateLoadingCommand : strange.extensions.command.impl.Command
    {
        public override void Execute()
        {
            Retain();
            injectionBinder.GetInstance<LoadingEmulationFinished>().AddListener(LoadingEmulationFinishedHandler);
            injectionBinder.GetInstance<StartLoadingEmulation>().Dispatch();
        }

        private void LoadingEmulationFinishedHandler()
        {
            injectionBinder.GetInstance<LoadingEmulationFinished>().RemoveListener(LoadingEmulationFinishedHandler);
            injectionBinder.GetInstance<HideUIPanelSignal>().Dispatch(UIPanelType.LoadingPanel);
            Release();
        }
    }
}