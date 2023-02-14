using MetaClass.UI.UnityReact.Scripts;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace UI.UnityReact.Components.Utenti
{
    [PrefabPath("Assets/UI/UnityReact/Resources/Utenti/ListaUtenti.prefab")]
    public class ListaUtentiComponent : ScrollViewComponent
    {
        
        
        public override void Init(params object[] initValues)
        {
            
        }

        public override void Draw()
        {
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                AddChildComponent<PlayerComponent>(Vector3.zero,1,player);
            }
            
            
        }
    }
}