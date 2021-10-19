using Contexts.Main.Model;
using UnityEngine;

namespace Contexts.Main.Command
{
    public abstract class LoadConfigsCommand<TL, TC> : strange.extensions.command.impl.Command 
        where TL : LibraryModel<TC> where TC : Config
    {
        public override void Execute()
        {
            var configs = Resources.LoadAll<TC>(GetPath());
		
            Debug.Log("Loaded " + typeof(TC) + ". Count: " + configs.Length);
		
            injectionBinder.GetInstance<TL>().Initialize(configs);
        }

        protected abstract string GetPath();
    }

}