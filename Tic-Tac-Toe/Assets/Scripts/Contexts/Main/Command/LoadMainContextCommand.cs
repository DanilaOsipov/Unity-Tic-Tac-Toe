using Common;

namespace Contexts.Main.Command
{
    public class LoadMainContextCommand : LoadContextCommand
    {
        protected override string GetContextSceneName() => ContextSceneNames.MAIN_SCENE;
    }
}