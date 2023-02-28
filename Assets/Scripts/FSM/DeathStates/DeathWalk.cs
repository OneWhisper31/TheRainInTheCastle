using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWalk : IState
{
    FSM _FSM;
    BdeathEnemy _enemy;

    public DeathWalk(FSM fsm, BdeathEnemy enemy)
    {
        _FSM = fsm;
        _enemy = enemy;
    }

    public void OnExit()
    {

    }

    public void OnStart()
    {

    }


    public void OnUpdate()
    {
        _enemy.transform.position += _enemy.enemyType.velocity*-Vector3.right * Time.deltaTime;
    }
     
   
}
