using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPause : IState
{
    FSM _fsm;
    BdeathEnemy _enemy;
    Animator _anim;

    public EnemyPause(FSM fsm, BdeathEnemy enemy, Animator anim)
    {
        _fsm = fsm;
        _enemy = enemy;
        _anim = anim;
    }

    public void OnExit()
    {
        if (_anim == null) return;
       _anim.speed = 1;
    }

    public void OnStart()
    {
        if (_anim == null) return;
        _anim.speed = 0;
    }

    public void OnUpdate()
    {

    }
}
