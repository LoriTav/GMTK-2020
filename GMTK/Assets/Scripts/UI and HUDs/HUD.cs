﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    //public ScoreManager scoreMan;
    public Inventory inventory;
    public Image life1;
    public Image life2;
    public Image life3;
    public Text Score;
    public Text RScore1;
    public Text RScore2;
    public Text RScore3;
    public Text RScore4;
    public Text RScore5;
    public Text RScore6;
    public Text RScore7;
    public Text RScore8;
    public Text RScore9;
    public Text RScore10;

    public int score = 0;

    public static int frameNum;     //update in scoremanager
    // Start is called before the first frame update
    void Start()
    {
        frameNum = 1;
        inventory = FindObjectOfType<Inventory>();

        RScore1.text = "";
        RScore2.text = "";
        RScore3.text = "";
        RScore4.text = "";
        RScore5.text = "";
        RScore6.text = "";
        RScore7.text = "";
        RScore8.text = "";
        RScore9.text = "";
        RScore10.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //score = ScoreManager.instance.score;

        Score.text = "Score:\t" + score;

        if (ScoreManager.instance.currentLives == 2)
        {
            life3.enabled = false;
        }
        if (ScoreManager.instance.currentLives == 1)
        {
            life3.enabled = false;
            life2.enabled = false;
        }
        if (ScoreManager.instance.currentLives <= 0)
        {
            life3.enabled = false;
            life2.enabled = false;
            life1.enabled = false;
        }
        else
        {
            life3.enabled = true;
            life2.enabled = true;
            life1.enabled = true;
        }

        if (frameNum == 1)
        {
            RScore1.text = "" + score;
        }

        if (frameNum == 2)
        {
            RScore2.text = "" + score;
        }

        if (frameNum == 3)
        {
            RScore3.text = "" + score;
        }

        if (frameNum == 4)
        {
            RScore4.text = "" + score;
        }

        if (frameNum == 5)
        {
            RScore5.text = "" + score;
        }

        if (frameNum == 6)
        {
            RScore6.text = "" + score;
        }

        if (frameNum == 7)
        {
            RScore7.text = "" + score;
        }

        if (frameNum == 8)
        {
            RScore8.text = "" + score;
        }

        if (frameNum == 9)
        {
            RScore9.text = "" + score;
        }

        if (frameNum == 10)
        {
            RScore10.text = "" + score;
        }

    }

}