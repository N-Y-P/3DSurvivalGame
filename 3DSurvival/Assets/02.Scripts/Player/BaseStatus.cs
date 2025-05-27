using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatusData
{
    [SerializeField] private float curValue;        // ���� ���°�
    [SerializeField] private float maxValue;        // �ִ� ���°�
    [SerializeField] private float passiveValue;    // �⺻������ ����Ǵ� ���°�(�ڿ�ȸ�� ��)

    public float CurValue { get { return curValue; } set { curValue = value; } }
    public float MaxValue { get { return maxValue; } }
    public float PassiveValue { get { return passiveValue; } }

    public float Percentage => curValue / maxValue;     // UI ǥ�ø� ���� �ۼ�Ʈ

    public void Add(float value)
    {
        curValue = Mathf.Min(curValue + value, maxValue);   // ���°� ȸ��
    }

    public void Subtract(float value)
    {
        curValue = Mathf.Max(curValue - value, 0f);         // ���°� ����
    }
}

public class BaseStatus : MonoBehaviour
{
    [SerializeField] protected StatusData hunger;
    [SerializeField] protected StatusData thirst;

    protected virtual void Update()
    {
        hunger.Subtract(hunger.PassiveValue * Time.deltaTime);  // �⺻ ����� ����
        thirst.Subtract(thirst.PassiveValue * Time.deltaTime);  // �⺻ ���� ����
    }

    protected void Eat(float amount)
    {
        hunger.Add(amount);
    }

    protected void GetHunger(float amount)
    {
        hunger.Subtract(amount);
    }

    protected void Drink(float amount)
    {
        thirst.Add(amount);
    }

    protected void GetThirst(float amount)
    {
        thirst.Subtract(amount);
    }
}