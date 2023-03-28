using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCharacteristics : MonoBehaviour
{
    [field: SerializeField] public  int MaxPassengersCount { get; private set; }
    [field: SerializeField] public int CapacityUpdateCost { get; private set; }
    [field: SerializeField] public int Fare { get; private set; }
    [field: SerializeField] public int SpeedUpdateCost { get; private set; }

    [field: SerializeField] public float Speed { get; private set; }

    private int _capacityUpdateLevel = 1;
    private int _speedUpdateLevel = 1;

    public int CapacityUpdateLevel => _capacityUpdateLevel;
    public int SpeedUpdateLevel => _speedUpdateLevel;

    public void UpgradeSpeed()
    {
        Speed += 0.4f;
        SpeedUpdateCost += 5;
        _speedUpdateLevel++;
    }

    public void UpgradeCapacity()
    {
        CapacityUpdateCost += 8;
        Fare++;
        MaxPassengersCount++;
        _capacityUpdateLevel++;
    }
}
