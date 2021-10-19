using System;
using Common;
using UnityEngine;
using UnityEngine.UI;

namespace Contexts.UI.View
{
    public class MainMenuPanelView : UIPanelView<MainMenuPanelData>
    {
        [SerializeField] private Button _startButton;
        
        public override UIPanelType Type => UIPanelType.MainMenuPanel;

        public event Action OnStartButtonClick = delegate { };
        
        protected override void Awake()
        {
            base.Awake();
            _startButton.onClick.AddListener(OnStartButtonClickHandler);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _startButton.onClick.RemoveListener(OnStartButtonClickHandler);
        }

        private void OnStartButtonClickHandler() => OnStartButtonClick();

        protected override void UpdateView(MainMenuPanelData data)
        {
            throw new System.NotImplementedException();
        }
    }
    
    public class MainMenuPanelData : UIPanelData
    {
    }
}