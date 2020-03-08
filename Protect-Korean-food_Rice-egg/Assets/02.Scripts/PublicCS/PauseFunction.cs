using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseFunction : MonoBehaviour
{
    public Sprite[] sprites;

    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        Time.timeScale = 1;
        image.sprite = (Time.timeScale == 1) ? sprites[0] : sprites[1];
    }

    public void OnClickPause()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            image.sprite = sprites[1];
        }
        else
        {
            Time.timeScale = 1;
            image.sprite = sprites[0];
        }
    }
}
