using System;
using System.Collections.Generic;
using Common;
using UnityEngine;

namespace Contexts.UI.View
{
    public class UIPanelsContainerView : strange.extensions.mediation.impl.View
    {
        [SerializeField] private List<UIPanelView> _panels = new List<UIPanelView>();
        
        public event Action<UIPanelType> OnPanelHided = delegate(UIPanelType type) { };

        protected override void Awake()
        {
            base.Awake();
            foreach (var panel in _panels)
            {
                panel.OnPanelHided += delegate(UIPanelType type) { OnPanelHided(type); };
            }
        }

        public bool IsPanelExits(UIPanelType type)
        {
            return _panels.Find(x => x.Type == type) != null;
        }
        
        public void ShowPanel(UIPanelType type)
        {
            _panels.Find(x => x.Type == type).Show();
        }

        public void UpdatePanel(UIPanelType type, UIPanelData data)
        {
            _panels.Find(x => x.Type == type).UpdateView(data);
        }

        public void PlacePanel(UIPanelView view)
        {
            view.Transform.SetParent(transform);
            view.Transform.localPosition = Vector3.zero;
            view.Transform.localScale = Vector3.one;
            view.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
            view.OnPanelHided += delegate(UIPanelType type) { OnPanelHided(type); };
            _panels.Add(view);
        }

        public void HidePanel(UIPanelType type)
        {
            _panels.Find(x => x.Type == type).Hide();
        }
    }
}