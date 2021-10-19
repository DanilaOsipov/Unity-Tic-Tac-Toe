using Contexts.Base;
using Contexts.Main.Command;
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
            injectionBinder.CrossContextBinder.Unbind<ShowUIPanelSignal>();
            injectionBinder.CrossContextBinder.Unbind<HideUIPanelSignal>();
            injectionBinder.CrossContextBinder.Unbind<UIPanelHidedSignal>();
            injectionBinder.CrossContextBinder.Unbind<UpdateUIPanelSignal>();
            injectionBinder.CrossContextBinder.Unbind<PlaceUIPanelSignal>();
            injectionBinder.CrossContextBinder.Unbind<LoadUIPanelSignal>();
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
        }

        protected override void MapEntities()
        {
            base.MapEntities();
            injectionBinder.Bind<StartSignal>().ToSingleton();
            injectionBinder.Bind<ShowUIPanelSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<HideUIPanelSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<UIPanelHidedSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<UpdateUIPanelSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<PlaceUIPanelSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<LoadUIPanelSignal>().ToSingleton().CrossContext();
        }
    }
}