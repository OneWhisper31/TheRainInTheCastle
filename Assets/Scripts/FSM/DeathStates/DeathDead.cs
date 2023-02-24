using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathDead : IState
{
    FSM _FSM;
    BdeathEnemy _enemy;

    public DeathDead(FSM fsm, BdeathEnemy enemy)
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

    }

   
}
