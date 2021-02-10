using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class restart : MonoBehaviour
{
    [SerializeField] Text Die;
    public float delay = 1f;
    [SerializeField] AudioSource bomb;
    public CameraShake cameraShake;

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            bomb.Play();
            Invoke("DieMessage", 0.0f);
            Invoke("Restart", delay);
        }
    }

    void DieMessage()
    {
        StartCoroutine(cameraShake.Shake(1f, 1f));
        Die.enabled = true;
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
