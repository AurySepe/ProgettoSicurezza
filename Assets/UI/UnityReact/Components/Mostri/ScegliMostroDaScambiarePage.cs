using MetaClass.UI.UnityReact.Scripts;
using Photon.Pun;
using UI.UnityReact.Components.ComponentiDiBase;
using UnityEngine;

namespace UI.UnityReact.Components.Mostri
{
    
    [Route("MostroDaScambiare")]
    public class ScegliMostroDaScambiarePage : ComponentUI
    {

        public override void Init(params object[] initValues)
        {


        }

        public override void Draw()
        {
            AddChildComponent<Titolo>(new Vector3(0,460,0),1,"Con chi lo vuoi scambiare?");
            AddChildComponent<ListaMostriDaProporre>(Vector3.zero, 1);
            
        }
    }
}