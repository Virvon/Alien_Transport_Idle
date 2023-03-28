using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _money;

    public int Money => _money;

    public event UnityAction<int> MoneyCountChanged;
    public event UnityAction MoneySpent;

    private void Start()
    {
        MoneyCountChanged?.Invoke(_money);
    }

    public void GiveMoney(int money)
    {
        _money += money;
        MoneyCountChanged?.Invoke(_money);
    }

    public bool TryTakeMoney(int money)
    {
        if(_money < money)
            return false;

        _money -= money;
        MoneySpent?.Invoke();
        MoneyCountChanged?.Invoke(_money);
        return true;
    }
}
