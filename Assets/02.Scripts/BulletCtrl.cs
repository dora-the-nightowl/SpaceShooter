using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();  // generic type GetComponent<T>()

        rb.AddRelativeForce(Vector3.forward * 800.0f);  // 800 뉴턴으로 힘을 가한다.
    }

    // 사용하지 않는 Update (callback) 함수는 절대 남겨두지 않는다.
}
