using System;
using strange.extensions.context.impl;

namespace Contexts.UI
{
    public class UIRoot : ContextView
    {
        private void Awake()
        {
            context = new UIContext(this);
        }
    }
}