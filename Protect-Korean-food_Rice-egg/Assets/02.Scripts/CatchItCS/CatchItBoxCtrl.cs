using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

// Box에 상태 갱신
// 등장하는 AOT 관리
public class CatchItBoxCtrl : MonoBehaviour
{
    // Food Ingredient Type.
    public enum FIT 
    {
        BOSS_LIFE,
        PLAYER_LIFE,
        RICE,
        BUCKWHEAT,
        FLOUR,
        BEAN_SPROUTS,
    }

    // Appearing Object Type
    public enum AOT 
    {
        TOWNSMEN,
        STUFF_FF,
        STIFF_FF,
        Oil_FF,
        DESSERT_FF
    }

    // Box Controller State
    public enum BCState 
    {
        HIDE,
        APPEAR,
        DIE
    }

    // --------------------------------------------

    struct ObstacleInfor
    {
        public AOT NAME;
        private int aotLife;
        public FIT FIT;
        public int countFIT;

        public void Set(int aotLife, int countFIT)
        {
            this.aotLife = aotLife;
            this.countFIT = countFIT;
        }
    };

    // --------------------------------------------

    public bool executable;

    public Sprite[] sprites;
    public BCState bcState;

    private float waitTime;
    
    private WeightedRandom weightedRandom;
    private ScoreManager scoreManager;
    private Timer timer;
    private ObstacleInfor oi;
    private BoxCollider2D collider2d;
    private SpriteRenderer spriteRenderer;

    // --------------------------------------------

    void Awake()
    {
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        scoreManager = GameObject.Find("Score").GetComponent<ScoreManager>();
        collider2d = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        weightedRandom = WeightedRandom.Instance;
        collider2d.enabled = false;
        bcState = BCState.HIDE;
        executable = true;
        waitTime = 0.2f;
        // spriteRenderer.sprite = sprites[(int)BCState.HIDE]; 
        // Debug.Log(Enum.GetNames(typeof(BCState)).Length);
    }

    void Update()
    {
        if (bcState == BCState.DIE)
            spriteRenderer.sprite = sprites[(int)BCState.DIE];
        if (executable)
        {
            executable = false;
            StartCoroutine(PlayDelayCtrl());
        }
    }

    // --------------------------------------------

    // 
    void ChangeBCStae()
    {
        switch (bcState)
        {
            case BCState.HIDE:
                spriteRenderer.sprite = sprites[(int)BCState.HIDE];
                collider2d.enabled = false;
                ChangeFF();
                waitTime = Random.Range(1.0f, 5.0f - timer.nowRound);
                bcState = BCState.APPEAR;
                break;
            case BCState.APPEAR:
                spriteRenderer.sprite = sprites[(int)oi.NAME+3];
                collider2d.enabled = true;
                // spriteRenderer.sprite = sprites[(int)BCState.APPEAR];
                waitTime = Random.Range(1.0f, 3.0f - (timer.nowRound * 0.5f));
                bcState = BCState.HIDE;
                break;
            case BCState.DIE:
                // 획득 재료 갱신
                UpdatingScore();
                spriteRenderer.sprite = sprites[(int)BCState.DIE];
                collider2d.enabled = false;
                waitTime = 1.0f;
                bcState = BCState.HIDE;
                break;
            default:
                Debug.Log("BCState에 예상치 못한 값이 들어왔거나 값이 없습니다.");
                break;
        }
        // Debug.Log(spriteRenderer.sprite);
        // Debug.Log("변경된 Time : " + Time.time.ToString("N1"));
    }

    // 적 정보 갱신
    void ChangeFF()
    {
        oi.NAME = (AOT)Random.Range(0, (Enum.GetNames(typeof(AOT)).Length)-1);
        oi.FIT = (FIT)weightedRandom.RC();
        // Debug.Log(oi.FIT + " ");

        // set(적 목숨, 횟득하는 것의 갯수)
        switch ((int)oi.NAME)
        {
            case 0: // 지나가는 시민
                oi.Set(1, -1);
                oi.FIT = FIT.PLAYER_LIFE;
                break;
            case 1: // 재료 패스트 푸드
                oi.Set(1, 1);
                break;
            case 2: // 딱딱한 패스트 푸드
                oi.Set(2, 1);
                break;
            case 3: // 기름탄 패스트 푸드
                oi.Set(1, 0);
                // BackScreen();
                break;
            case 4: // 디저트 패스트 푸드
                oi.Set(2, 1);
                break;
        }
    }

    void UpdatingScore()
    {
        Debug.Log(oi.FIT);
        if (oi.FIT != FIT.PLAYER_LIFE)
        {
            scoreManager.score[(int)oi.FIT] += oi.countFIT;
            scoreManager.TotalScore();
        }
        else
            scoreManager.playerLife += oi.countFIT;
    }

    void BackScreen()
    {
        // 화면 가리개하는 코드 작성
        if(oi.NAME == AOT.Oil_FF)
        {
            collider2d.enabled = false;
        }
    }

    // --------------------------------------------

    IEnumerator PlayDelayCtrl()
    {
        ChangeBCStae();
        //spriteRenderer.sprite = sprites[(int)BCState.DIE];
        yield return new WaitForSeconds(waitTime);
        executable = true;
    }



    /*IEnumerator test()
    {
        Debug.Log("start");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Test1");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Test2");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("end");
    }*/
}
