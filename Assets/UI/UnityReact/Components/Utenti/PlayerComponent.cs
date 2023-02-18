using System;
using MetaClass.UI.UnityReact.Scripts;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.UnityReact.Components.Utenti
{
    [PrefabPath("Assets/UI/UnityReact/Resources/Utenti/Utente.prefab")]

    public class PlayerComponent : ComponentUI
    {

        private Player player;
        
        
        [SerializeField] 
        private TextMeshProUGUI _indirizzoPlayer;
    
    
        [SerializeField] 
        private Button _buttonList;
        public override void Init(params object[] initValues)
        {
            player = (Player)initValues[0];
        }

        public override void Draw()
        {
            if (player.CustomProperties.ContainsKey("indirizzo"))
            {
                _indirizzoPlayer.text = player.CustomProperties["indirizzo"] + "";
            }
            else
            {
                _indirizzoPlayer.text = "Indirizzo non trovato";
            }
            
            _buttonList.onClick.AddListener(GoToPlayerMonsterList);
           
        }


        public void GoToPlayerMonsterList()
        {
            Action<string,object[]> changeRoute = (Action<string,object[]>)Enviroment["ChangeRoute"];
            changeRoute("ListaMostri",new[] { _indirizzoPlayer.text });
        }
        
    }
}