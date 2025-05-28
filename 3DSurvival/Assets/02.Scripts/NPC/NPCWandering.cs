using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NPCWandering : MonoBehaviour
{
    [Header("AI")]
    private NavMeshAgent agent;
    public float detectDistance;//�ڵ����� ȥ�� ��ȸ�ϴ� �Ÿ�
    private ALSTATE aiState;

    [Header("Wandering")]
    public float walkSpeed = 3f;
    public float minWanderDistance = 2f;
    public float maxWanderDistance = 5f;
    public float minWanderWaitTime = 5f;
    public float maxWanderWaitTime = 10f;

    private Animator anim;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agent.speed = walkSpeed;
        SetState(ALSTATE.IDLE);
    }

    void SetState(ALSTATE state)
    {
        aiState = state;

        switch(aiState)
        {
            case ALSTATE.IDLE:
                anim.SetBool("IsWalk", false);
                StartCoroutine(IdleRoutine());
                Debug.Log("����");
                break;
            case ALSTATE.WANDERING:
                anim.SetBool("IsWalk", true);
                StartCoroutine(WanderRoutine());
                break;
        }
    }

    IEnumerator IdleRoutine()
    {
        float waitTime = Random.Range(minWanderWaitTime, maxWanderWaitTime);
        yield return new WaitForSeconds(waitTime);

        SetState(ALSTATE.WANDERING);
    }

    IEnumerator WanderRoutine()
    {
        Vector3 wanderTarget = GetWanderLocation();
        agent.SetDestination(wanderTarget);

        agent.isStopped = false;//�̵��簳

        // ������ �̵� ���� �� ����
        while (agent.hasPath && agent.remainingDistance > agent.stoppingDistance)//��ȿ�� ����̰� �����Ÿ��� 0���� Ŭ�� 
        {
            Debug.Log("�ȴ���");
            yield return null;
        }

        // ���߰� Idle�� ��ȯ
        agent.isStopped = true;//�̵� ����

        SetState(ALSTATE.IDLE);
    }
    Vector3 GetWanderLocation()
    {
        NavMeshHit hit;

        NavMesh.SamplePosition(transform.position + (Random.onUnitSphere * Random.Range(minWanderDistance, maxWanderDistance)), out hit, maxWanderDistance, NavMesh.AllAreas);

        int i = 0;
        while (Vector3.Distance(transform.position, hit.position) < detectDistance)
        {
            //onUnitSphere�� �������� 1�� ������ ��
            NavMesh.SamplePosition(transform.position + (Random.onUnitSphere * Random.Range(minWanderDistance, maxWanderDistance)), out hit, maxWanderDistance, NavMesh.AllAreas);
            i++;
            if (i == 30)
                break;
        }

        return hit.position;
    }
}
