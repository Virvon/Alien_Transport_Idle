using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StationView))]
public class StationImprover : MonoBehaviour
{
    private Station _station;

    private void Start()
    {
        _station = GetComponent<StationView>().Station;
    }

    public void UpdateQuantityPerMinute()
    {
        _station.TryUpdateQuantityPerMinute();
    }

    public void UpdateMaxPassengersCount()
    {
        _station.TryUpdateMaxPassengersCount();
    }
}
