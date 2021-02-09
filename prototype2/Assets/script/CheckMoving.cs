using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckMoving : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] Text Die;
    private void FixedUpdate()
    {
        if (rb.velocity.magnitude == 0)
        {
            Die.enabled = true;
        }
    }

}
