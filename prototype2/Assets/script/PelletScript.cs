using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletScript : MonoBehaviour
{
    AudioSource audioData;
    [SerializeField] GameObject fish;
    private FishMovement fishMovement;
    // Start is called before the first frame update
    void Start()
    {
        audioData = gameObject.GetComponent<AudioSource>();
        fishMovement = fish.GetComponent<FishMovement>();
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            audioData.Play();
            fishMovement.frenzyReset = true;
            float x = Random.Range(-70.0f, 70.0f);
            float y = Random.Range(-12.0f, 12.0f);
            transform.position = new Vector3(x, y, 0.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
