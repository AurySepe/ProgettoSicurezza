using MetaClass.UI.UnityReact.Scripts;
using TMPro;
using UnityEngine;

namespace UI.UnityReact.Components.ComponentiDiBase
{
    [PrefabPath("Assets/UI/UnityReact/Resources/ComponentiDiBase/Titolo.prefab")]
    public class Titolo : ComponentUI
    {

        public string Scritta { get; set; }

        [SerializeField] private TextMeshProUGUI textBox;
        public override void Init(params object[] initValues)
        {
            Scritta = (string)initValues[0];
        }

        public override void Draw()
        {
            textBox.text = Scritta;
        }
    }
}