using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameList : MonoBehaviour
{
    public Sprite[] miniGameList;
    private int ListNumber = 0;

    void Start()
    {
        ChangeMiniGame();
    }

    
    void Update()
    {
        
    }

    public void MiniGameRight() {
        if(ListNumber >= miniGameList.Length - 1) {
            ListNumber = ListNumber % (miniGameList.Length - 1);
        }
        else {
            ListNumber++;
        }

        ChangeMiniGame();
    }

    public void MiniGameLeft() {
        if(ListNumber <= 0) {
            ListNumber = miniGameList.Length - 1;
        }
        else {
            ListNumber--;
        }
        
        ChangeMiniGame();
    }

    void ChangeMiniGame() {
        this.GetComponent<Image>().sprite = miniGameList[ListNumber];
    }
}
