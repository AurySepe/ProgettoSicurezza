using System;
using UnityEngine;

namespace MetaClass.UI.UnityReact.Scripts
{
    public class PrefabStarerUI : ComponentUI
    {
        // Start is called before the first frame update

        [SerializeField] private GameObject TopUI;

        private ComponentUI componentC;

        public override void Init(params object[] initValues)
        {
            componentC = TopUI.GetComponent<ComponentUI>();
            
        }

        // Update is called once per frame
        public override void Draw()
        {
            
            AddChildComponent(componentC.GetType(),Vector3.zero,1);
        }
    }
}
