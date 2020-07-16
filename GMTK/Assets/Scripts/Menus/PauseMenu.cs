using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseMenu : MonoBehaviour
{
    //public SoundManager soundManager;
    public Canvas PauseCanvas;
    public Canvas ControlsCanvas;
    public Canvas OptionsCanvas;
    public bool isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 1)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void ResumeGame()
    {
        //resume
        Time.timeScale = 1;
        //close all canvases
        PauseCanvas.enabled = false;
        ControlsCanvas.enabled = false;
        OptionsCanvas.enabled = false;
        isPaused = false;
    }
    public void PauseGame()
    {
        //pause
        Time.timeScale = 0;
        //makes sure all but pause canvas are closed initially
        PauseCanvas.enabled = true;
        ControlsCanvas.enabled = false;
        OptionsCanvas.enabled = false;
        isPaused = true;
    }

    public void OptionsButtonPressed()
    {
        OptionsCanvas.enabled = true;
        PauseCanvas.enabled = false;
        ControlsCanvas.enabled = false;
    }

    public void ThemeOffButtonPressed()
    {
        SoundManager.instance.disableBackgroundMusic();
    }

    public void ThemeOnButtonPressed()
    {
        SoundManager.instance.enableBackgroundMusic();
    }

    public void SFXOffButtonPressed()
    {
        SoundManager.instance.disableSoundEfxVolume();
    }

    public void SFXOnButtonPressed()
    {
        SoundManager.instance.enableSoundEfxVolume();
    }

    public void ControlsButtonPressed()
    {
        ControlsCanvas.enabled = true;
        OptionsCanvas.enabled = false;
        PauseCanvas.enabled = false;
    }

    public void BackButtonPressed()
    {
        PauseCanvas.enabled = true;
        ControlsCanvas.enabled = false;
        OptionsCanvas.enabled = false;
    }

    public void ExitButtonPressed()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
