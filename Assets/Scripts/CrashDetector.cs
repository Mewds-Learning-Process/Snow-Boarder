using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CrashDetector : MonoBehaviour
{
    [SerializeField] float levelReloadTime = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Ground")
        {
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", levelReloadTime);
        }
        
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
