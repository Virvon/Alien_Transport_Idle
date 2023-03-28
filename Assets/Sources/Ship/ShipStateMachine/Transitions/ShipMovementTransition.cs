using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementTransition : Transition
{
    private Ship _ship;

    protected override void OnEnable()
    {
        _ship = GetComponent<Ship>();
        _ship.TargetChanged += Transit;
        base.OnEnable();
    }

    private void OnDisable()
    {
        _ship.TargetChanged -= Transit;
    }

    private void Transit(Point point)
    {
        NeedTransit = true;
    }
}
