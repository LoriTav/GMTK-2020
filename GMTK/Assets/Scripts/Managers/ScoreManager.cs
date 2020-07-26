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
    public Inventory inventory;
    public Frame[] frames;
    public int currentFrameIdx = 0;
    private int MaxLives = 3;
    public int currentLives = 3;
    public bool isGameOver = false;
    public float framesLoadTimer = 3;
    public int totalScore = 0;
    public float gameOverDelay = 3;
    public EnemyManager enemyManager;
    public Transform camPosition;

    public bool SlotTimerOn = false;
    public float slotTimer = .8f;
    private float gameoverTimer = 0;
    private float framesTimer = 0;

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
        if(SlotTimerOn)
        {
            slotTimer -= Time.deltaTime;
        }

        if(slotTimer < 0 && SlotTimerOn)
        {
            inventory.UpdateUIMachineSlots();
            SlotTimerOn = false;
        }

        if (isGameOver && SceneManager.GetActiveScene().buildIndex == 1) 
        {
            if(gameoverTimer <= 0)
                SceneManager.LoadScene(2);

            gameoverTimer -= Time.deltaTime;
            return; 
        }

        if (framesTimer <= 0 && SceneManager.GetActiveScene().buildIndex == 1)
        {
            enemyManager.isActivated = true;
        }

        framesTimer -= Time.deltaTime;
    }

    public void CompleteFrame()
    {
        if (isGameOver) { return; }

        // Stop spawning enemies
        enemyManager.isActivated = false;

        // Destroy any enemies left
        foreach (GameObject enemy in enemyManager.enemiesOnField)
        {
            Destroy(enemy.gameObject);
        }

        // Go to next frame or game over
        if (currentFrameIdx + 1 < frames.Length)
        {
            enemyManager.RestartEnemyManager();
            framesTimer = framesLoadTimer;
            currentFrameIdx++;

            if(GameObject.Find("WaveCanvas"))
            {
                WaveCanvas waveC = GameObject.Find("WaveCanvas").GetComponent<WaveCanvas>();
                waveC.CanvasOn();
            }
        }
        else
        {
            GameOverSequence();
        }
    }

    public void IncreaseScoreInCurrentFrame(int scoreToAdd)
    {
        if (isGameOver || !enemyManager.isActivated) { return; }
        frames[currentFrameIdx].score += scoreToAdd;
        totalScore += scoreToAdd;
    }

    public void IncreaseEnemyKillInCurrentFrame()
    {
        if (isGameOver) { return; }

        frames[currentFrameIdx].enemiesKilled++;
    }

    // Reset values for when the player decides to loop
    public void ResetScoreManager()
    {
        foreach (Frame frame in frames)
        {
            frame.enemiesKilled = 0;
            frame.score = 0;
        }

        currentLives = MaxLives;
        isGameOver = false;
        currentFrameIdx = 0;
        framesTimer = framesLoadTimer;
        totalScore = 0;
        slotTimer = .8f;
    }

    // Updates UI to remove a bowling ball, ans checks for game over
    public void ReduceALive()
    {
        currentLives--;
        ShakeCamera();

        GameObject.Find("HealthBalls").GetComponent<HealthBalls>().UpdateHealthBallsUI();
       
        if (currentLives <= 0)
        {
            GameOverSequence();
        }
    }

    public void ShakeCamera()
    {
        int shakeIdx = currentLives == 0 ? 1 : 0;
        camPosition.GetComponent<Animator>().SetTrigger("shake");
        camPosition.GetComponent<Animator>().SetInteger("shakeIndex", shakeIdx);
    }

    // Add a delay when the game is over
    public void GameOverSequence()
    {
        gameoverTimer = gameOverDelay;
        isGameOver = true;
        //SoundManager.instance.PlayGameOver(currentLives > 0);       
    }
}
