using System.Collections;
using Common;
using Contexts.UI;
using Contexts.UI.View;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Contexts.Main.Command
{
    public abstract class LoadContextCommand : strange.extensions.command.impl.Command
    {
        public override void Execute()
        {
            Retain();
            var asyncOperation = SceneManager.LoadSceneAsync(GetContextSceneName(), LoadSceneMode.Additive);
            var loadingDisplayer = new ContextLoadingDisplayer(asyncOperation);
            var loadingStatus = $"Loading {GetContextSceneName()} scene";
            UpdateLoadingPanel(loadingDisplayer, loadingStatus);
            asyncOperation.completed += AsyncOperationOnCompletedHandler;
        }
        
        private void AsyncOperationOnCompletedHandler(AsyncOperation operation)
        {
            Debug.Log("Scene loaded: " + GetContextSceneName());
            // injectionBinder.GetInstance<HideUIPanelSignal>().Dispatch(UIPanelType.LoadingPanel);
            ContextLoadedHandler();
            Release();
        }

        private void UpdateLoadingPanel(LoadingDisplayer loadingDisplayer, string loadingStatus)
        {
            var updateUIPanelSignal = injectionBinder.GetInstance<UpdateUIPanelSignal>();
            var panelData = new LoadingPanelData(loadingDisplayer, loadingStatus);
            updateUIPanelSignal.Dispatch(UIPanelType.LoadingPanel, panelData);
        }
        
        protected abstract string GetContextSceneName();

        protected virtual void ContextLoadedHandler()
        {
        }
    }

    public class ContextLoadingDisplayer : LoadingDisplayer
    {
        private AsyncOperation _contextLoadingOperation;

        public ContextLoadingDisplayer(AsyncOperation contextLoadingOperation)
        {
            _contextLoadingOperation = contextLoadingOperation;
        }
        
        public override IEnumerator DisplayCoroutine(Image progressBar)
        {
            while (!_contextLoadingOperation.isDone)
            {
                Debug.Log("progress " + _contextLoadingOperation.progress);
                progressBar.fillAmount = _contextLoadingOperation.progress;
                yield return null;
            }
        }
    }
}