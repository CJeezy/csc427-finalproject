using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    private static AudioManager _instance;
    public AudioSource backgroundMusic;
    public AudioSource soundFX;
    public AudioClip[] soundEffects;
    public AudioClip[] songs;

    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<AudioManager>();
            }

            return _instance;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {

        //if this doesn't exist yet...
        if (_instance == null)
            //set instance to this
            _instance = this;
        //If instance already exists and it's not this:
        else if (_instance != null && _instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

    }

    public void StopMusic()
    {
        backgroundMusic.Stop();
    }

    //make sure i is in range of songs (SONG BIBLE)
    public void PlaySong(int i)
    {
        backgroundMusic.Stop();
        backgroundMusic.clip = songs[i];
        backgroundMusic.Play();
    }


    //make sure i is in range
    public void PlaySoundEffect(int i)
    {
        soundFX.PlayOneShot(soundEffects[i]);
    }

}
