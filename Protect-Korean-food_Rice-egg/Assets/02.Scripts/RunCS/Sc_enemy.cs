using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_enemy : MonoBehaviour
{
    public float Speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

   
    void MoveControl()
    {

        float xMove = Speed * Time.deltaTime;
        transform.Translate(-xMove, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        MoveControl();

        //transform.Translate(-speed * Time.deltaTime, 0, 0);

    }
    
}
