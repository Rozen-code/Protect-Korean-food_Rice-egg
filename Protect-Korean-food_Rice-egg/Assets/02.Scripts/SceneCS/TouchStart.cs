using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchStart : MonoBehaviour
{
    Image image;
    float delayTime;
    public float delayTimeMax;

    void Start()
    {
        image = this.gameObject.GetComponent<Image>();    
    }

    // Update is called once per frame
    void Update()
    {
        delayTime += Time.deltaTime;
        if (delayTime > delayTimeMax)
        {
            delayTime = 0; 
            if(image.color.a == 1)
            {
                image.color = new Color(1, 1, 1, 0);
            }else if(image.color.a == 0)
            {
                image.color = new Color(1, 1, 1, 1);
            }
        }
    }
}
