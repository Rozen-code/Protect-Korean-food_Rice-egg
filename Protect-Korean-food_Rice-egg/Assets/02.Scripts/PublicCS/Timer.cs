using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 라운드 갱신
// 시간 갱신
public class Timer : MonoBehaviour
{
    public float nextRoundTime;
    public float nowTime;

    public int nowRound;
    private float delTime;

    void Start()
    {
        nowRound = 1;
    }

    // Update is called once per frame
    void Update()
    {
        choose1Timer(10.0f);
        if (nowTime >= nextRoundTime && nextRoundTime <= 80)
            RoundCounter();
    }

    void choose1Timer(float decimalPointCount)
    {
        nowTime = (Mathf.Floor(Time.time * decimalPointCount) / decimalPointCount);
    }

    void choose2Timer(float decimalPointCount)
    {
        // ex)2.34556
        delTime += Time.deltaTime;

        // 23.4556 -> 23 -> 2.3;
        nowTime += (Mathf.Floor(delTime * decimalPointCount) / decimalPointCount);
    }

    void RoundCounter()
    {
        nowRound++;
        nextRoundTime *= 2;
    }
}
