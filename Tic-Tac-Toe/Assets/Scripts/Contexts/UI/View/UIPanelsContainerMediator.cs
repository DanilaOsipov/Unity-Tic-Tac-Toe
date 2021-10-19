using Common;
using strange.extensions.mediation.impl;
using strange.extensions.signal.api;

namespace Contexts.UI.View
{
    public class UIPanelsContainerMediator : Mediator
    {
        [Inject] public UIPanelsContainerView View { get; set; }
        [Inject] public ShowUIPanelSignal ShowUIPanelSignal { get; set; }
        [Inject] public HideUIPanelSignal HideUIPanelSignal { get; set; }
        [Inject] public UIPanelHidedSignal UIPanelHidedSignal { get; set; }
        [Inject] public UpdateUIPanelSignal UpdateUIPanelSignal { get; set; }
        [Inject] public PlaceUIPanelSignal PlaceUIPanelSignal { get; set; }
        [Inject] public LoadUIPanelSignal LoadUIPanelSignal { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            ShowUIPanelSignal.AddListener(ShowUIPanelSignalHandler);
            HideUIPanelSignal.AddListener(HideUIPanelSignalHandler);
            UpdateUIPanelSignal.AddListener(UpdateUIPanelSignalHandler);
            PlaceUIPanelSignal.AddListener(PlaceUIPanelSignalHandler);
            View.OnPanelHided += OnPanelHidedHandler;
        }

        public override void OnRemove()
        {
            base.OnRemove();
            ShowUIPanelSignal.RemoveListener(ShowUIPanelSignalHandler);
            HideUIPanelSignal.RemoveListener(HideUIPanelSignalHandler);
            UpdateUIPanelSignal.RemoveListener(UpdateUIPanelSignalHandler);
            PlaceUIPanelSignal.RemoveListener(PlaceUIPanelSignalHandler);
            View.OnPanelHided -= OnPanelHidedHandler;
        }

        private void OnPanelHidedHandler(UIPanelType type)
        {
            UIPanelHidedSignal.Dispatch(type);
        }

        private void UpdateUIPanelSignalHandler(UIPanelType type, UIPanelData data)
        {
            View.UpdatePanel(type, data);
        }

        private void PlaceUIPanelSignalHandler(UIPanelView view)
        {
            View.PlacePanel(view);
        }

        private void HideUIPanelSignalHandler(UIPanelType type)
        {
            View.HidePanel(type);
        }

        private void ShowUIPanelSignalHandler(UIPanelType type)
        {
            if (!View.IsPanelExits(type))
            {
                LoadUIPanelSignal.Dispatch(type);
            }
            View.ShowPanel(type);
        }
    }
}