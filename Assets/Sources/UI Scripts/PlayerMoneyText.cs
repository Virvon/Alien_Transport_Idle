using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMoneyText : MonoBehaviour
{
    [SerializeField] private Player _player;

    private TMP_Text _text;

    private void OnEnable()
    {
        _text = GetComponent<TMP_Text>();
        _player.MoneyCountChanged += SetMoney;
    }

    private void OnDisable()
    {
        _player.MoneyCountChanged -= SetMoney;
    }

    private void SetMoney(int money)
    {
        _text.text = money.ToString();
    }
}
