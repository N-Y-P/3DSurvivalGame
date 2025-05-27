using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum ALSTATE
{
    IDLE,
    WANDERING
}
public class NPCWandering : MonoBehaviour
{
    [Header("AI")]
    private NavMeshAgent agent;
    public float detectDistance;//�ڵ����� ȥ�� ��ȸ�ϴ� �Ÿ�
    private ALSTATE aiState;

    [Header("Wandering")]
    public float minWanderDistance;
    public float maxWanderDistance;
    public float minWanderWaitTime;
    public float maxWanderWaitTime;

    private void Start()
    {
        
    }

    void SetState(ALSTATE state)
    {
        aiState = state;

        switch(aiState)
        {
            case ALSTATE.IDLE:
                break;
            case ALSTATE.WANDERING:
                break;
        }
    }
}
