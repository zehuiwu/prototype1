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
        transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);
    }
}
