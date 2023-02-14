using System.Runtime.InteropServices;
using ExitGames.Client.Photon;
using Photon.Pun;
using UnityEngine;

public class MultiPlayerManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update

    [SerializeField] 
    private GameObject player;

    [SerializeField] private Vector3 startPosition;
    
   [DllImport("__Internal")] private static extern string WalletAddress();
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        ExitGames.Client.Photon.Hashtable hashtable = new Hashtable();
        hashtable.Add("indirizzo", WalletAddress());
        PhotonNetwork.LocalPlayer.SetCustomProperties(hashtable);
        PhotonNetwork.NickName = "Prova";
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.Instantiate(player.name, startPosition, Quaternion.identity);

    }

   
}
