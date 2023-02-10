using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Scripts
{
    public class SetListaPlayers : MonoBehaviour
    {

        [SerializeField] 
        private GameObject _listaPlayers;
        
        [SerializeField] 
        private Button _buttonBack;
        
        [SerializeField] 
        private Button _buttonListPlayers;
    
        [SerializeField] 
        private GameObject _elementoPlayer;
    
        [SerializeField] 
        private GameObject _content;
        
        

        public void SetUp()
        {

            if (_listaPlayers.activeSelf)
            {
                List<Transform> panelList= new List<Transform>();
                _listaPlayers.SetActive(false);
                foreach (Transform panel in _content.transform)
                {
                    panelList.Add(panel);
                }

                foreach (Transform panel2 in panelList)
                {
                    Destroy(panel2.gameObject);
                }
            }
            else
            {
                foreach (Player player in PhotonNetwork.PlayerList)
                {
                    GameObject gameObject = Instantiate(_elementoPlayer, _content.transform);
                    gameObject.GetComponent<SetPlayer>().SetPlayerInfo(player, _buttonBack, _buttonListPlayers, _listaPlayers);
                }
                _listaPlayers.SetActive(true);
            }
        }
    }
}