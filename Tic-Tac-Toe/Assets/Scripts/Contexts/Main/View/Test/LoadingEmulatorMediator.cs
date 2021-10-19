using System.Collections;
using Common;
using Contexts.UI;
using Contexts.UI.View;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

namespace Contexts.Main.View.Test
{
    public class LoadingEmulatorMediator : Mediator
    {
        [Inject] public LoadingEmulatorView View { get; set; }
        [Inject] public StartLoadingEmulation StartLoadingEmulation { get; set; }
        [Inject] public LoadingEmulationFinished LoadingEmulationFinished { get; set; }
        [Inject] public UpdateUIPanelSignal UpdateUIPanelSignal { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            StartLoadingEmulation.AddListener(StartLoadingEmulationHandler);
            View.OnLoadingEmulationFinished += OnLoadingEmulationFinishedHandler;
        }

        public override void OnRemove()
        {
            base.OnRemove();
            StartLoadingEmulation.RemoveListener(StartLoadingEmulationHandler);
            View.OnLoadingEmulationFinished -= OnLoadingEmulationFinishedHandler;
        }

        private void OnLoadingEmulationFinishedHandler()
        {
            LoadingEmulationFinished.Dispatch();
        }

        private void StartLoadingEmulationHandler()
        {
            View.StartLoadingEmulation();
            var loadingDisplayer = new EmulatedLoadingDisplayer(View.LoadingTime);
            var loadingStatus = "Emulating loading...";
            var panelData = new LoadingPanelData(loadingDisplayer, loadingStatus);
            UpdateUIPanelSignal.Dispatch(UIPanelType.LoadingPanel, panelData);
        }
    }
    
    public class EmulatedLoadingDisplayer : LoadingDisplayer
    {
        public float LoadingTime { get; }
        
        public EmulatedLoadingDisplayer(float loadingTime)
        {
            LoadingTime = loadingTime;
        }

        public override IEnumerator DisplayCoroutine(Image progressBar)
        {
            float elapsedTime = 0;
            while (elapsedTime < LoadingTime)
            {
                progressBar.fillAmount = elapsedTime / LoadingTime;
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}