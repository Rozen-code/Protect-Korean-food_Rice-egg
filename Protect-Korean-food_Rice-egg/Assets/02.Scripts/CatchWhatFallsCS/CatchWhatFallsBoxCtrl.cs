using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CatchWhatFallsBoxCtrl : MonoBehaviour
{
    // Catch What Fall
    enum FIT // Appearing Object Type
    {
        BOSS_LIFE,
        STOON,
        ROTTEN_CABBAGE,
        CABBAGE,
        CORN,
        CUCUMBER,
        RADISH
    }

    public enum BCState
    {
        HIDE,
        APPEAR,
        DIE,
    }

    public float speed;
    public float maxSpawnTime;

    private bool hideRun; // Hide 상태에서 계속 적인 갱신을 없애기 위한 변수
    private float spawnTime;
    private float delTime;
    private float randomPos;
    private float startHeight;

    public BCState bcState;

    private FIT fit;
    private CircleCollider2D collider2d;
    private ScoreManager scoreManager;

    private void Awake()
    {
        collider2d = GetComponent<CircleCollider2D>();
        scoreManager = ScoreManager.Instance;
    }

    void Start()
    {
        collider2d.enabled = false;
        startHeight = GetComponentInParent<Transform>().position.y;
        hideRun = true;
        spawnTime = Random.Range(3, maxSpawnTime);
        bcState = BCState.HIDE;
    }

    void Update()
    {
        if(bcState == BCState.HIDE)
            delTime += Time.deltaTime;

        if (delTime >= spawnTime)
        {
            delTime = 0.0f;
            spawnTime = Random.Range(0, maxSpawnTime);
            bcState = BCState.APPEAR;
        }

        ChangeBCState();
    }

    void ChangeBCState()
    {
        switch (bcState)
        {
            case BCState.HIDE:
                if (hideRun)
                {
                    collider2d.enabled = false;
                    fit = (FIT)Random.Range(0, Enum.GetNames(typeof(FIT)).Length);
                    // img 변경
                    randomPos = Random.Range(-3f, 3f);
                    this.transform.position = new Vector3(randomPos, startHeight, 0);
                    hideRun = false;
                }
                break;
            case BCState.APPEAR:
                hideRun = true;
                collider2d.enabled = true;
                this.transform.Translate(0, -speed * Time.deltaTime, 0);
                break;
            case BCState.DIE:
                bcState = BCState.HIDE;
                if (!hideRun) // false일때 true 바꾸기 위해
                    hideRun = true;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Floor")
        {
            bcState = BCState.HIDE;
            if (coll.gameObject.tag == "Player")
            {
                // 스코어 갱신 함수 넣어야됨.
            }
        }
    }

    /* private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Floor")
        {
            // 플레이어 score 갱신
            bcState = BCState.HIDE;
            if(coll.gameObject.tag == "Player")
            {

            }
        }
    } */
}
