using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    [SerializeField] private PlayerStatus playerStatus; // �÷��̾� ����

    // �÷��̾� ���� UI
    [SerializeField] private StatusUI playerHealthUI;
    [SerializeField] private StatusUI playerStaminaUI;
    [SerializeField] private StatusUI playerHungerUI;
    [SerializeField] private StatusUI playerThirstUI;

    private void Start()
    {
        // �÷��̾� ���� �����͸� �� UI�� ����
        playerHealthUI.Bind(playerStatus.Health);
        playerStaminaUI.Bind(playerStatus.Stamina);
        playerHungerUI.Bind(playerStatus.Hunger);
        playerThirstUI.Bind(playerStatus.Thirst);
    }
}
