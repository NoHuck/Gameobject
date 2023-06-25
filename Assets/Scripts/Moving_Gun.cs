using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGun : MonoBehaviour
{
    [SerializeField]
    private MovingGunName currentMovingGun;

    public Transform player;
    Camera cam;
    RaycastHit hit;
    public LayerMask targetObj;
    LineRenderer lr;
    bool OnGrappling = false;
    Vector3 spot;
    public Transform handTip;
    
    SpringJoint sj;

    void Start()
    {
        cam = Camera.main;
        lr = GetComponent<LineRenderer>();
        WeaponManager.currentWeapon = currentMovingGun.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            RopeShoot();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            EndShoot();
        }
        DrawRope();
    }

    void RopeShoot(){
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 100f, targetObj))
        {
            /*OnGrappling =true;
            lr.positionCount=2;
            lr.SetPosition(0, this.transform.position);
            lr.SetPosition(1, hit.point);

            sj=player.gameObject.AddComponent<SpringJoint>();
            sj.autoConfigureConnectedAnchor = false; // 앵커위치 자동 계산 비활성
            sj.connectedAnchor = spot;

            float dis=Vector3.Distance(this.transform.position, spot);

            sj.maxDistance = dis;
            sj.minDistance = dis*0.5f;
            sj.spring = 5f; //강도
            sj.damper = 5f; // 줄어드는 힘
            sj.massScale=5f;*/
            print("장애물 검출");
            
        }
    }

    void EndShoot(){
        OnGrappling =false;
        lr.positionCount=0;
    }

    void DrawRope(){
        if (OnGrappling){
            lr.SetPosition(0, handTip.position);
        }
}
}
