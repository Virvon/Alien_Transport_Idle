using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipParckingTransition : Transition
{
    private void Update()
    {
        if (transform.position == Target.transform.position)
            NeedTransit = true;
    }
}
