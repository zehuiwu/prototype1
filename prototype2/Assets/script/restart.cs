using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class restart : MonoBehaviour
{
    [SerializeField] Text Die;
    public float delay = 1f;
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if(collision.collider.gameObject.CompareTag("Player"))
        {
            Die.enabled = true;
            Invoke("Restart", delay);
        }
        
        
  
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
