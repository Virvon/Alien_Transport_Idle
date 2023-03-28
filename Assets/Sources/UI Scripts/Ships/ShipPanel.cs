using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShipPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _shipCountValue;

    private ShipBuying[] _shipViews;

    private int _shipCount = 0;

    private void OnEnable()
    {
        _shipViews = GetComponentsInChildren<ShipBuying>();

        foreach (var shipView in _shipViews)
            shipView.ShipCreated += SetShipsCount;
    }

    private void OnDisable()
    {
        foreach (var shipView in _shipViews)
            shipView.ShipCreated -= SetShipsCount;
    }

    private void SetShipsCount(Ship ship)
    {
        _shipCount++;
        _shipCountValue.text = _shipCount.ToString();
    }
}
