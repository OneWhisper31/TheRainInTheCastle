using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM
{
    private IState _currentState;
    private Dictionary<EnemyStates, IState> _allStates = new Dictionary<EnemyStates, IState>();

    public void Update()
    {
        _currentState.OnUpdate();
    }

    public void ChangeState(EnemyStates state)
    {
        if (!_allStates.ContainsKey(state)) return;

        if (_currentState != null) _currentState.OnExit();
        _currentState = _allStates[state];
        _currentState.OnStart();
    }
    public void AddState(EnemyStates key, IState value)
    {
        if (!_allStates.ContainsKey(key)) _allStates.Add(key, value);
        else _allStates[key] = value;
    }
}
