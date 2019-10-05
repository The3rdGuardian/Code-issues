using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    { 
        public AudioClip musicClipOne;

        public AudioClip musicClipTwo;

        public AudioSource musicSource;

        if (Input.GetKeyDown(KeyCode.W))
        {
            musicSource.clip = musicClipOne;
            musicSource.Play();
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            musicSource.Stop();

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            musicSource.clip = musicClipTwo;
            musicSource.Play();
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            musicSource.Stop();

        }
    }
}
