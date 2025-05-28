using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelData
{
    public int level;
    public int requiredExp;
}
public class NPCStatus : BaseStatus
{
    //�����, ������ ������ ǥ���ϰ�
    //�Ϸ簡 ������ �����, ���� ��ġ ������ ���� ����ġ�� ���
    //�������� �մϴ�

    public GameClock clock;

    //����Ǿ�� �ϴ� ��ġ
    [SerializeField] private int curLevel = 1;//ó�� ����
    [SerializeField] private int curExp = 0;//���� ����ġ

    [Header("������ ����ǥ")]
    [SerializeField] private List<LevelData> levelTable;

    void Start()
    {
        // clock�� ������� �ʾҴٸ� ������ �ڵ� Ž��
        if (clock == null)
            clock = FindObjectOfType<GameClock>();

        // �ð� ���� �̺�Ʈ ����
        clock.OnTimeChanged += CheckSleep;
    }

    protected override void Update()
    {
        base.Update();

    }
    // �ð� ���� �� ȣ��Ǵ� �ݹ� �Լ�
    void CheckSleep(int hour, int minute)
    {
        // ���� 2�ð� �Ǹ� �Ϸ� ����
        if (hour == 2 && minute == 0)
        {
            GetExp();
        }
        else if(hour == 6 && minute == 1)
        {
            hunger.CurValue = hunger.MaxValue;
            thirst.CurValue = thirst.MaxValue;
        }

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
        //�Ϸ簡 ������ �� �⺻ ȣ��
        Debug.Log($"���� ������ {curLevel}, ���� ����ġ�� {curExp}");

        bool didLevelUp = false;

        // ���� ������ �ش��ϴ� ����ǥ�� ã�Ƽ� �ݺ� ������
        while (true)
        {
            LevelData data = levelTable.Find(x => x.level == curLevel);
            if (data == null)
            {
                Debug.LogWarning($"���� {curLevel} ����ǥ�� �����ϴ�. ������ �ߴ�");
                break;
            }

            if (curExp >= data.requiredExp)
            {
                curExp -= data.requiredExp;
                curLevel++;
                didLevelUp = true;
                Debug.Log($"������! �� ����: {curLevel}");

                if (curLevel == 2 || curLevel == 5)
                {
                    //������ ���� �̺�Ʈ ó��
                    Debug.Log($"{curLevel}�������� Ư�� �̺�Ʈ �߻�!");
                }
            }
            else
            {
                break;
            }
        }

        if (!didLevelUp)
            Debug.Log("���������� �ʾҽ��ϴ�.");

        Debug.Log($"���� ����: ���� {curLevel}, ���� EXP {curExp}");


    }
}
