using Common;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "UIPanelConfig", menuName = "Config/UIPanelConfig")]
    public class UIPanelConfig : Config
    {
        [SerializeField] private UIPanelType _type;
        [SerializeField] private string _viewPath;

        public UIPanelType Type => _type;

        public string ViewPath => _viewPath;
    }
}