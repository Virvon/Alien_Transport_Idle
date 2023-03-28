using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationView : MonoBehaviour
{
    [SerializeField] private Station _station;

    public Station Station => _station;
}
