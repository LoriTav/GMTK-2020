using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveCanvas : MonoBehaviour
{
    public Canvas WaveC;
    public bool timerOn = false;
    public float timer = .35f;
    public float padding;
    public Text waveNumText;
    public int frameNum = 1;
    public EnemyManager enemyManager;

    public bool isWorking = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = .8f;
        padding = timer;
        CanvasOn();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn == true)
        {
            timer -= Time.deltaTime;
        }

        if (timer < 0)
        {
            EverythingOff();
            PlayerMovement.isRandomizingSpell = false;
        }

        frameNum = ScoreManager.instance.currentFrameIdx + 2;
    }

    public void CanvasOn()
    {
        waveNumText.text = "Wave " + frameNum;
        WaveC.enabled = true;
        PlayerMovement.isRandomizingSpell = true;
        enemyManager.DelayEnemies(padding);
        isWorking = true;
        timerOn = true;
    }

    public void EverythingOff()
    {
        isWorking = false;
        timerOn = false;
        timer = .8f;
        WaveC.enabled = false;
    }
}
