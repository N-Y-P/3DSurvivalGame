using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable // �������� �޴� ������Ʈ�� �����ؾ� �� �������̽�
{
    void TakePhysicalDamage(int damage);    // �������� �޴� �Լ�
}

public class PlayerStatus : BaseStatus
{
    [SerializeField] private StatusData health;
    [SerializeField] private StatusData stamina;

    public event Action onTakeDamage;

    protected override void Update()
    {
        base.Update();

        health.Add(health.PassiveValue * Time.deltaTime);  // �⺻ ü�� ����
        stamina.Add(stamina.PassiveValue * Time.deltaTime);  // �⺻ ���׹̳� ����
    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void GetStamina(float amount)
    {
        stamina.Add(amount); // �Է� ����ŭ ���׹̳� ȸ��
    }

    public void TakePhysicalDamage(int damage)
    {
        health.Subtract(damage);    // �Է� ����ŭ ü�� ����
        onTakeDamage?.Invoke();     // �������� �޾Ҵٴ� �̺�Ʈ �߻�
    }

    public bool UseStamina(float amount)
    {
        if (stamina.CurValue - amount < 0f) // ���׹̳��� ������ ���
        {
            return false;
        }

        stamina.Subtract(amount);   // �Է� ����ŭ ���׹̳� �Ҹ�
        return true;
    }
}
