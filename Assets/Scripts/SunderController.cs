using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunderController : MonoBehaviour
{
    private Rigidbody rb;
    public int creatorID;

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
            Debug.Log("Faded out, creator id = " + creatorID);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("On Collide " + collision.collider.gameObject);

        if (collision.collider.tag == "Player")
        {
      
            Debug.Log("Collide with Player, creator id = " + creatorID);

            if (collision.collider.gameObject.GetInstanceID() != creatorID)
            {
                //collision.collider.gameObject.SetActive(false);
                collision.collider.gameObject.GetComponent<PlayerController>().Die();
                Destroy(gameObject);

            }
        }
        else if(collision.collider.tag != "Floor")
        {
            
            Debug.Log("Collide with Obstacle, creator id = " + creatorID);

            Destroy(gameObject);

        }
    }
}
