using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoadManager : MonoBehaviour
{
    public string strSceneName;


    public void LoadScene()
    {
        GameObject.Find("NextScene").GetComponent<NextSceneSave>().nextSceneName = strSceneName;
        SceneManager.LoadScene("Load");
    }

    public void LoadScene(Button btn)
    {
        strSceneName = btn.name;
        GameObject.Find("NextScene").GetComponent<NextSceneSave>().nextSceneName = strSceneName;
        SceneManager.LoadScene("Load");
    }
}
