using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
// audio source 삭제 방지
public class FireCtrl : MonoBehaviour
{
    // private 상태 유지하면서 inspector에 노출할 수 있음
    [SerializeField]
    private new AudioSource audio;

    public GameObject bulletPrefab;
    public Transform firePos;
    public AudioClip fireSfx;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            Fire();
        }
    }

    // 총알 생성하는 함수 따로 생성 (Update 줄이기 위해)
    void Fire()
    {
        // 총알 생성
        // Instantiate (생성할객체, 위치, 각도)
        Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        // 사운드 발생 (sound, volume scale)
        audio.PlayOneShot(fireSfx, 0.8f);
    }
}
