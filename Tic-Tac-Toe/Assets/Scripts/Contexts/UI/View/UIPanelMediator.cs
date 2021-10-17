using Common;
using strange.extensions.mediation.impl;

namespace Contexts.UI.View
{
    public abstract class UIPanelMediator<TView, TData> : Mediator
        where TView : UIPanelView<TData>
        where TData : UIPanelData
    {
        [Inject] public TView View { get; set; }
        
        public override void OnRegister()
        {
            base.OnRegister();
            View.OnPanelHided += OnPanelHidedHandler;
        }

        public override void OnRemove()
        {
            base.OnRemove();
            View.OnPanelHided -= OnPanelHidedHandler;
        }

        protected virtual void OnPanelHidedHandler(UIPanelType type)
        {
            
        }
    }
}