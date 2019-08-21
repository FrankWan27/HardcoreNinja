using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunderController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 startPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = 10 * transform.forward;
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        if(Vector3.Distance(startPosition, transform.position) > 10)
        {
            Destroy(gameObject);
        }
    }
}
