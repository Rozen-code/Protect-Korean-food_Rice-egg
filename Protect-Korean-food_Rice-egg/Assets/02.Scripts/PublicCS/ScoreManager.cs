using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    public static ScoreManager Instance
    {
        get { return instance; }
    }

    public int playerLife;
    public int nowTotalScore;
    
    public int[] score;

    private int totalScore;

    private void Awake()
    {
        if (instance != null) Destroy(this);
        instance = this;

    }

    void Start()
    {
        score = new int[this.gameObject.GetComponent<WeightedRandom>().drawingPercentage.Length];
        // Debug.Log(score.LongLength + " ~!!!!!!!!!!!!!!!!!!!!" + score);
    }

    public void TotalScore()
    {
        int result = 0;
        for(int i = 0; i < score.Length; i++)
        {
            result += score[i];
        }
        nowTotalScore = result;
    }

    private int TotalScore(int[] scores, int count)
    {
        if (count <= 0)
            return scores[count] + TotalScore(scores, count - 1);
        return 0;
    }

    
}
 