using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{

    [SerializeField]
    public Transform player;
    public float smoothSpeed;

    void LateUpdate()
    {

        Vector3 destination = player.position;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, destination, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
