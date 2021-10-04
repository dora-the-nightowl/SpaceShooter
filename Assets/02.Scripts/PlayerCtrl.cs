using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    /*
        Pascal Phase    - 클래스, 함수명
        Camel Phase     - 변수명
    */
    /*
    void Awake()
    {
        // 처음 한번만 실행.
        // Start보다 먼저 호출됨.
        // Initialize, game data 전체 초기화
    }

    void OnEnable()
    {
        // event 함수. 매번 호출됨.
    }
    */

    private Animation anim;

    // 전역변수 이동, 회전 속도
    public float moveSpeed = 8.0f;
    public float turnSpeed = 100.0f;

    // Start is called before the first frame update
    // 처음 한번만 실행
    void Start()
    {
        // 컴포넌트를 추출해서 변수에 대입
        // anim = this.gameObject.GetComponent<Animation>();
        // 편의상 this.gameObject는 생략해서 사용
        anim = GetComponent<Animation>();

        anim.Play("Idle");
    }

    /* Update is called once per frame
    프레임 드랍 현상 때문에 호출이 불규칙적
    렌더링하는 주기와 동일
    최대한 간소화 하는게 좋음
    ex. 주인공 이동 로직 */
    void Update()
    {
        // -1.0f ~ 0.0f ~ +1.0f 값이 return됨.
        float h = Input.GetAxis("Horizontal");  // left, right
        float v = Input.GetAxis("Vertical");  // up, down
        float r = Input.GetAxis("Mouse X");  // mouse cursor left, right

        // (전진후진벡터) + (좌우벡터)
        Vector3 dir = (Vector3.forward * v) + (Vector3.right * h);

        // Debug.Log("dir=" + dir.magnitude);
        // Debug.Log("정규화 벡터 dir=" + dir.normalized.magnitude);

        // 이동처리
        transform.Translate(dir.normalized * Time.deltaTime * moveSpeed);

        // 회전처리
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * r);

        /*
            정규화 벡터(Normalized Vector), 단위 벡터(Unit Vector)
            Vector3.forward     = Vector3(0, 0, 1)
            Vector3.up          = Vector3(0, 1, 0)
            Vector3.right       = Vector3(1, 0, 0)
            반대방향은 *(-1)

            Vector3.one         = Vector3(1, 1, 1)
            Vector3.zero        = Vector3.(0, 0, 0)
        */

        // 애니메이션 처리
        PlayerAnim(h, v);
    }

    void PlayerAnim(float h, float v)
    {
        if (v >= 0.1f)  // 전진
        {
            // 애니메이션을 부드럽게 전환
            anim.CrossFade("RunF", 0.3f);
        }
        else if (v <= -0.1f)  // 후진
        {
            anim.CrossFade("RunB", 0.3f);
        }
        else if (h >= 0.1f)  // 오른쪽
        {
            anim.CrossFade("RunR", 0.3f);
        }
        else if (h <= -0.1f)  // 왼쪽
        {
            anim.CrossFade("RunL", 0.3f);
        }
        else {
            anim.CrossFade("Idle", 0.3f);
        }
    }

    /*
    void FixedUpdate()
    {
        // 호출되는 간격이 규칙적. (0.02s 간격으로 호출)
        // 물리 엔진이 백그라운드에서 계산하는 속도
    }

    
    void LateUpdate()
    {
        // Update 후 LateUpdate 실행
        // Update 계산 결과로 후처리 작업 실행
        // 반드시 계산처리가 끝난 후 실행되어야 함.
        // ex. 주인공 따라가는 카메라 로직
    }
    */
}

/*
    Animation Type

    - Legacy : 하위 호환성, 속도가 빠르지만 오직 코드로만 조종 가능. Animation 컴포넌트

    - Mecanim: Visual Editor 제공됨. Animator 컴포넌트
        - Generic
        - Humanoid : Retargetting, 이족보행, 15개 필수 bones
*/