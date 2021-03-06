﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private ParticleSystem PS;


    private Vector3 velocity = Vector3.zero;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 vel)
    {
        velocity = vel;
    }

    private void FixedUpdate()
    {
        PerformMovement();
    }

    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    public void TurnOffCam()
    {
        cam.enabled = false;
    }
}
