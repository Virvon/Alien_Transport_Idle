using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ShipCharacteristics))]
public class Ship : MonoBehaviour
{
    private GameObject _pointsWrapper;

    private Point _startPoint;
    private Point _targetPoint;

    private Player _player;

    private int _passengersCount;

    private List<Point> _points;
    
    private ShipCharacteristics _shipCharacteristics;

    public Point StartPoint => _startPoint;

    public event UnityAction<Point> TargetChanged;
    public event UnityAction<ShipCharacteristics> CharacteristicsChanged;

    private void Start()
    {
        _shipCharacteristics = GetComponent<ShipCharacteristics>();
        _points = _pointsWrapper.GetComponentsInChildren<Point>().ToList();
        _targetPoint = _startPoint;
        TargetChanged?.Invoke(_targetPoint);
        CharacteristicsChanged?.Invoke(_shipCharacteristics);
    }

    public void SetNextTarget(Point target)
    {
        int targetIndex = _points.IndexOf(target);

        if (targetIndex == _points.Count - 1)
            _targetPoint = _points[0];
        else
            _targetPoint = _points[targetIndex + 1];
    }

    public void DropAllPassengers()
    {
        _passengersCount = 0;
    }

    public void TryTakePassenger(Station station)
    {
        if (_passengersCount < _shipCharacteristics.MaxPassengersCount && station.PassengersCount > 0)
        {
            station.TakePassenger();
            _passengersCount++;
            _player.GiveMoney(_shipCharacteristics.Fare);
        }
        else
        {
            SetNextTarget(_targetPoint);
            TargetChanged?.Invoke(_targetPoint);
        }
    }

    public void Init(Player player, GameObject pointsWrapper, Point startPoint)
    {
        _player = player;
        _pointsWrapper = pointsWrapper;
        _startPoint = startPoint;
    }

    public void TryUpdateSpeed()
    { 
        bool isEnoughMoney = _player.TryTakeMoney(_shipCharacteristics.SpeedUpdateCost);

        if (isEnoughMoney)
        {
            _shipCharacteristics.UpgradeSpeed();
            CharacteristicsChanged?.Invoke(_shipCharacteristics);
        }
    }

    public void TryUpdateCapacity()
    {
        bool isEnoughMoney = _player.TryTakeMoney(_shipCharacteristics.CapacityUpdateCost);

        if(isEnoughMoney)
        {
            _shipCharacteristics.UpgradeCapacity();
            CharacteristicsChanged?.Invoke(_shipCharacteristics);
        }
    }
}
