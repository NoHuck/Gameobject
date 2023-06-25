
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGun : MonoBehaviour
{
    public Transform player;
    Camera cam;
    RaycastHit hit;
    public LayerMask MovingObj;
    LineRenderer lr;
    bool OnGrappling = false;
    Vector3 spot;
    public Transform handTip;


    void Start()
    {
        cam = Camera.main;
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RopeShoot();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            EndShoot();
        }
        DrawMove();
    }

    void RopeShoot(){
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 100f, MovingObj))
        {
            OnGrappling = true;
            lr.positionCount=2;
            lr.SetPosition(0, this.transform.position);  
            

            hit.transform.parent = handTip.transform;
            print("장애물 검출");
        }
    }

    void EndShoot(){
        OnGrappling =false;
        hit.transform.parent =null;
        lr.positionCount = 0;
    }

    void DrawMove(){
        if (OnGrappling){
            lr.SetPosition(0, handTip.position);
        }
    }
}