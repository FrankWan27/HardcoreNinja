﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    private PlayerMotor motor;
    private PhotonView PV;
    private PlayerSkills skills;

    [SerializeField]
    private ParticleSystem PS;
    [SerializeField]
    private Transform target;
    PlayerFollow pf;

    private void Start()
    {
        PV = GetComponent<PhotonView>();
        motor = GetComponent<PlayerMotor>();
        skills = GetComponent<PlayerSkills>();
        pf = target.GetComponent<PlayerFollow>();

        PS.Stop();
        if(!PV.IsMine)
            motor.TurnOffCam();
    }

    private void Update()
    {
        if (!PV.IsMine)
            return;

        if (Cursor.lockState != CursorLockMode.Locked)
            Cursor.lockState = CursorLockMode.Locked;


        //Calculate movement as a 3D vector
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");
       

        Vector3 moveHorizontal = transform.right * xMove; //(1, 0, 0)
        Vector3 moveVertical = transform.forward * zMove; //(0, 0, 1)

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        motor.Move(velocity);

        if(Input.GetKey(KeyCode.E))
        {
            Dash();
        }
        if(Input.GetMouseButtonDown(1))
        {
            Sunder();
        }
        

    }

    private void Dash()
    {
        //check if skill on CD
        if (!skills.CheckSkillCD("dash"))
            return;
        float forwardDistance = 10;

        //catch up camera and particle system (don't teleport)

        //teleport player forward (check for collision?)
        Vector3 newLocation = transform.position + transform.forward * forwardDistance;
        transform.position = newLocation;
    }

    private void Sunder()
    {
        //check if skill on CD
        if (!skills.CheckSkillCD("sunder"))
            return;

       PV.RPC("SunderRPC", Photon.Pun.RpcTarget.All, new object[] { transform.position, transform.rotation, gameObject.GetInstanceID()});  

       //CreateSunder(transform.position, transform.rotation);
    } 

    [PunRPC]
    public void SunderRPC( Vector3 position, Quaternion rotation, int creatorID)
    {
        GameObject newSunderObject = Instantiate((GameObject)Resources.Load("PhotonPrefabs/Sunder"), position + transform.forward, rotation);
        newSunderObject.GetComponent<SunderController>().creatorID = gameObject.GetInstanceID();
    }

    public void CreateSunder(Vector3 position, Quaternion rotation)
    {
        GameObject newSunderObject = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Sunder"), position + transform.forward, rotation);
        newSunderObject.GetComponent<SunderController>().creatorID = gameObject.GetInstanceID();

        //GameObject newSunderObject = (GameObject)Instantiate(Resources.Load)
    }

    public void Die()
    {
        GameObject.Find("Scoreboard").GetComponent<ScoreController>().IncScore(PV.Owner);

        PV.RPC("AddScoreRPC", Photon.Pun.RpcTarget.All, 1);
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        PV.RPC("ExplodeRPC", Photon.Pun.RpcTarget.All);
        yield return new WaitForSeconds(3f);
        PV.RPC("RespawnRPC", Photon.Pun.RpcTarget.All);
    }

    [PunRPC]
    void ExplodeRPC()
    {
        //transform.GetChild(0).gameObject.SetActive(false);
        Debug.Log("Blow up");
    }

    [PunRPC]
    void RespawnRPC()
    {
        Debug.Log("Respawn");
    }

    [PunRPC]
    void AddScoreRPC(int amount)
    {
         
    }
}
