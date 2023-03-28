using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShipBuying))]
public class ShipImprover : MonoBehaviour
{
    private Ship _ship;

    private ShipBuying _shipBuying;

    private void OnEnable()
    {
        _shipBuying = GetComponent<ShipBuying>();
        _shipBuying.ShipCreated += SetShip;
    }

    private void OnDisable()
    {
        _shipBuying.ShipCreated -= SetShip;
    }

    public void UpdateSpeed()
    {
        _ship.TryUpdateSpeed();
    }

    public void UpdateCapacity()
    {
        _ship.TryUpdateCapacity();
    }

    private void SetShip(Ship ship)
    {
        _ship = ship;
    }
}
