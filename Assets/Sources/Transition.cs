using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    public State TargetState => _targetState;

    public bool NeedTransit { get; protected set; }

    protected Point Target { get; private set; }

    public void Init(Point target)
    {
        Target = target;
    }

    protected virtual void OnEnable()
    {
        NeedTransit = false;
    }
}
