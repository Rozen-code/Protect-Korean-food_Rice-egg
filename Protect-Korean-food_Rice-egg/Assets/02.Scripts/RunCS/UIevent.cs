using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIevent : MonoBehaviour
{
    private bool pauseOn = false;

    public void ActivePause()
    {//일시정지 버튼 눌렀을 때 처리
        if (!pauseOn)
        {//일시정지 중이 아니면 일시정지
            Time.timeScale = 0; //시간 흐름 비율 0
        }
        else
        {//일시정지 중이면 해제
            Time.timeScale = 1.0f;//시간 흐름 비율 1
        }

        pauseOn = !pauseOn;//값 반전

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
