using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedRandom : MonoBehaviour
{
    private static WeightedRandom instance;
    public static WeightedRandom Instance
    {
        get { return instance; }
    }

    public float[] drawingPercentage;

   // public int repeatCount;

    private float nowPoint;
    private float randomPivot;

    private void Awake()
    {
        if (instance != null) Destroy(this);
        instance = this;
    }

    /*private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            for(int i =0; i<repeatCount; i++)
                RC();
        }
    }*/

    public int RC() // Random Change
    {
        int i = 0;
        nowPoint = 0;
        randomPivot = Random.Range(0, 100);

        for (; i < drawingPercentage.Length; i++)
        {
            nowPoint += drawingPercentage[i];
            if (nowPoint >= randomPivot)
            {
                //Debug.Log("i = " + i + " 확인");
                break;
            }
        }

        nowPoint = 0;
        randomPivot = 0;

        return i;
    }
}
