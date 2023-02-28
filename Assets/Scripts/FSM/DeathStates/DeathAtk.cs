using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAtk : IState
{
    FSM _FSM;
    BdeathEnemy _enemy;
    float cooldown, currentCooldown;
    int damage;

    PlayerHealth playerHealth { get { return _enemy.allay; } }

    public DeathAtk(FSM fsm, BdeathEnemy enemy, float _cooldown,TypesOfEntitys type)
    {
        _FSM = fsm;
        _enemy = enemy;
        cooldown = _cooldown;

        switch (type)//daño
        {
            case TypesOfEntitys.Zombie:
                damage=FlyweightPointer.zombie.damage;
                break;
            case TypesOfEntitys.Kamikaze:
                damage = FlyweightPointer.kamikaze.damage;
                break;
            case TypesOfEntitys.Blindado:
                damage = FlyweightPointer.blindado.damage;
                break;
            default:
                break;
        }
    }
    public void OnExit()
    {
        currentCooldown = 0;
    }

    public void OnStart()
    {
        
    }

    public void OnUpdate()
    {
        if (currentCooldown < 0 && playerHealth!=null)
        {
            currentCooldown = cooldown;
            playerHealth.OnHitHandler(damage);
        }
        else
            currentCooldown -= Time.deltaTime;
    }
}
