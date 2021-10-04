using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    private int hitCount = 0;
    // 폭발효과 prefab
    [SerializeField] private GameObject expEffect;

    void Start()
    {
        expEffect = Resources.Load<GameObject>("BigExplosionEffect");
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET"))
        {
            if (++hitCount == 3)
            {
                // 드럼통 폭발
                ExpBarrel();
            }
        }
    }

    void ExpBarrel()
    {
        Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();
        rb.AddForce(Vector3.up * 1200.0f);

        // 2초 후에 드럼통 오브젝트 삭제
        Destroy(this.gameObject, 2.0f);
        Instantiate(expEffect, transform.position, Quaternion.identity);
    }
}
