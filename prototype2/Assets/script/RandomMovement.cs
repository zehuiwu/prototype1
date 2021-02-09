using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;

    public float accelerationTime = 2f;
    public float maxSpeed = 5f;
    private Vector2 movement;
    private float timeLeft;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            timeLeft += accelerationTime;
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(movement * maxSpeed);
    }


    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        

        if (collision.collider.gameObject.CompareTag("Wall")) // for example wall is called Wall
        {
            //Debug.Log("collided with " + collision.collider.gameObject.name);
            movement = -movement;
            rb.AddForce(movement * maxSpeed);
        }
    }
}
