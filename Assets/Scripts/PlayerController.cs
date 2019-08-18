using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
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

        //PS.Stop();
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
}
