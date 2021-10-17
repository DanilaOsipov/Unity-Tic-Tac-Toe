using System;
using Common;
using UnityEngine;

namespace Contexts.UI.View
{
    public abstract class UIPanelData
    {
    }

    public abstract class UIPanelView<TData> : UIPanelView
        where TData : UIPanelData
    {
        public override void UpdateView(UIPanelData data)
        {
            UpdateView(data as TData);
        }

        protected abstract void UpdateView(TData data);
    }
    
    public abstract class UIPanelView : strange.extensions.mediation.impl.View
    {
        [SerializeField] private UIAnimation hideUIAnimation;
        [SerializeField] private UIAnimation showUIAnimation;

        public abstract UIPanelType Type { get; }

        public Transform Transform => transform;

        public event Action<UIPanelType> OnPanelHided = delegate(UIPanelType type) {  };

        public abstract void UpdateView(UIPanelData data);

        public void Hide()
        {
            if (hideUIAnimation != null) hideUIAnimation.Play(InternalHide);
            else InternalHide();
        }

        private void InternalHide()
        {
            gameObject.SetActive(false);
            OnPanelHided(Type);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            showUIAnimation?.Play(() => { });
        }
    }
}