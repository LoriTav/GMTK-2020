﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Range(0,1)]
    public float soundEfxVolume;
    
    [Range(0,1)]
    public float backgroundVolume;

    public bool enableSoundEfx = true;
    public bool enableBackgroundTheme = true;

    public AudioClip bowlingTheme;
    public AudioClip mainMenuTheme; 
    public AudioClip[] pinsHit;
    public int tempLvlIndex;

    public AudioSource backgroundAS;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        backgroundAS = GetComponent<AudioSource>();
        backgroundAS.loop = true;

        playLevelBackground();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            UpdateNewVolumeSettings();
        }
    }

    public AudioClip GetRandomPinHit()
    {
        int rndIndex = Random.Range(0, pinsHit.Length);

        return pinsHit[rndIndex];
    }

    public void playLevelBackground()
    {
        //int lvlIndex = SceneManager.GetActiveScene().buildIndex;
        AudioClip audioToPlay = tempLvlIndex == 0 ? mainMenuTheme : bowlingTheme;

        UpdateNewVolumeSettings();
        backgroundAS.clip = audioToPlay;
        backgroundAS.Play();
    }

    public void UpdateNewVolumeSettings()
    {
        backgroundAS.volume = backgroundVolume;
        enableSoundEfx = !enableSoundEfx;
    }

    public void enableBackgroundMusic()
    {
        backgroundAS.volume = backgroundVolume;
    }
    public void disableBackgroundMusic()
    {
        backgroundAS.volume = 0;
    }
    public void enableSoundEfxVolume()
    {
        enableSoundEfx = true;
    }
    public void disableSoundEfxVolume()
    {
        enableSoundEfx = false;
    }
}
