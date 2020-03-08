using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManagers : MonoBehaviour
{
    public float countTime;
    public Text textTimer;
    public Text textLife;
    GameObject player;
    PlayerMove playerScript;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerMove>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //Any Thing
    }

    // Update is called once per frame
    void Update()
    {
        textLife.text = "목숨 : " + playerScript.life;
        if(playerScript.life > 0)
        {
            countTime += Time.deltaTime;
            textTimer.text = "시간 : " + Mathf.Round(countTime);
        }
    }
}
