using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ShipBuying : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private int _cost;

    [SerializeField] private Ship _shipPrefab;

    [SerializeField] private SpawnPoint _spawnPoint;

    [SerializeField] private GameObject _hidingPanel;

    [SerializeField] private TMP_Text _costValue;

    public event UnityAction<Ship> ShipCreated;

    private void Start()
    {
        _costValue.text = _cost.ToString();
    }

    public void TryBuy()
    {
        bool isEnoughMoney = _player.TryTakeMoney(_cost);

        if (isEnoughMoney)
        {
            Ship ship = _spawnPoint.CreatShip(_shipPrefab);
            _hidingPanel.SetActive(false);
            ShipCreated?.Invoke(ship);
        }
    }
}
