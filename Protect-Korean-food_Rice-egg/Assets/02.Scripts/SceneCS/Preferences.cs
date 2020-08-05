using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Preferences : MonoBehaviour
{
    bool isClick;
    bool preferencesListSee;
    float delayTime;
    public float delayTimeMax;
    public GameObject pList;
    

    // Start is called before the first frame update
    void Start()
    {
        isClick = false;
        preferencesListSee = false;
        pList.GetComponent<Image>().fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isClick)
        {
            delayTime += Time.deltaTime;

            pList.GetComponent<Image>().fillAmount
            += (preferencesListSee) ? (Time.deltaTime / delayTimeMax) : (Time.deltaTime / delayTimeMax) * (-1);
        }
        
        if (delayTime > delayTimeMax )
            isClick = false;
    }

    public void PreferencesListView()
    {
        preferencesListSee = (preferencesListSee) ? false : true;
        isClick = true;
        delayTime = 0;
    }

    /* IEnumerator Test() 
    {
        yield return null;

        while(delayTime < delayTimeMax)
        {
            delayTime += Time.deltaTime;

            //.....


            yield return new WaitForSeconds(Time.deltaTime);
        }
    } */
}
