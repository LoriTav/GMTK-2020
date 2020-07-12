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
    public float timer = .5f;
    public float timer2 = .8f;

    // Start is called before the first frame update
    void Start()
    {
        
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
        }
    }

    public void CanvasOn()
    {
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
        Slots.enabled = false;
        s1.enabled = false;
        s2.enabled = false;
        s3.enabled = false;
        s4.enabled = false;
        s5.enabled = false;
        timerOn = false;
        timer = .35f;
        timer2On = false;
        timer2 = .05f;
    }
}
