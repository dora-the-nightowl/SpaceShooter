using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterCtrl : MonoBehaviour
{
    // 몬스터의 상태 정의
    public enum State
    {
        IDLE,
        TRACE,
        ATTACK,
        DIE
    }
    // 몬스터의 상태를 저장할 변수
    public State state = State.IDLE;

    public float attackDist = 2.0f;  // 공격 사정거리
    public float traceDist = 10.0f;  // 추적 사정거리

    public Transform playerTr;
    private NavMeshAgent agent;

    public bool isDie = false;

    // Start is called before the first frame update
    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();    
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(playerTr.position);
    }

    // 몬스터의 상태를 체크하는 coroutine
    IEnumerator CheckMonsterState()
    {
        while (!isDie)
        {
            yield return new WaitForSeconds(0.3f);
        }
    }
}

/*
    유한상태머신(Finite State Machine) FSM
    - NPC AI 구현하기 위한 기법(방식)
*/
