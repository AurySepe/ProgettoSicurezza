using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class MultiPlayerManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update

    [SerializeField] 
    private GameObject player;

    [SerializeField] private Vector3 startPosition;
    
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.Instantiate(player.name, startPosition, Quaternion.identity);

    }

   
}
