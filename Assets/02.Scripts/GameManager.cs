using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 몬스터가 출현할 위치정보를 저장할 리스트
    public List<Transform> points = new List<Transform>();
    // 몬스터 prefab를 저장할 변수
    public GameObject monsterPrefab;
    // 몬스터의 생성 주기
    public float createTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        // 1. hierarchy view에서 SpawnPointGroup 이름을 갖는 게임오브젝트를 검색
        GameObject spg = GameObject.Find("SpawnPointGroup");
        // 2. SpawnPointGroup 하위에 있는 모든 Transform 컴포넌트를 추출
        spg.GetComponentsInChildren<Transform>(points);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
