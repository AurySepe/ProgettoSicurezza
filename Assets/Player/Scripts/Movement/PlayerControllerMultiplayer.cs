using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerControllerMultiplayer : PlayerController
{
    // Start is called before the first frame update

    private PhotonView _photonView;

    private Queue<Vector3> _positionsToMoveTo = new Queue<Vector3>();

    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (_photonView.IsMine && !BattleScene.Instance.IsBattle)
        {
            MovementCheck();
        }

        if (!isMoving && _positionsToMoveTo.Count != 0)
        {
            StartCoroutine(MoveTo(_positionsToMoveTo.Dequeue()));
        }


    }

    protected override void StartMoveTo(Vector3 positionToMove)
    {
        
        _photonView.RPC("MoveRpc",RpcTarget.All,positionToMove);
    }

    [PunRPC]
    private void MoveRpc(Vector3 positionToMove)
    {
        _positionsToMoveTo.Enqueue(positionToMove);
    }

    public override void AddHasWalkedAction(Action action)
    {
        if (_photonView.IsMine)
        {
            base.AddHasWalkedAction(action);
        }
    }
}
