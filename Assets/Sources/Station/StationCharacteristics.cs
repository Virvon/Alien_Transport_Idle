using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationCharacteristics : MonoBehaviour
{
    [field: SerializeField] public float QuantityPerMinute { get; private set; }

    [field: SerializeField] public int MaxPassengersCount { get; private set; }
    [field: SerializeField] public int QuantityPerMinuteUpdateCost { get; private set; }
    [field: SerializeField] public int MaxPassengersCoutnUpdateCost { get; private set; }

    private int _quantityPerMinuteUpdateLevel = 1;
    private int _maxPassengersCountUpdateLevel = 1;

    public int QuantityPerMinuteUpdateLevel => _quantityPerMinuteUpdateLevel;
    public int MaxPassengersCountUpdateLevel => _maxPassengersCountUpdateLevel;

    public void UpgradeMaxPassengersCount()
    {
        MaxPassengersCount += 2;
        _maxPassengersCountUpdateLevel++;
        MaxPassengersCoutnUpdateCost += 2;
    }

    public void UpgradeQuantityPerMinute()
    {
        QuantityPerMinute += 2.4f;
        _quantityPerMinuteUpdateLevel++;
        QuantityPerMinuteUpdateCost += 3;
    }
}
