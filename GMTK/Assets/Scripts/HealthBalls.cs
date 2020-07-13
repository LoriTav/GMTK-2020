using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBalls : MonoBehaviour
{
    public GameObject[] healthBalls;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthBallsUI()
    {

        foreach(var ball in healthBalls)
        {
            ball.SetActive(false);
        }

        for(int i = 0; i < ScoreManager.instance.currentLives; i++)
        {
            healthBalls[i].SetActive(true);
        }
    }
}
