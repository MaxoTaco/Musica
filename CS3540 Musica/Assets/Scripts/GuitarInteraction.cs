using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarInteraction : MonoBehaviour
{
    public AudioClip noteSound;
    private AudioSource audioSource;
    private bool playerInRange = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = noteSound;
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            PlayNote();
        }
    }

    void PlayNote()
    {
        audioSource.Play();
        GameManager.Instance.NotePlayed(this);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
