using System;
using System.Collections;
using UnityEngine;

namespace Contexts.Main.View.Test
{
    public class LoadingEmulatorView : strange.extensions.mediation.impl.View
    {
        [SerializeField] private float _loadingTime = 5.0f;

        public event Action OnLoadingEmulationFinished = delegate { };

        public float LoadingTime => _loadingTime;

        public void StartLoadingEmulation()
        {
            StartCoroutine(EmulationCoroutine());
        }

        private IEnumerator EmulationCoroutine()
        {
            yield return new WaitForSeconds(_loadingTime);
            OnLoadingEmulationFinished();
        }
    }
}