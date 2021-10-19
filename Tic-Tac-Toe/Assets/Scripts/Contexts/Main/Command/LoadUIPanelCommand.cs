using Common;
using Contexts.Main.Model;
using Contexts.UI;
using Contexts.UI.View;
using strange.extensions.context.impl;
using UnityEngine;

namespace Contexts.Main.Command
{
    public class LoadUIPanelCommand : strange.extensions.command.impl.Command
    {
        [Inject] public UIPanelType UIPanelType { get; set; }
        
        public override void Execute()
        {
            var viewPath = injectionBinder
                .GetInstance<UIPanelsLibraryModel>().GetUIPanelConfig(UIPanelType).ViewPath;
            var panelPrefab = Resources.Load<UIPanelView>(viewPath);
            var panelInstance = Object.Instantiate(panelPrefab);
            injectionBinder.GetInstance<PlaceUIPanelSignal>().Dispatch(panelInstance);
        }
    }
}