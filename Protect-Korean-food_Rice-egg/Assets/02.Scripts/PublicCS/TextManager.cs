using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    Timer timer;
    ScoreManager scoreManager;

    Text timerText;
    Text scoreText;
    Text lifeText;

    private void Awake()
    {
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        // scoreManager = GameObject.Find("Score").GetComponent<ScoreManager>();

        // Debug.Log(scoreManager);

        timerText = GameObject.Find("Timer").GetComponent<Text>();
        // scoreText = GameObject.Find("Score").GetComponent<Text>();
        // lifeText = GameObject.Find("Life").GetComponent<Text>();
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = timer.nowTime.ToString();
        //scoreText.text = scoreManager.nowTotalScore.ToString();
        //lifeText.text = scoreManager.playerLife.ToString();
    }
}
