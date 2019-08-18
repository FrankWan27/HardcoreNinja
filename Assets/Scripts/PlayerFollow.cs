using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{

    [SerializeField]
    public Transform player;
    public float smoothSpeed;
    public ParticleSystem PS;

    void LateUpdate()
    {

        Vector3 destination = player.position;

        if (Vector3.Distance(destination, transform.position) > 1)
        {
            if (PS != null)
            {
                PS.Play();
            }
            smoothSpeed = 0.2f;
        }
        else
        {
            if (PS != null)
            {
                PS.Stop();
            }
            smoothSpeed = 1f;
        }

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, destination, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
