using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStatus : BaseStatus
{

    [SerializeField] private StatusData exp;

    protected override void Update()
    {
        base.Update();
    }

    public void GetExp(float amount)
    {
        //���� ������ �ʿ�
        //������ ���� �ٸ�
        //���� �� ���� �ʿ�
        exp.Add(amount);
    }

}
