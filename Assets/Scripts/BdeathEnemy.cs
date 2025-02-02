using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyStates{Walk, Atk, Death, Pause}

public class BdeathEnemy : Enemies, IScreen
{
    private FSM _FSM;

    [SerializeField]float cooldownHit;

    PlayerHealth allayClose; public PlayerHealth allay { get { return allayClose; } }

    protected override void Start()//asi detecta el start  de Enemies
    {
        base.Start();

        _FSM = new FSM();
        _FSM.AddState(EnemyStates.Walk, new DeathWalk(_FSM, this));
        _FSM.AddState(EnemyStates.Atk, new DeathAtk(_FSM, this, cooldownHit,GetComponent<EnemyHealth>().typeOfEntity));
        _FSM.AddState(EnemyStates.Death, new DeathDead(_FSM, this));
        _FSM.AddState(EnemyStates.Pause, new EnemyPause(_FSM, this, animator));
        _FSM.ChangeState(EnemyStates.Walk);
        AddToListEntitySM();

    }

    
    void Update()
    {
        _FSM.Update();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerHealth>() != null)
        {
            _FSM.ChangeState(EnemyStates.Atk);
            allayClose = collision.GetComponent<PlayerHealth>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerHealth>() != null)
        {
            _FSM.ChangeState(EnemyStates.Walk);
            allayClose = null;
        }
    }

    public void AddToListEntitySM() //Sumo la entidad al primer push
    {
        if (SMEntity._entityList.Contains(this)) return;
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
        EnemyHealth health = GetComponent<EnemyHealth>();
        EntityFactory.Instance.ReturnEntity(health.typeOfEntity, health);
        //Destroy(this);
    }

   
}
