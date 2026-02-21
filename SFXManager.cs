using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip jumpSFX;
    [SerializeField] AudioClip hitSFX;
    [SerializeField] AudioClip powerupSFX;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySFX(string sfx)
    {
        switch(sfx)
        {
            case "Jump":
                audioSource.clip = jumpSFX;
                break;
            case "Hit":
                audioSource.clip = hitSFX;
                break;
            case "Powerup":
                audioSource.clip = powerupSFX;
                break;
        }

        audioSource.Play();
    }
}
