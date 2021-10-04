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

    [HideInInspector]  // Unity 문법
    // C# 문법인 [System.NonSerialized] 도 사용 가능
    public MeshRenderer muzzleFlash;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        muzzleFlash = firePos.GetComponentInChildren<MeshRenderer>();
        muzzleFlash.enabled = false;
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
        StartCoroutine(ShowMuzzleFlash());
    }

    // coroutine 함수 - multi thread처럼 처리해줌
    IEnumerator ShowMuzzleFlash()
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

        // 크기변경
        float scale = Random.Range(1.0f, 3.0f);
        muzzleFlash.transform.localScale = Vector3.one * scale;

        // MuzzleFlash의 회전
        float angle = Random.Range(0, 360);
        muzzleFlash.transform.localRotation = Quaternion.Euler(Vector3.forward * angle);

        // MeshRenderer 컴포넌트를 활성화
        muzzleFlash.enabled = true;

        // coroutine을 이용해서 waiting 걸어주기
        yield return new WaitForSeconds(0.2f);

        // MeshRenderer 컴포넌트를 비활성화
        muzzleFlash.enabled = false;
    }
}
