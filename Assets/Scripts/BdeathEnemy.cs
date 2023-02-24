using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyStates{Walk, Atk, Death}

public class BdeathEnemy : Enemies
{
    private FSM _FSM;

    void Start()
    {
        _FSM = new FSM();
        _FSM.AddState(EnemyStates.Walk, new DeathWalk(_FSM, this));
        _FSM.AddState(EnemyStates.Atk, new DeathAtk(_FSM, this));
        _FSM.AddState(EnemyStates.Death, new DeathDead(_FSM, this));
        _FSM.ChangeState(EnemyStates.Walk);

    }

    
    void Update()
    {
        _FSM.Update();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Tower>() != null)
        {
            //atacar
        }
    }
}
