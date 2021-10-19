using Common;
using Contexts.UI.View;
using strange.extensions.signal.impl;

namespace Contexts.UI
{ 
    public class StartSignal : Signal { }
    
    public class ShowUIPanelSignal : Signal<UIPanelType> { }
    
    public class HideUIPanelSignal : Signal<UIPanelType> { }
    
    public class UIPanelHidedSignal : Signal<UIPanelType> { }
    
    public class UpdateUIPanelSignal : Signal<UIPanelType, UIPanelData> { }
    
    public class PlaceUIPanelSignal : Signal<UIPanelView> { }
    public class LoadUIPanelSignal : Signal<UIPanelType> { }
}