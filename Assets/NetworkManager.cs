using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{

    private GameObject spawnedPlayerPrefab;
    public Transform spawnPos;

    public Transform xrRig;

    public Transform mainCamera;
    public Transform leftController;
    public Transform rightController;

    // Start is called before the first frame update
    void Start()
    {
        ConnectToServer();
    }

    void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Connecting to server...");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected");
        RoomOptions roomOptions = new RoomOptions();
        PhotonNetwork.JoinOrCreateRoom("Room 1", roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Room joined");
        if (PhotonNetwork.IsMasterClient)
        {
            xrRig.position += new Vector3(0,0, 2.0f);
            xrRig.Rotate(0, 180, 0);
            Debug.Log("Player1");
        }
        else
        {
            xrRig.position += new Vector3(0,0.0f,-2.0f);
            Debug.Log("Player2");
        }
        spawnedPlayerPrefab = PhotonNetwork.Instantiate("NetworkPlayer", xrRig.position, xrRig.rotation);

        NetworkPlayer player = spawnedPlayerPrefab.GetComponent(typeof(NetworkPlayer)) as NetworkPlayer;

        player.mainCamera = mainCamera;
        player.leftController = leftController;
        player.rightController = rightController;
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
