using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPooling : MonoBehaviour
{
    public GameObject stuffPrefab;

    public int prefabCount;
    public float spawnTime;

    private GameObject[] stuffPool;
    
    private int nowSpawnObj;
    private float time;
    
    void Start()
    {
        stuffPool = new GameObject[prefabCount];
        // 자식들 가져와서 배열에 넣어 관리하기.
        for(nowSpawnObj = 0; nowSpawnObj < prefabCount; nowSpawnObj++)
        {
            stuffPool[nowSpawnObj] = Instantiate(stuffPrefab,this.transform);
            // Debug.Log("실행!");
            stuffPool[nowSpawnObj].gameObject.GetComponent<CatchWhatFallsBoxCtrl>().bcState 
                = CatchWhatFallsBoxCtrl.BCState.HIDE;
        }
        nowSpawnObj = 0;

    }

    // 일정 시간이 될때마다 소환
    // 소환 되면서 떨어지는 것의 정보 갱신(재료에 대한것, 해당 오브젝트 활성화)
    // 그리고 플레이어와 충돌 시 이벤트 발생
    // 이벤트 = 획득한 것에 대한 것을 판단하여 score 갱신하고
    // 소환 된 것은 다시 풀링의 위치도 돌아가면서 비활성화

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(spawnTime <= time) 
        {
            Debug.Log("실행!" + nowSpawnObj);
            time = 0.0f;
            stuffPool[nowSpawnObj].gameObject.SetActive(true);
            stuffPool[nowSpawnObj].gameObject.GetComponent<CatchWhatFallsBoxCtrl>().bcState
                = CatchWhatFallsBoxCtrl.BCState.APPEAR;
            nowSpawnObj++;
            if (nowSpawnObj >= prefabCount)
                nowSpawnObj = 0;
        }
    }
}
