using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConstrain : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.1F;
    public Transform farLeft;  // End of screen Left
    public Transform farRight;  //End of Screen Right
    public Transform farUp;
    public Transform farDown;

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, farLeft.position.x, farRight.position.x), 0);
    }
}
