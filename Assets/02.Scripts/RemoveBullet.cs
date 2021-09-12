using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public GameObject sparkEffect;

    // callback function, event
    void OnCollisionEnter(Collision coll)
    {
        // if (coll.collision.CompareTag("BULLET"))도 가능
        // if (coll.gameObject.tag == "BULLET")는 불필요한 메모리 사용하게 돼서 사용 안 함
        // 메모리 release할 때 garbage collection 때문에 렉 걸리기 때문
        if (coll.gameObject.CompareTag("BULLET"))
        {
            Destroy(coll.gameObject);

            ContactPoint cp = coll.GetContact(0);
            // 충돌한 객체의 법선벡터를 반대 방향으로 뒤집음
            Vector3 _normal = -cp.normal;

            // 각도를 쿼터니언 타입으로 변환
            Quaternion rot = Quaternion.LookRotation(_normal);

            // spark effect 생성 후 0.4s delay 뒤 삭제
            GameObject obj = Instantiate(sparkEffect, cp.point, rot);
            Destroy(obj, 0.4f);
        }
    }
}
/*
    OnCollisionEnter    1
    OnCollisionStay     n
    OnCollisionExit     1

    Quaternion - x, y, z, w : 복소수 4차원벡터

    오일러회전(Euler) x -> y -> z
    3차원 공간에서 오일러회전을 하게 되면 짐벌락(Gimbal Lock)이 생김
    짐벌락을 방지하기 위해 Quaternion 도입


    AudioListener : 소리를 듣는 역할, scene에 1개만 존재해야 함.
    AudioSource   : 소리를 발생시키는 역할, 복수 가능.
*/