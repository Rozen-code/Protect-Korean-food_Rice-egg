using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public Slider slider;
    public string strSceneName;
    
    bool IsDone = false;
    float fTime = 0f;
    AsyncOperation async_operation;


    void Start()
    {
        if (GameObject.Find("NextScene") != null)
            strSceneName = GameObject.Find("NextScene").GetComponent<NextSceneSave>().nextSceneName;
        StartCoroutine(StartLoad(strSceneName));
    }

    void Update()
    {
        fTime += Time.deltaTime;
        slider.value = fTime;

        if (fTime >= 2)
        {
            async_operation.allowSceneActivation = true;
        }
    }

    public IEnumerator StartLoad(string strSceneName)
    {
        async_operation = SceneManager.LoadSceneAsync(strSceneName);
        async_operation.allowSceneActivation = false;

        if (IsDone == false)
        {
            IsDone = true;

            while (async_operation.progress < 0.9f)
            {
                slider.value = async_operation.progress;

                yield return true;
            }
        }
    }
}



