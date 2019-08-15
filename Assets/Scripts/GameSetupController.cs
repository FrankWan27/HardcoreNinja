using Photon.Pun;
using System.IO; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetupController : MonoBehaviour
{

    public Transform[] spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        Transform spawnLoc = spawnPoints[Random.Range(0, spawnPoints.Length)];
        CreatePlayer(spawnLoc);
    }

    private void CreatePlayer(Transform spawnLoc)
    {
        Debug.Log("Creating Player");
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"), spawnLoc.position, spawnLoc.rotation);
    }
}
