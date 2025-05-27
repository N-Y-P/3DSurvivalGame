using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStatus : BaseStatus
{

    [SerializeField] private int curLevel = 1;//ó�� ����
    [SerializeField] private int curExp = 0;//���� ����ġ

    protected override void Update()
    {
        base.Update();
    }

    public void GetExp()
    {
        //�Ϸ簡 ���� �� ����ġ ����
        
        int expGain = 0;
        if(hunger.CurValue >= 80 && thirst.CurValue >= 80) //������ 80 �̻� && ������� 80 �̻��̸� exp += 100
        {
            expGain = 100;
        }
        else if(hunger.CurValue >= 80 ||  thirst.CurValue >= 80)//�� �� �ϳ��� 80�̸��̸� exp += 50
        {
            expGain = 50;
        }
        else//�� �� 80�̸��̸� exp += 30
        {
            expGain = 30;
        }
        curExp += expGain;
        LevelUp();

    }

    public void LevelUp()
    {
        //�������� ���� �� ȣ���ؾ��� 
        Debug.Log($"������ : ���� ������ {curLevel}");

        if(curLevel == 2 || curLevel == 5)
        {
            //������ ���� �̺�Ʈ ó��
            Debug.Log($"{curLevel}�������� Ư�� �̺�Ʈ �߻�!");
        }
    }
}
