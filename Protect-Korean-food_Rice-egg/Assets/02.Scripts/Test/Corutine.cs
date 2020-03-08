using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corutine : MonoBehaviour
{
    IEnumerator aaa;
    // Start is called before the first frame update
    void Start()
    {
        aaa = PlayDelayCtrl();
        StartCoroutine(aaa);
        //StopCoroutine(PlayDelayCtrl());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayDelayCtrl()
    {
        Debug.Log("test 1");
        yield return new WaitForSeconds(1.5f);
        Debug.Log("test 2");
        StopCoroutine(aaa);
        yield return new WaitForSeconds(1.5f);
        Debug.Log("test 3");
        yield return new WaitForSeconds(1.5f);
        Debug.Log("test 4");
        yield return new WaitForSeconds(1.5f);
    }
}
