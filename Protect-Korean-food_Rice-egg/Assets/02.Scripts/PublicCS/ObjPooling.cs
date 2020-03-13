using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPooling : MonoBehaviour
{
    public GameObject stuffPrefab;

    public int prefabCount;

    private GameObject[] stuffPool;
    
    void Start()
    {
        stuffPool = new GameObject[prefabCount];
        // 자식들 가져와서 배열에 넣어 관리하기.
        for (int spawnTime = 0; spawnTime < prefabCount; spawnTime++)
        {
            stuffPool[spawnTime] = Instantiate(stuffPrefab, this.transform);
            // Debug.Log("실행!");
        }
    }
}
