using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.signal.impl;
using UnityEngine;

namespace Contexts.Base
{
    public abstract class BaseContext<TStartSignal> : MVCSContext
        where TStartSignal : Signal
    {
        protected BaseContext(MonoBehaviour view) : base(view)
        {
        }
        
        public override IContext Start()
        {
            base.Start();
            var startSignal = injectionBinder.GetInstance<TStartSignal>();
            startSignal.Dispatch();
            return this;
        }
        
        protected override void addCoreComponents()
        {
            base.addCoreComponents();
            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
        }
        
        protected override void mapBindings()
        {
            MapEntities();
            MapCommands();
            MapMediators();
        }
        
        public override void OnRemove()
        {
            base.OnRemove();
            UnbindOnRemove();
        }

        protected virtual void UnbindOnRemove()
        {
        }

        protected virtual void MapMediators()
        {
        }

        protected virtual void MapCommands()
        {
        }

        protected virtual void MapEntities()
        {
        }
    }
}