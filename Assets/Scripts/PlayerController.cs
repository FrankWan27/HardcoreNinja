using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivityX = 3f;
    [SerializeField]
    private float lookSensitivityY = 3f;
    private PlayerMotor motor;
    private PhotonView PV;
    private PlayerSkills skills;

    [SerializeField]
    private ParticleSystem PS;
    [SerializeField]
    private Camera camera;
    CameraFollow cf;

    private void Start()
    {
        PV = GetComponent<PhotonView>();
        motor = GetComponent<PlayerMotor>();
        skills = GetComponent<PlayerSkills>();
        cf = camera.GetComponent<CameraFollow>();

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

        //Calculate rotation
        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0f, yRot, 0f) * lookSensitivityX;

        motor.Rotate(rotation);

        //Calculate camera rotation
        float xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 cameraRotation = new Vector3(xRot, 0f, 0f) * lookSensitivityY;

        motor.RotateCamera(cameraRotation);

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

        PS.Play();
        cf.smoothSpeed = 0.1f;

        Invoke("ResetThings", 0.2f);
        //teleport player forward (check for collision?)
        Vector3 newLocation = transform.position + transform.forward * forwardDistance;
        transform.position = newLocation;



        //catch up camera and particle system (don't teleport)
    }

    private void ResetThings()
    {
        cf.smoothSpeed = 1f;
        PS.Stop();
    }
}
