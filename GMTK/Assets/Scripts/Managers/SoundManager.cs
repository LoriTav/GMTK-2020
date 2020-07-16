using System.Collections;
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
    public AudioClip playerWinSoundEfx;         // Default is the "Many Pins" sound effect
    public AudioClip playerLoseSoundEfx;        // Default is the "Death" sound effect

    public AudioClip[] pinsHit;                 // When a pin is KO'd, it will play a random sound effect from this array

    public AudioSource backgroundAS;            // Should loop
    public AudioSource gameOverAS;              // This is a sound effect. Should not loop when played
    public AudioSource slotsRollingEfx;
    public AudioSource slotsPrizeEfx;

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
        backgroundAS.loop = true;
        gameOverAS.loop = false;
        playLevelBackground(SceneManager.GetActiveScene().buildIndex);
        backgroundAS.volume = backgroundVolume;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public AudioClip GetRandomPinHit()
    {
        int rndIndex = Random.Range(0, pinsHit.Length);

        return pinsHit[rndIndex];
    }

    public void playLevelBackground(int lvlIndex)
    {
        if(!backgroundAS) { return; }

        AudioClip audioToPlay = lvlIndex == 0 ? mainMenuTheme : bowlingTheme;

        
        backgroundAS.clip = audioToPlay;
        backgroundAS.Play();
    }

    public void PlayGameOver(bool didPlayerWin)
    {
        if(!gameOverAS) { return; }
        backgroundAS.Stop();

        gameOverAS.volume = soundEfxVolume;
        gameOverAS.clip = didPlayerWin ? playerWinSoundEfx : playerLoseSoundEfx;
        gameOverAS.Play();
    }

    public void PlaySlotsRolling()
    {
        slotsRollingEfx.Play();
    }

    public void PlaySlotsPrize()
    {
        slotsPrizeEfx.Play();
        slotsRollingEfx.Stop();
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
