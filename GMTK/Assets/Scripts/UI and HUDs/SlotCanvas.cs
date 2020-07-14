using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotCanvas : MonoBehaviour
{
    public Canvas Slots;
    public SpriteRenderer s1;
    public SpriteRenderer s2;
    public SpriteRenderer s3;
    public SpriteRenderer s4;
    public SpriteRenderer s5;
    public bool timerOn = false;
    public bool timer2On = false;
    public float timer = .35f;
    public float timer2 = .05f;
    public float padding;
    public EnemyManager enemyManager;
    public PlayerMovement playerMovement;

    public bool isWorking = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = .35f;
        timer2 = .05f;
        padding = 1.65f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn == true)
        {
            timer -= Time.deltaTime;
        }

        if (timer2On == true)
        {
            timer2 -= Time.deltaTime;
        }

        if(timer < 0)
        {
            resultsOn();
        }

        if (timer2 < -1)
        {
            EverythingOff();
            PlayerMovement.isRandomizingSpell = false;
        }
    }

    public void CanvasOn()
    {
        PlayerMovement.isRandomizingSpell = true;
        enemyManager.DelayEnemies(padding);
        isWorking = true;
        Slots.enabled = true;
        s1.enabled = true;
        s2.enabled = false;
        s3.enabled = false;
        s4.enabled = false;
        s5.enabled = false;
        timerOn = true;
    }

    public void resultsOn()
    {
        isWorking = true;
        Slots.enabled = true;
        s1.enabled = false;
        s2.enabled = true;
        s3.enabled = true;
        s4.enabled = true;
        s5.enabled = true;
        timerOn = false;
        timer = .35f;
        timer2On = true;
    }

    public void EverythingOff()
    {
        isWorking = false;
        s1.enabled = false;
        s2.enabled = false;
        s3.enabled = false;
        s4.enabled = false;
        s5.enabled = false;
        timerOn = false;
        timer = .35f;
        timer2On = false;
        timer2 = .05f;
        Slots.enabled = false;
    }
}
