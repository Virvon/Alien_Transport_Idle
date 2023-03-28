using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ship))]
public class ShipParckedState : State
{
    [SerializeField] private float _passengerExchangeSpeed;

    private float _lastExchangeTime;

    private Station _station;

    private Ship _ship;

    private void OnEnable()
    {
        _lastExchangeTime = 0;
        _station = Target.Station;
        _ship = GetComponent<Ship>();
        _ship.DropAllPassengers();
    }

    private void Update()
    {       
        _lastExchangeTime += Time.deltaTime;

        if(_lastExchangeTime >= _passengerExchangeSpeed)
        {
            _ship.TryTakePassenger(_station);
            _lastExchangeTime = 0;
        }
    }
}
