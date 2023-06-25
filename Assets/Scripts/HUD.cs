using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    // 총알 정보를 얻기 위해 📜Gun.cs, 📜GunController.cs 가 필요
    [SerializeField]
    private GunController theGunController;
    private Gun currentGun;

    // 총알 텍스트 UI들을 담았던 이미지 UI를 할당할 것이다. 필요할 때 HUD를 호출하고 필요 없을 땐 비활성화 할 것이다.
    [SerializeField]
    private GameObject go_BulletHUD;

    // 총알 개수를 텍스트 UI에 반영
    [SerializeField]
    private Text[] text_Bullet;  

    void Update()
    {
        CheckBullet();
    }

    private void CheckBullet()
    {
        currentGun = theGunController.GetGun();
        text_Bullet[0].text = currentGun.carryBulletCount.ToString();
        text_Bullet[1].text = currentGun.reloadBulletCount.ToString();
        text_Bullet[2].text = currentGun.currentBulletCount.ToString();
    }
}