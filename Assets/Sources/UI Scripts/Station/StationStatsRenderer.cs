using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(StationView))]
public class StationStatsRenderer : MonoBehaviour
{
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _quantityPerMinuteValue;
    [SerializeField] private TMP_Text _maxPassengersCountValue;
    [SerializeField] private TMP_Text _quantityPerMinuteLevelValue;
    [SerializeField] private TMP_Text _maxPassengersCountLevelValue;
    [SerializeField] private TMP_Text _quantityPerMinuteUpdateCostValue;
    [SerializeField] private TMP_Text _maxPassengersCountUpdateCostValue;

    private Station _station;

    private void OnEnable()
    {
        _station = GetComponent<StationView>().Station;
        _title.text = name;
        _station.CharacteristicsChanged += UpdateStats;   
    }

    private void OnDisable()
    {
        _station.CharacteristicsChanged -= UpdateStats;
    }

    private void UpdateStats(StationCharacteristics characteristics)
    {
        _quantityPerMinuteValue.text = characteristics.QuantityPerMinute.ToString();
        _quantityPerMinuteLevelValue.text = characteristics.QuantityPerMinuteUpdateLevel.ToString();
        _quantityPerMinuteUpdateCostValue.text = characteristics.QuantityPerMinuteUpdateCost.ToString();

        _maxPassengersCountValue.text = characteristics.MaxPassengersCount.ToString();
        _maxPassengersCountLevelValue.text = characteristics.MaxPassengersCountUpdateLevel.ToString();
        _maxPassengersCountUpdateCostValue.text = characteristics.MaxPassengersCoutnUpdateCost.ToString();
    }
}
