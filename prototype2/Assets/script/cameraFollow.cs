using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform Target;
    public Vector3 offset;

  
    private void FixedUpdate()
    {
        Vector3 newPosition = Target.position + offset;
        newPosition.z = -10;
        newPosition = new Vector3(Mathf.Clamp(newPosition.x, -52f, 52f), Mathf.Clamp(newPosition.y, -3.7f, 3.5f), newPosition.z);
        transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);
    }
}
