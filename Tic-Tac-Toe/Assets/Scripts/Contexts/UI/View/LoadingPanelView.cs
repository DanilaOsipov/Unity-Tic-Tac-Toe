using System.Collections;
using Common;
using UnityEngine;
using UnityEngine.UI;

namespace Contexts.UI.View
{
    public class LoadingPanelView : UIPanelView<LoadingPanelData>
    {
        [SerializeField] private Image _progressBar;

        public override UIPanelType Type => UIPanelType.LoadingPanel;

        protected override void UpdateView(LoadingPanelData data)
        {
            StartCoroutine(data.LoadingDisplayer.DisplayCoroutine(_progressBar));
        }
    }

    public class LoadingPanelData : UIPanelData
    {
        public string LoadingStatus { get; }
        public LoadingDisplayer LoadingDisplayer { get; }
        
        public LoadingPanelData(LoadingDisplayer loadingDisplayer, string loadingStatus)
        {
            LoadingDisplayer = loadingDisplayer;
            LoadingStatus = loadingStatus;
        }
    }

    public abstract class LoadingDisplayer
    {
        public abstract IEnumerator DisplayCoroutine(Image progressBar);
    }
}