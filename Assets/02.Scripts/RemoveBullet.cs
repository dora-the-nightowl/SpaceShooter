using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    // callback function, event
    void OnCollisionEnter(Collision coll)
    {
        // if (coll.collision.CompareTag("BULLET"))도 가능
        // if (coll.gameObject.tag == "BULLET")는 불필요한 메모리 사용하게 돼서 사용 안 함
        // 메모리 release할 때 garbage collection 때문에 렉 걸리기 때문
        if (coll.gameObject.CompareTag("BULLET"))
        {
            Debug.Log("총알 충돌했음 !!");
            Destroy(coll.gameObject);
        }
    }
}
