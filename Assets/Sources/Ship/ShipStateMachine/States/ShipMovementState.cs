using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent (typeof(ShipCharacteristics))]
public class ShipMovementState : State
{

    [SerializeField] private float _minDistanceToNextShip;
    [SerializeField] private float _rotationSpeed;

    [SerializeField] private GameObject _overtakeEffeck;

    private Ship _firstShipInFront;
    private Ship _secondShipInFront;

    private ShipCharacteristics _characteristics;

    private void Start()
    {
        _characteristics = GetComponent<ShipCharacteristics>();
    }


    private void Update()
    {
        float currentSpeed = _characteristics.Speed;
        SetShipsOnWay();

        if (_firstShipInFront != null)
        {
            float distanceToFirstShip = (transform.position - _firstShipInFront.transform.position).magnitude;

            if(distanceToFirstShip <= _minDistanceToNextShip)
            {
                bool canOvertake = TryOvertake(_firstShipInFront, _secondShipInFront, Target);

                if (canOvertake == false)
                    currentSpeed = 0;
            }
        }

        var direction = (Target.transform.position - transform.position).normalized;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), _rotationSpeed);
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, currentSpeed * Time.deltaTime);
    }

    private bool TryOvertake(Ship firstShip, Ship secondShip, Point target)
    {
        float minInterval = 2 * _minDistanceToNextShip + GetComponent<BoxCollider>().size.z;
        float distanceFromFirstShipToTarget = (firstShip.transform.position - target.transform.position).magnitude;

        if (distanceFromFirstShipToTarget <= minInterval)
            return false;

        if (secondShip != null)
        {
            float distanceFromFirstToSecondShip = (secondShip.transform.position - firstShip.transform.position).magnitude;

            if (distanceFromFirstToSecondShip <= minInterval)
                return false;
        }

        Overtake(firstShip, target);
        return true;
    }

    private void Overtake(Ship shipInFront, Point target)
    {
        var direction = (target.transform.position - transform.position).normalized;
        float distance = 2 * _minDistanceToNextShip + shipInFront.GetComponent<BoxCollider>().size.z;
        transform.position += direction * distance;
        SetShipsOnWay();
    }

    private void SetShipsOnWay()
    {
        RaycastHit[] hits = GetHitsOnWay(Target);
        Ship[] ships = SortNearestShips(hits);

        if (ships.Length > 0)
            _firstShipInFront = ships[0];
        else
            _firstShipInFront = null;

        if (hits.Length > 1)
            _secondShipInFront = ships[1];
        else
            _secondShipInFront = null;
    }

    private RaycastHit[] GetHitsOnWay(Point target)
    {
        var distance = (target.transform.position - transform.position).magnitude;
        var direction = (target.transform.position - transform.position).normalized;
        return Physics.RaycastAll(transform.position, direction, distance);
    }

    private Ship[] SortNearestShips(RaycastHit[] hits)
    {
        List<Ship> ships = new List<Ship>();

        foreach (var hit in hits)
            if (hit.collider.TryGetComponent(out Ship ship))
                if (ship != null)
                    ships.Add(ship);

        for(int i = 0; i < ships.Count; i++)
        {
            for(int j = 0; j < ships.Count - 1 - i; j++)
            {
                if((transform.position - ships[j].transform.position).magnitude > (transform.position - ships[j + 1].transform.position).magnitude)
                {
                    var temporaryValue = ships[j];
                    ships[j] = ships[j + 1];
                    ships[j + 1] = temporaryValue;
                }
            }
        }

        return ships.ToArray();
    }
}
