using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStatus : BaseStatus
{

    [SerializeField] private StatusData exp;

    [Header("���� ���� �����+���� �Ҹ� �ӵ� ����")]
    [SerializeField] private float hungerDecayMultiplier = 0.5f;  // ����� �÷��̾�� õõ�� ����
    [SerializeField] private float thirstDecayMultiplier = 0.8f;  // �񸶸� �÷��̾�� õõ�� ����

    protected override void Update()
    {
        hunger.Subtract(hunger.PassiveValue * Time.deltaTime * hungerDecayMultiplier);
        thirst.Subtract(thirst.PassiveValue * Time.deltaTime * thirstDecayMultiplier);
    }

    public void GetExp(float amount)
    {
        //���� ������ �ʿ�
        //������ ���� �ٸ�
        //���� �� ���� �ʿ�
        exp.Add(amount);
    }




}
