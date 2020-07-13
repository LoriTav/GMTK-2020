using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndSceneComp : MonoBehaviour
{
    public Text scoreValue;
    public float timeToLoop = 3;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (scoreValue)
        {
            scoreValue.text = ScoreManager.instance.totalScore.ToString();
        }

        timer = timeToLoop;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
