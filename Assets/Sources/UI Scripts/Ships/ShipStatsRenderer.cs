using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(ShipBuying))]
public class ShipStatsRenderer : MonoBehaviour
{
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _speedValue;
    [SerializeField] private TMP_Text _capacityValue;
    [SerializeField] private TMP_Text _fareValue;
    [SerializeField] private TMP_Text _speedLevelValue;
    [SerializeField] private TMP_Text _capacityLevelValue;
    [SerializeField] private TMP_Text _speedUpdateCostValue;
    [SerializeField] private TMP_Text _capacityUpdateCostValue;

    private Ship _ship;

    private ShipBuying _shipBuying;


    private void OnEnable()
    {
        _title.text = name;
        _shipBuying = GetComponent<ShipBuying>();
        _shipBuying.ShipCreated += SetShip;
    }

    private void OnDisable()
    {
        _shipBuying.ShipCreated -= SetShip;
    }

    private void OnDestroy()
    {
        _ship.CharacteristicsChanged -= UpdateStats;
    }

    private void UpdateStats(ShipCharacteristics characteristics)
    {
        _speedValue.text = characteristics.Speed.ToString();
        _capacityValue.text = characteristics.MaxPassengersCount.ToString();
        _fareValue.text = characteristics.Fare.ToString();
        _speedLevelValue.text = characteristics.SpeedUpdateLevel.ToString();
        _capacityLevelValue.text = characteristics.CapacityUpdateLevel.ToString();
        _speedUpdateCostValue.text = characteristics.SpeedUpdateCost.ToString();
        _capacityUpdateCostValue.text = characteristics.CapacityUpdateCost.ToString();
    }

    private void SetShip(Ship ship)
    {
        _ship = ship;
        _ship.CharacteristicsChanged += UpdateStats;
    }
}
