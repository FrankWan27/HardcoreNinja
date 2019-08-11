using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PhotonConnect : MonoBehaviourPunCallbacks
{

    /*
     * Documentation: 
     * API: https://doc-api.photonengine.com/en/pun/v2/
     */

    public string versionName = "0.1";

    public void Start()
    {
        connectToPhoton();
    }

    public void connectToPhoton() 
    {
        PhotonNetwork.ConnectUsingSettings();

        Debug.Log("Connecting to Photon...");

    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("You are now connected to the " + PhotonNetwork.CloudRegion + " server!");
    }

    private void OnDisconnectedFromServer(NetworkIdentity info)
    {
        Debug.Log("Disconnected from Photon");
    }
}
