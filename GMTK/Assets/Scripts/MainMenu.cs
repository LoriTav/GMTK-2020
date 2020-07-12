using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu : MonoBehaviour
{
    //public SoundManager soundManager;
    public Canvas MainCanvas;
    public Canvas ControlsCanvas;
    public Canvas OptionsCanvas;

    private void Start()
    {
        SoundManager.instance.playLevelBackground(0);
    }

    public void StartButtonPressed()
    {
        ScoreManager.instance.ResetScoreManager();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SoundManager.instance.playLevelBackground(1);
    }

    public void OptionsButtonPressed()
    {
        OptionsCanvas.enabled = true;
        MainCanvas.enabled = false;
        ControlsCanvas.enabled = false;
    }

    public void ThemeOffButtonPressed()
    {
        //soundManager.ThemeVolumeOff();
    }

    public void ThemeOnButtonPressed()
    {
        //soundManager.ThemeVolumeOn();
    }

    public void SFXOffButtonPressed()
    {
        //soundManager.SFXVolumeOff();
    }

    public void SFXOnButtonPressed()
    {
        //soundManager.SFXVolumeOn();
    }

    public void ControlsButtonPressed()
    {
        ControlsCanvas.enabled = true;
        OptionsCanvas.enabled = false;
        MainCanvas.enabled = false;
    }

    public void BackButtonPressed()
    {
        MainCanvas.enabled = true;
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
