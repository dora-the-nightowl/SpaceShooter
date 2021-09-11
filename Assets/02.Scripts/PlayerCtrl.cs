using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    /**
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

    // 처음 한번만 실행.
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    // 프레임 드랍 현상 때문에 호출이 불규칙적
    // 렌더링하는 주기와 동일
    // ex. 주인공 이동 로직
    void Update()
    {
        // -1.0f ~ 0.0f ~ +1.0f 값이 return됨.
        float h = Input.GetAxis("Horizontal");  // left, right
        float v = Input.GetAxis("Vertical");  // up, down
        float r = Input.GetAxis("Mouse X");  // mouse cursor left, right

        // 콘솔에 메세지 출력
        // Debug.Log("h=" + h + ", v=" + v);
        
        // (전진후진벡터) + (좌우벡터)
        Vector3 dir = (Vector3.forward * v) + (Vector3.right * h);

        // 이동방향 * 속도
        // transform.Translate(Vector3.forward * 0.1f * v);
        // transform.Translate(Vector3.right * 0.1f * h);

        Debug.Log("dir=" + dir.magnitude);
        Debug.Log("정규화 벡터 dir=" + dir.normalized.magnitude);

        // 이동처리
        transform.Translate(dir * 0.1f);

        // 회전처리
        transform.Rotate(Vector3.up * 100.0f * r);

        /*
        정규화 벡터(Normalized Vector), 단위 벡터(Unit Vector)
        Vector3.forward     = Vector3(0, 0, 1)
        Vector3.up          = Vector3(0, 1, 0)
        Vector3.right       = Vector3(1, 0, 0)
        반대방향은 *(-1)

        Vector3.one         = Vector3(1, 1, 1)
        Vector3.zero        = Vector3.(0, 0, 0)
    */
    }

    /**
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
