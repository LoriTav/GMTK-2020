using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBeatCanvas : MonoBehaviour
{
    public Canvas OnBeatC;
    public bool timerOn = false;
    public float timer;
    public float onBeatDelay = .1f;
    public EnemyManager enemyManager;

    // Start is called before the first frame update
    void Start()
    {
        timer = .5f;
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
        }
    }

    public void CanvasOn()
    {
        enemyManager.DelayEnemies(onBeatDelay);
        OnBeatC.enabled = true;
        timerOn = true;
    }

    public void EverythingOff()
    {
        timerOn = false;
        timer = .5f;
        OnBeatC.enabled = false;
    }
}
