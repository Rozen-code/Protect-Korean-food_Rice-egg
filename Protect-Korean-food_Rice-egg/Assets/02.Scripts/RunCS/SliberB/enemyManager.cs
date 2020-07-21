using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    public bool enableSpawn = false;
    public GameObject yum; //Prefab을 받을 public 변수 입니다.
    void SpawnEnemy()
    {
        float randomY = Random.Range(-4,-4); //적이 나타날 Y좌표를 랜덤으로 생성해 줍니다.
        if (enableSpawn)
        {
            GameObject enemy = (GameObject)Instantiate(yum, new Vector3(10f, randomY, -0.01f), Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 yum를 하나 생성해줍니다.
        }
    }

    void SpawnEnemy1()
    {
        float randomY = Random.Range(-1, -1); //적이 나타날 Y좌표를 랜덤으로 생성해 줍니다.
        if (enableSpawn)
        {
            GameObject enemy = (GameObject)Instantiate(yum, new Vector3(10f, randomY, -0.01f), Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 yum를 하나 생성해줍니다.
        }
    }

    void SpawnEnemy2()
    {
        float randomY = Random.Range(2, 2); //적이 나타날 Y좌표를 랜덤으로 생성해 줍니다.
        if (enableSpawn)
        {
            GameObject enemy = (GameObject)Instantiate(yum, new Vector3(10f, randomY, -0.01f), Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 yum를 하나 생성해줍니다.
        }
    }

    void Start()
    {
        InvokeRepeating("SpawnEnemy", Random.Range(0.1f, 2.0f), Random.Range(2.1f,9.5f)); //3초후 부터, SpawnEnemy함수를 1초마다 반복해서 실행 시킵니다.
        InvokeRepeating("SpawnEnemy1", Random.Range(0.1f, 2.0f), Random.Range(1.5f, 11.6f));
        InvokeRepeating("SpawnEnemy2", Random.Range(0.1f, 2.0f), Random.Range(2.2f, 7.2f));
       
    }
    void Update()
    {

    }
}

