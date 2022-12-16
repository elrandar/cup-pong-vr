using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviourPunCallbacks
{
    private GameObject spawnedPlayerPrefab;
    public Transform spawnPos;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        spawnedPlayerPrefab = PhotonNetwork.Instantiate("NetworkPlayer", spawnPos.position, spawnPos.rotation);
        // PhotonView photonView = spawnedPlayerPrefab.GetComponent<PhotonView>();
        // if (!photonView.IsMine)
        // {
        //     if (!PhotonNetwork.IsMasterClient)
        //     {
        //         spawnedPlayerPrefab.transform.position += new Vector3(0,0, 2.5f);
        //         spawnedPlayerPrefab.transform.Rotate(0, 180, 0);
        //         // Debug.Log("Player1");
        //     }
        //     else
        //     {
        //         spawnedPlayerPrefab.transform.position += new Vector3(0,0.0f,-2.5f);
        //         // Debug.Log("Player2");
        //     }
        // }
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }
}
