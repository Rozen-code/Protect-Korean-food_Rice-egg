using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneSave : MonoBehaviour
{
    public string nextSceneName;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
