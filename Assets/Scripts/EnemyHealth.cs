using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{

    public override void OnHitHandler(int damageDealt)
    {
        base.OnHitHandler(damageDealt);

    }

    protected override void OnDeadHandler()
    {
        if (typeOfEntity == TypesOfEntitys.Blindado)
        {
            //dividir
        }
        base.OnDeadHandler();
    }

    private void Reset()
    {
        switch (typeOfEntity)
        {
            case TypesOfEntitys.Zombie:
                health=FlyweightPointer.zombieHealth.originalHealth;
                break;
            case TypesOfEntitys.Kamikaze:
                health = FlyweightPointer.kamikazeHealth.originalHealth;
                break;
            case TypesOfEntitys.Blindado:
                health = FlyweightPointer.blindadoHealth.originalHealth;
                break;
            default:
                break;
        }
    }

    public static void TurnOn(EnemyHealth b)
    {
        b.gameObject.SetActive(true);
        b.Reset();
    }

    public static void TurnOff(EnemyHealth b)
    {
        b.gameObject.SetActive(false);
    }
}
