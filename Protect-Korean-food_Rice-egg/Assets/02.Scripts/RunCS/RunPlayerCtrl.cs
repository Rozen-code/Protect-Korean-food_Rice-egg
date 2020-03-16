using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunPlayerCtrl : MonoBehaviour
{
    private int step;

    private float[] floorY;

    private float collHeightHalf;

    private void Awake()
    {
        collHeightHalf = GetComponent<BoxCollider2D>().size.y/2;
    }

    void Start()
    {
        Transform[] transformFloor = GameObject.Find("FloorGroup").GetComponentsInChildren<Transform>();
        floorY = new float[transformFloor.Length - 1];

        for (int i = 1; i < transformFloor.Length; i++)
        {
            floorY[i - 1] = transformFloor[i].position.y;
            // Debug.Log(floorY[i - 1]);
        }
        step = 1;
    }

    public void OnBtnUp()
    {
        if(Time.timeScale != 0)
            step--;
        ChangePos();
    }

    public void OnBtnDown()
    {
        if (Time.timeScale != 0)
            step++;
        ChangePos();
    }

    void ChangePos()
    {
        if (step < 0)
            step = 0;
        else if (step > floorY.Length - 1)
            step = floorY.Length - 1;
        else
            Debug.Log("현재 위치 Step : " + step);
        this.transform.position = new Vector2(this.transform.position.x, floorY[step] + collHeightHalf);
    }
}
