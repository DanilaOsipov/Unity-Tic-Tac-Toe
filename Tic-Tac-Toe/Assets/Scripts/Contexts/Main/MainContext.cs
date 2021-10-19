using Contexts.Base;
using Contexts.Main.Command;
using Contexts.Main.Command.Test;
using Contexts.Main.Model;
using Contexts.Main.View.Test;
using Contexts.UI;
using UnityEngine;

namespace Contexts.Main
{
    public class MainContext : BaseContext<StartSignal>
    {
        public MainContext(MonoBehaviour view) : base(view)
        {
        }

        protected override void UnbindOnRemove()
        {
            base.UnbindOnRemove();
        }

        protected override void MapMediators()
        {
            base.MapMediators();
            mediationBinder.BindView<LoadingEmulatorView>().ToMediator<LoadingEmulatorMediator>();
        }

        protected override void MapCommands()
        {
            base.MapCommands();
            commandBinder.Bind<StartSignal>()
                .To<LoadUIPanelsConfigsCommand>()
                .To<EmulateLoadingCommand>();
            
            commandBinder.Bind<LoadUIPanelSignal>().To<LoadUIPanelCommand>();
        }

        protected override void MapEntities()
        {
            base.MapEntities();
            injectionBinder.Bind<StartSignal>().ToSingleton();
            injectionBinder.Bind<UIPanelsLibraryModel>().ToSingleton();
            injectionBinder.Bind<StartLoadingEmulation>().ToSingleton();
            injectionBinder.Bind<LoadingEmulationFinished>().ToSingleton();
        }
    }
}