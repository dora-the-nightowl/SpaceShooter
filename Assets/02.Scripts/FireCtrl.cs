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

    public MeshRenderer muzzleFlash;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        muzzleFlash = firePos.GetComponentInChildren<MeshRenderer>();
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

        // 총구화염 효과
        ShowMuzzleFlash();
    }

    void ShowMuzzleFlash()
    {
        /*
            총 4장으로 분리. (0, 0), (0.5, 0), (0, 0.5), (0.5, 0.5)
            0 ~ 0.5 사이의 난수 생성
            Random.Range는 (int, int)면 마지막 인자를 포함 x, (float, float)는 포함 o
            Random.Range(0, 3) ==> 0, 1, 2 
            Random.Range(0.0f, 3.0f) ==> 0.0f ~ 3.0f
        */

        Vector2 offset = new Vector2(Random.Range(0, 2) * 0.5f, Random.Range(0, 2) * 0.5f);
        muzzleFlash.material.mainTextureOffset = offset;
    }
}
