using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Scripts
{
    public class SetPlayer: MonoBehaviour
    {
        [SerializeField] 
        private TextMeshProUGUI _indirizzoPlayer;
    
        [SerializeField] 
        private TextMeshProUGUI _usernamePlayer;
    
        [SerializeField] 
        private Button _buttonList;

        private Button _buttonBack;
        
        private Button _buttonListPlayers;
        
        private GameObject _listaPlayers;
        


        public void SetPlayerInfo(Player player, Button _buttonB, Button _buttonListPlayers, GameObject _listaPlayers)
        {
            _buttonBack = _buttonB;
            this._listaPlayers = _listaPlayers;
            this._buttonListPlayers = _buttonListPlayers;
            if (player.CustomProperties.ContainsKey("indirizzo"))
            {
                _indirizzoPlayer.text = player.CustomProperties["indirizzo"] + "";
            }
            else
            {
                _indirizzoPlayer.text = "Indirizzo non trovato";
            }
            _usernamePlayer.text = player.NickName;
            
            _buttonList.onClick.AddListener(SetButton);
            
            //_buttonBack.onClick.AddListener(SetButtonBack);
            
        }


        public void SetButton()
        {
            SetUpMonster _setUpMonster= GameObject.FindObjectOfType<SetUpMonster>();
            _setUpMonster.listaMostri(_indirizzoPlayer.text);
            _listaPlayers.SetActive(false);
            _buttonListPlayers.gameObject.SetActive(false);
            _buttonBack.gameObject.SetActive(true);
        }
        
       /* public void SetButtonBack()
        {
            _buttonBack.gameObject.SetActive(false);
            _buttonListPlayers.gameObject.SetActive(true);
            _listaPlayers.SetActive(true);
        }*/
    }
}