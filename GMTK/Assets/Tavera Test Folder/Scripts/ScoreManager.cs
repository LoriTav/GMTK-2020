﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Frame
{
    public int score = 0;
    public int enemiesKilled = 0;
}

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Frame[] frames;
    public int currentFrameIdx = 0;
    public bool isGameOver = false;
    public float framesLoadTimer = 3;

    private float timer;

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
        currentFrameIdx = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver) { return; }

        if(timer <= 0)
        {
            EnemyManager.instance.isActivated = true;
        }

        timer -= Time.deltaTime;
    }

    public void CompleteFrame()
    {
        if(isGameOver) { return; }
        
        EnemyManager.instance.isActivated = false;
        Debug.Log("completed");

        foreach(GameObject enemy in EnemyManager.instance.enemiesOnField)
        {
            Destroy(enemy.gameObject);
        }

        if(currentFrameIdx + 1 < frames.Length)
        {
            LoadFrameSequence();
            currentFrameIdx++;
        }
        else
        {
            Debug.Log("Game over");
            isGameOver = true;
        }
    }

    public void IncreaseScoreInCurrentFrame(int scoreToAdd)
    {
        if(isGameOver) { return; }
        frames[currentFrameIdx].score += scoreToAdd;
    }

    public void IncreaseEnemyKillInCurrentFrame()
    {
        if(isGameOver) { return; }

        frames[currentFrameIdx].enemiesKilled++;
        Debug.Log("pew");

        if(frames[currentFrameIdx].enemiesKilled >= 2)
        {
            CompleteFrame();
        }
    }

    private void LoadFrameSequence()
    {
        timer = framesLoadTimer;
    }
}
