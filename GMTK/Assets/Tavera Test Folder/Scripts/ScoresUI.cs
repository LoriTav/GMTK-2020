using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoresUI : MonoBehaviour
{
    public Text totalScoreText;
    public Text[] frameScoreTexts;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalScoreText.text = ScoreManager.instance.totalScore.ToString();
        UpdateFramesUI();
    }

    void UpdateFramesUI()
    {
        for(int i = 0; i < ScoreManager.instance.frames.Length; i++)
        {
            frameScoreTexts[i].text = ScoreManager.instance.frames[i].score.ToString();
        }
    }
}
