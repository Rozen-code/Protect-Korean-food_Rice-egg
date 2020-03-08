using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManagers : MonoBehaviour
{
    GameObject player;
    PlayerMove playerScript;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerMove>();
    }
    public void LeftClick()
    {
        playerScript.inputLeft = true;
    }
    public void LeftNonClick()
    {
        playerScript.inputLeft = false;
    }
    public void RightClick()
    {
        playerScript.inputRight = true;
    }
    public void RightNonClick()
    {
        playerScript.inputRight = false;
    }
    public void UpClick()
    {
        playerScript.inputUp = true;
    }
    public void UpNonClick()
    {
        playerScript.inputUp = false;
    }
    public void DownClick()
    {
        playerScript.inputDown  = true;
    }
    public void DownNonClick()
    {
        playerScript.inputDown = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
