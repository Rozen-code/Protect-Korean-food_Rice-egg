using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RunBoxCtrl : MonoBehaviour
{
    public enum FIT
    {
        BOSS_LIFE,
        ONION,
        GREEN_ONION,
        PEPPER,
        SESAME_SEED, 
        SMALL_PUDDLE,
        BIG_PUDDLE,
        FASTFOOD,
        MOLE
    }

    public enum BCState
    {
        HIDE,
        APPEAR,
        DIE
    }

    public float speed;
    public float maxSpawnTime;

    private int step;
    private float delTime;
    private float spawnTime;
    private float collHeightHalf;

    private float[] floorY;

    private Vector3 spawnPos;
    private FIT fit;
    private BCState bcState;
    private BoxCollider2D coll2D;
    private WeightedRandom rand;
    private ScoreManager scoreManager;

    private void Awake()
    {
        coll2D = GetComponent<BoxCollider2D>();
        rand = GameObject.Find("Score").GetComponent<WeightedRandom>();
        scoreManager = GameObject.Find("Score").GetComponent<ScoreManager>();
        Debug.Log(collHeightHalf);
    }

    void Start()
    {
        Transform[] transformFloor = GameObject.Find("FloorGroup").GetComponentsInChildren<Transform>();
        floorY = new float[transformFloor.Length - 1];

        for (int i = 1; i < transformFloor.Length; i++)
        {
            floorY[i - 1] = transformFloor[i].position.y;
        }

        bcState = BCState.HIDE;
        coll2D.enabled = false;
        collHeightHalf = coll2D.size.y / 2;
        spawnTime = Random.Range(1.0f, maxSpawnTime);
        spawnPos = this.GetComponentInParent<Transform>().position;
    }

    void Update()
    {
        if (Time.timeScale != 0)
            ChangeFIT();

        /*
        if (bcState == BCState.HIDE)
            delTime += Time.deltaTime;

        if (delTime >= spawnTime && bcState == BCState.HIDE) // 숨어있고 스폰 타임 되었을 때. 소환
        {
            coll2D.enabled = true;
            bcState = BCState.APPEAR;
            delTime = 0.0f; // 소환 되는 타임 초기화
            spawnTime = Random.Range(1.0f, maxSpawnTime);

            fit = (FIT)rand.RC(); // 소환되는 종류 설정
            step = Random.Range(0, floorY.Length); // 몇번째 줄에 소환되는지 설정
            this.transform.position = new Vector2(this.transform.position.x, floorY[step] + collHeightHalf); // 소환되는 위치 설정
        }

        if (bcState == BCState.APPEAR && Time.timeScale != 0)
            transform.Translate((-1) * speed, 0, 0);

        if (bcState == BCState.APPEAR && this.transform.position.x <= -4)
        {
            bcState = BCState.DIE;
        }

        if (bcState == BCState.DIE)
        {
            this.transform.position = spawnPos;
            coll2D.enabled = false;
            bcState = BCState.HIDE;
        }*/
    }

    void ChangeFIT()
    {
        switch ((int)bcState)
        {
            case 0: // HIDE
                delTime += Time.deltaTime;
                if(delTime >= spawnTime)
                {
                    coll2D.enabled = true;
                    bcState = BCState.APPEAR;
                    delTime = 0.0f; // 소환 되는 타임 초기화
                    spawnTime = Random.Range(1.0f, maxSpawnTime);

                    fit = (FIT)rand.RC(); // 소환되는 종류 설정
                    step = Random.Range(0, floorY.Length); // 몇번째 줄에 소환되는지 설정
                    this.transform.position = new Vector2(this.transform.position.x, floorY[step] + collHeightHalf); // 소환되는 위치 설정
                }
                break;
            case 1: // APPEAR
                if (this.transform.position.x <= -4)
                    bcState = BCState.DIE;
                else
                    transform.Translate((-1) * speed, 0, 0);
                break;
            case 2: // DIE
                this.transform.position = spawnPos;
                coll2D.enabled = false;
                bcState = BCState.HIDE;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("충돌!~!");
        bcState = BCState.DIE;
        if (coll.gameObject.tag == "Player" && (int)fit < (int)FIT.SMALL_PUDDLE)
        {
            scoreManager.score[(int)fit] += 1;
            scoreManager.TotalScore();
        }
    }
}