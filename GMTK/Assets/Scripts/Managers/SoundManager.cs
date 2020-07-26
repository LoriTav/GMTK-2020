/*using System.Collections;
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
    public AudioSource slotsEfx;

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
        backgroundAS.volume = backgroundVolume;
        playLevelBackground(SceneManager.GetActiveScene().buildIndex);
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

        if(enableBackgroundTheme == true)
        {
            backgroundVolume= audioToPlay == mainMenuTheme ? 1f : 0.25f;
            backgroundAS.volume = backgroundVolume;
        }
        else 
        {
            disableBackgroundMusic();
        }
       

        backgroundAS.clip = audioToPlay;
        backgroundAS.Play();
    }

    public void PlayGameOver(bool didPlayerWin)
    {
        if(!gameOverAS) { return; }
        backgroundAS.Stop();

        gameOverAS.clip = didPlayerWin ? playerWinSoundEfx : playerLoseSoundEfx;

        if (enableSoundEfx == true)
        {
            gameOverAS.volume = gameOverAS.clip == playerLoseSoundEfx ? 1f : soundEfxVolume;
        }
        else
        {
            gameOverAS.volume = soundEfxVolume;
        }

        gameOverAS.Play();
    }

    public void PlaySlotsSound()
    {

        slotsEfx.volume = enableSoundEfx == true ? 1f : soundEfxVolume;
        
        slotsEfx.Play();
    }

    public void enableBackgroundMusic()
    {
        backgroundAS.volume = backgroundVolume;
        enableBackgroundTheme = true;
    }
    public void disableBackgroundMusic()
    {
        backgroundAS.volume = 0;
        enableBackgroundTheme = false;
    }
    public void enableSoundEfxVolume()
    {
        enableSoundEfx = true;
        soundEfxVolume = 0.222f;
    }
    public void disableSoundEfxVolume()
    {
        enableSoundEfx = false;
        soundEfxVolume = 0;
    }
}
*/