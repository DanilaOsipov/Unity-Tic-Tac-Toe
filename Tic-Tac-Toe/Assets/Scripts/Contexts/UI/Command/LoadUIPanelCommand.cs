using Common;
using Contexts.UI.View;
using strange.extensions.context.impl;
using UnityEngine;

namespace Contexts.UI.Command
{
    public class LoadUIPanelCommand : strange.extensions.command.impl.Command
    {
        [Inject] public string UIPanelPath { get; set; }
        
        public override void Execute()
        {
            var panelPrefab = Resources.Load<UIPanelView>(UIPanelPath);
            var panelInstance = Object.Instantiate(panelPrefab);
            injectionBinder.GetInstance<PlaceUIPanelSignal>().Dispatch(panelInstance);
        }
    }
}