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
        scoreManager = GameObject.Find("Score").GetComponent<ScoreManager>();

        // Debug.Log(scoreManager);

        timerText = TextInstance("Timer");
        scoreText = TextInstance("Score");
        lifeText = TextInstance("Life");

        // Debug.Log(timerText);
        // Debug.Log(scoreText);
        // Debug.Log(lifeText);
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        TextUpdate(timerText, timer.nowTime.ToString());
        TextUpdate(scoreText, scoreManager.nowTotalScore.ToString());
        TextUpdate(lifeText, scoreManager.playerLife.ToString());
    }

    void TextUpdate(Text text, string textString)
    {
        if (text != null)
        {
            text.text = textString;
        }
    }

    Text TextInstance(string obj)
    {
        return (GameObject.Find(obj) != null) ? GameObject.Find(obj).GetComponent<Text>() : null;
    }
}
