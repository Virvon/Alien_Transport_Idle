using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private GameObject _pointsWrapper;

    [SerializeField] private Point _startPoint;

    public Ship CreatShip(Ship shipPrefab)
    {
        var ship = Instantiate(shipPrefab, gameObject.transform, false);
        ship.Init(_player, _pointsWrapper, _startPoint);

        return ship;
    }
}
