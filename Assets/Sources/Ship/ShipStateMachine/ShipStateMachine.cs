using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ship))]
public class ShipStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private Point _target;

    private State _currentState;

    public State CurrentState => _currentState;

    private void Start()
    {
        Reset(_firstState);
    }

    private void OnEnable()
    {
        GetComponent<Ship>().TargetChanged += SetTarget;
    }

    public void OnDisable()
    {
        GetComponent<Ship>().TargetChanged -= SetTarget;
    }

    private void Update()
    {
        if (CurrentState == null)
            return;

        State nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    private void SetTarget(Point target)
    {
        _target = target;
    }

    private void Reset(State startState)
    {
        _currentState = startState;

        if (_currentState != null)
            _currentState.Enter(_target);
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter(_target);
    }
}
