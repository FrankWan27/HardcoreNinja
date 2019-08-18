using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target, player;
    public PhotonView PV;

    public float rotationSpeed = 1;

    float mouseX, mouseY;


    // Update is called once per frame
    void LateUpdate()
    {
        if (!PV.IsMine)
            return;
        //calculate offset
        /*
        Vector3 forward = target.forward;
        Vector3 offset = forward * -xOffset + new Vector3(0, yOffset, 0);



        Vector3 destination = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, destination, smoothSpeed);
        transform.position = smoothedPosition;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, target.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        */

        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -90, 50);

        transform.LookAt(target);

        if (Input.GetKey(KeyCode.LeftAlt))
        {
            target.rotation = Quaternion.Euler(mouseY, mouseX, 0);

        }
        else
        {
            target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            player.rotation = Quaternion.Euler(0, mouseX, 0);
        }


    }
}
