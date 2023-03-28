using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StationPassengersCount : MonoBehaviour
{
    [SerializeField] private Station _station;

    private TMP_Text _text;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _station.PassengersCountChanged += SetPassengersCount;
    }

    private void OnDisable()
    {
        _station.PassengersCountChanged -= SetPassengersCount;
    }

    private void SetPassengersCount(int passengersCount)
    {
        _text.text = passengersCount.ToString();
    }
}
