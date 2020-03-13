using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CatchWhatFallsPlayerCtrl : MonoBehaviour
{
    public float speed;

    private int direction;

    private Vector2 mousePos;
    private Camera camera;


    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
            // mousePos = new Vector2(mousePos.x,this.transform.position.y);
            direction = (mousePos.x > 0) ? 1 : -1;
            transform.Translate(direction * speed * Time.deltaTime, 0, 0);
            // Debug.Log(direction * speed);
        }
    }
}
