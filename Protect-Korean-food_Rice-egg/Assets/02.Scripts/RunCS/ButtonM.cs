using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonM : MonoBehaviour
{
    GameObject player;
    Sc_Player playerScript;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Sc_Player>();
    }

    
    public void UPClick()
    {
        playerScript.UP = true;
    }
   
     public void UPNONClick()
      {
          playerScript.UP = false;
      } 

      public void DOWNClick()
      {
          playerScript.DOWN = true;
      }

      public void DOWNNONClick()
      {
          playerScript.DOWN = false;
      }
      

}
