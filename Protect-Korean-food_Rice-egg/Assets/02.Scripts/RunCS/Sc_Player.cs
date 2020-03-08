using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sc_Player : MonoBehaviour
{
    Rigidbody2D ri;

    public float upMAX=0;//UP최대
    public float downMIN=0;//DOWN최대 
    public float pos=0;//이동

  
    public float Speed = 1;

    int count = 0;
    public Text countText;

    public bool UP = false;
    public bool DOWN = false;
   


    void Awake()
    {
        ri = GetComponent<Rigidbody2D>();
    }


   

    // Start is called before the first frame update
    void Start()
    {
        countText.text = "점수 : " + count;
    }

    // Update is called once per frame
    void Update()
    {
        if (pos < upMAX)
        {
            if (UP)
            {
                pos += 1;
                transform.Translate(new Vector2(0, 3));
            }
        }

        else if (pos > downMIN)
        {
            if (DOWN)
            {
                pos += -1;
                transform.Translate(new Vector2(0, -3));
            }
        }

    }


    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.tag == "yum")
        {
            Destroy(other.gameObject);
            count = count + 1;
            countText.text = "점수 : " + count;
        }

        if (other.tag == "enemy")
        {
            SceneManager.LoadScene("lose");
        }
    }
   
}
