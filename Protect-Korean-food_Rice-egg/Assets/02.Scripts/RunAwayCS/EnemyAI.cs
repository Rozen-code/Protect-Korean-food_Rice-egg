using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    
    private Transform PlayerTr;
    [SerializeField]
    private int nextIdx = 0;
    [SerializeField]
    private int time = 0;
    public List<Transform> wayPoints;
    public float speed = 0.03f;
    public float dist;

    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player"); //Tag 할당.

        if (player != null) //Player가 존재할 때.
        {
            PlayerTr = player.GetComponent<Transform>(); //Transform 컴포넌트 할당.
        }

        var group = GameObject.Find("Way Point Group");

        if (group != null)
        {
            group.GetComponentsInChildren<Transform>(wayPoints);
            wayPoints.RemoveAt(0);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dist = Vector2.Distance(PlayerTr.position, transform.position);

        if (dist < 2)
        {
            Vector2 chase = Vector2.MoveTowards(transform.position, PlayerTr.position, speed); //PlayerTr.position
            GetComponent<Rigidbody2D>().MovePosition(chase);
        }
        else if (transform.position != wayPoints[nextIdx].position) //PlayerTr.position
        {
            Vector2 patrol = Vector2.MoveTowards(transform.position, wayPoints[nextIdx].position, speed); //PlayerTr.position
            GetComponent<Rigidbody2D>().MovePosition(patrol);
            time++;
            if (time == 222)
            {
                nextIdx = Random.Range(0, 8);
                time = 0;
            }
        }
        else
        {
            nextIdx = Random.Range(0, 8);
            time = 0;
        }
    }
}
