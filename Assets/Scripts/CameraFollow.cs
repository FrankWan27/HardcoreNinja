using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed;
    public float xOffset;
    public float yOffset;

    // Update is called once per frame
    void LateUpdate()
    {
        //calculate offset
        Vector3 forward = target.forward;
        Vector3 offset = forward * -xOffset + new Vector3(0, yOffset, 0);



        Vector3 destination = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, destination, smoothSpeed);
        transform.position = smoothedPosition;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, target.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}
