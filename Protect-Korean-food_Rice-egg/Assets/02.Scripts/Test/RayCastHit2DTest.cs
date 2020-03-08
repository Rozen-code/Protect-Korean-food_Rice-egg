using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastHit2DTest : MonoBehaviour
{
    float MaxDistance = 15f;
    Vector3 MousePos;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MousePos = Input.mousePosition;
            MousePos = cam.ScreenToWorldPoint(MousePos);

            RaycastHit2D hit = Physics2D.Raycast(MousePos, transform.forward, MaxDistance);
            Debug.DrawRay(MousePos, transform.forward * 10, Color.red, 0.3f);

            if (hit)
            {
                hit.collider.GetComponent<CatchItBoxCtrl>().bcState = CatchItBoxCtrl.BCState.DIE;
            }
        }
    }
}
