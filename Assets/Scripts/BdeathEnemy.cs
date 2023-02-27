using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyStates{Walk, Atk, Death, Pause}

public class BdeathEnemy : Enemies, IScreen
{
    private FSM _FSM;
    public Animator anim;
    void Start()
    {
        _FSM = new FSM();
        _FSM.AddState(EnemyStates.Walk, new DeathWalk(_FSM, this));
        _FSM.AddState(EnemyStates.Atk, new DeathAtk(_FSM, this));
        _FSM.AddState(EnemyStates.Death, new DeathDead(_FSM, this));
        _FSM.AddState(EnemyStates.Pause, new EnemyPause(_FSM, this, anim));
        _FSM.ChangeState(EnemyStates.Walk);
        SumarmeAListaEntitySM();

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

    public void SumarmeAListaEntitySM()
    {
        SMEntity._entityList.Add(this);
        Debug.Log("Sumo a la lista y hay "+ SMEntity._entityList.Count);
    }
    //Screen MAanger
    public void Activate()
    {
        _FSM.ChangeState(EnemyStates.Walk);
    }

    public void Deactivate()
    {
        _FSM.ChangeState(EnemyStates.Pause);
    }

    public void Free()
    {
        Destroy(this);
    }
}
