using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public List<GameObject> livesRends;
    public int currentFrameIdx = 0;
    private int MaxLives = 3;
    public int currentLives = 3;
    public bool isGameOver = false;
    public float framesLoadTimer = 3;
    public int totalScore = 0;

    private float timer = 0;

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

        totalScore = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetScoreManager();
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
        
        // Stop spawning enemies
        EnemyManager.instance.isActivated = false;

        // Destroy any enemies left
        foreach(GameObject enemy in EnemyManager.instance.enemiesOnField)
        {
            Destroy(enemy.gameObject);
        }

        HUD.frameNum = currentFrameIdx + 1;

        // Go to next frame
        if (currentFrameIdx + 1 < frames.Length)
        {
            LoadFrameSequence();
            currentFrameIdx++;
        }
        else
        {
            isGameOver = true;
        }
    }

    public void IncreaseScoreInCurrentFrame(int scoreToAdd)
    {
        if(isGameOver) { return; }
        frames[currentFrameIdx].score += scoreToAdd;
        totalScore += scoreToAdd;
    }

    public void IncreaseEnemyKillInCurrentFrame()
    {
        if(isGameOver) { return; }

        frames[currentFrameIdx].enemiesKilled++;

        if(frames[currentFrameIdx].enemiesKilled >= 10)
        {
            CompleteFrame();
        }
    }

    private void LoadFrameSequence()
    {
        EnemyManager.instance.RestartEnemyManager();
        timer = framesLoadTimer;
    }

    public void ResetScoreManager()
    {
        foreach(Frame frame in frames)
        {
            frame.enemiesKilled = 0;
            frame.score = 0;
        }
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            foreach (var x in livesRends)
                x.SetActive(true);
        }
        currentLives = MaxLives;
        isGameOver = false;
        currentFrameIdx = 0;
        timer = framesLoadTimer;
        totalScore = 0;
    }

    public void ReduceALive()
    {
        if(isGameOver) { return; }

        currentLives--;

        livesRends[0].SetActive(false);

        if(currentLives <= 0)
        {
            isGameOver = true;
            SceneManager.LoadScene(2);
        }
    }
}
