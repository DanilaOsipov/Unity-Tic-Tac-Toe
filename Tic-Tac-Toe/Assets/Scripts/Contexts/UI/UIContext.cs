using Contexts.Base;
using Contexts.Main.Command;
using Contexts.UI.Command;
using Contexts.UI.View;
using UnityEngine;

namespace Contexts.UI
{
    public class UIContext : BaseContext<StartSignal>
    {
        public UIContext(MonoBehaviour view) : base(view)
        {
        }

        protected override void UnbindOnRemove()
        {
            base.UnbindOnRemove();
        }

        protected override void MapMediators()
        {
            base.MapMediators();
            mediationBinder.BindView<UIPanelsContainerView>().ToMediator<UIPanelsContainerMediator>();
            mediationBinder.BindView<LoadingPanelView>().ToMediator<LoadingPanelMediator>();
            mediationBinder.BindView<MainMenuPanelView>().ToMediator<MainMenuPanelMediator>();
        }

        protected override void MapCommands()
        {
            base.MapCommands();
            commandBinder.Bind<StartSignal>()
                .To<LoadMainContextCommand>()
                .InSequence()
                .Once();

            commandBinder.Bind<LoadUIPanelSignal>().To<LoadUIPanelCommand>();
        }

        protected override void MapEntities()
        {
            base.MapEntities();
            injectionBinder.Bind<StartSignal>().ToSingleton();
            injectionBinder.Bind<ShowUIPanelSignal>().ToSingleton();
            injectionBinder.Bind<HideUIPanelSignal>().ToSingleton();
            injectionBinder.Bind<UIPanelHidedSignal>().ToSingleton();
            injectionBinder.Bind<UpdateUIPanelSignal>().ToSingleton();
            injectionBinder.Bind<PlaceUIPanelSignal>().ToSingleton();
            injectionBinder.Bind<LoadUIPanelSignal>().ToSingleton();
        }
    }
}